using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace vip_sharp
{
    public class VIPPreprocessor
    {
        private class ObjectPayload
        {
            private class FieldMappingComparer : IEqualityComparer<Dictionary<string, string>>
            {
                public bool Equals(Dictionary<string, string> x, Dictionary<string, string> y) =>
                    x.Count == y.Count && !x.Except(y).Any();

                public int GetHashCode(Dictionary<string, string> obj)
                {
                    int res = 0;
                    foreach (var kvp in obj)
                        res = res * 23 + kvp.Key.GetHashCode() ^ kvp.Value.GetHashCode();
                    return res;
                }
            }

            internal ContinuationStringBuilder Body = new ContinuationStringBuilder();
            internal MyStringBuilder ContinuationPoint;
            internal bool Used;
            internal Dictionary<Dictionary<string, string>, int> FieldMapping = new Dictionary<Dictionary<string, string>, int>(new FieldMappingComparer());
            internal string Name;
        }

        private Regex InstructionRegex = new Regex(@"^\s*(use|define)\s+(.*?)\s*;?\s*(?://.*)?$", RegexOptions.IgnoreCase);
        private Dictionary<string, ObjectPayload> Objects = new Dictionary<string, ObjectPayload>(StringComparer.OrdinalIgnoreCase);
        private HashSet<string> ProcessedFiles = new HashSet<string>();
        private int MaxAutogenID;

        public string Preprocess(string filename)
        {
            // init defines
            var defines = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            defines.Add("BLACK", "0");
            defines.Add("DARK_GREY", "1");
            defines.Add("GREY", "2");
            defines.Add("LIGHT_GREY", "3");
            defines.Add("WHITE", "4");
            defines.Add("RED", "5");
            defines.Add("GREEN", "6");
            defines.Add("BLUE", "7");
            defines.Add("CYAN", "8");
            defines.Add("MAGENTA", "9");
            defines.Add("YELLOW", "10");
            defines.Add("AMBER", "11");
            defines.Add("ORANGE", "12");
            defines.Add("VIOLET", "13");
            defines.Add("BROWN", "14");
            defines.Add("LIGHT_BROWN", "15");
            defines.Add("DARK_GREEN", "16");
            defines.Add("LIGHT_GREEN", "17");
            defines.Add("LIGHT_RED", "18");
            defines.Add("DARK_RED", "19");
            defines.Add("DARK_CYAN", "20");
            defines.Add("SOFT_BLUE", "21");
            defines.Add("PINK", "22");
            defines.Add("GOLD", "23");

            // various housekeeping
            Objects.Clear();
            ProcessedFiles.Clear();
            MaxAutogenID = 0;

            var result = _PreprocessFile(filename, defines).ToString();
            return result;
        }

        private static Dictionary<string, T> CloneDictionary<T>(Dictionary<string, T> d)
        {
            var clone = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
            foreach (var kvp in d)
                clone.Add(kvp.Key, kvp.Value);

            return clone;
        }

        private static Dictionary<string, T> AddOrUpdate<T>(Dictionary<string, T> d, string key, T val)
        {
            if (d.ContainsKey(key))
                d[key] = val;
            else
                d.Add(key, val);
            return d;
        }

        private static Dictionary<string, T> AddOrUpdate<T>(Dictionary<string, T> d, Dictionary<string, T> nd)
        {
            foreach (var kvp in nd)
                AddOrUpdate(d, kvp.Key, kvp.Value);
            return d;
        }

        private static string GetNextToken(string line, ref int idx)
        {
            while (char.IsWhiteSpace(line[idx])) ++idx;
            var endidx = idx;
            while (endidx < line.Length && (char.IsLetterOrDigit(line[endidx]) || line[endidx] == '_')) ++endidx;
            var token = line.Substring(idx, endidx - idx);
            idx = endidx;

            return token;
        }

        private static string GetNextBlock(string line, ref int idx)
        {
            int balance = 1;

            while (char.IsWhiteSpace(line[idx])) ++idx;
            if (line[idx] == '{')
            {
                var startidx = idx++;

                do
                {
                    if (line[idx] == '{')
                        ++balance;
                    else if (line[idx] == '}' && --balance == 0)
                        return line.Substring(startidx, idx++ - startidx + 1);
                    // TODO handle strings, comments, etc
                } while (++idx < line.Length);
            }

            throw new InvalidOperationException();
        }

        private static bool GetCharacterToken(string line, ref int idx, char c)
        {
            while (char.IsWhiteSpace(line[idx])) ++idx;
            return line[idx++] == c;
        }

        private ContinuationStringBuilder _PreprocessFile(string filename, Dictionary<string, string> defines)
        {
            var added = ProcessedFiles.Add(filename);
            var sb = new ContinuationStringBuilder();
            if (!added)
                sb.AppendLine($"// not including {filename}, already added");
            else
            {
                sb.AppendLine($"// including {filename}");
                sb.AppendLine(_Preprocess(File.ReadAllText(filename), defines));
            }

            return sb;
        }

        private bool IsSeparator(char c) => char.IsSeparator(c) || char.IsWhiteSpace(c);

        private ContinuationStringBuilder _Preprocess(string sourcecode, Dictionary<string, string> defines)
        {
            var mastersb = new ContinuationStringBuilder();
            var sb = mastersb;
            int objlvl = -1;
            string line;

            bool first = true;
            using (var s = new StringReader(sourcecode))
                while ((line = s.ReadLine()?.Trim()) != null)
                {
                    if (first) first = false; else sb.AppendLine();

                    var m = InstructionRegex.Match(line);
                    if (m.Success)
                    {
                        if (m.Groups[1].Value.EqualsI("use"))
                        {
                            // include the file instead of the line
                            var f = m.Groups[2].Value;
                            if (f.EndsWith(";"))
                                f = f.Substring(0, f.Length - 1).Trim();
                            if (f.StartsWith("\"") && f.EndsWith("\""))
                                f = f.Substring(1, f.Length - 2);
                            sb.AppendLine(_PreprocessFile(f, defines));
                        }
                        else
                        {
                            // define
                            var idx = m.Groups[2].Value.IndexOfAny(new[] { ' ', '\t' });
                            var key = m.Groups[2].Value.Substring(0, idx);
                            var val = m.Groups[2].Value.Substring(idx + 1);

                            AddOrUpdate(defines, key, val);
                        }
                    }
                    else
                    {
                        for (int idx = 0; idx < line.Length; ++idx)
                        {
                            if (line[idx] == '/' && idx + 1 < line.Length && line[idx + 1] == '/')
                            {
                                // finish processing the line
                                break;
                            }

                            if (line[idx] == '"' && idx + 1 < line.Length)
                            {
                                var end = line.IndexOf('"', idx + 1);
                                if (end > idx)
                                {
                                    sb.Append(line.Substring(idx, end - idx + 1));
                                    idx += end - idx;
                                    continue;
                                }
                            }

                            if (string.Compare(line, idx, "object", 0, 6, true) == 0 && IsSeparator(line[idx + 6]))
                            {
                                idx += 7;
                                // we're starting an object, add the metadata
                                var objname = GetNextToken(line, ref idx);
                                var payload = new ObjectPayload { ContinuationPoint = sb.InsertContinuation() };
                                Objects.Add(objname, payload);
                                sb = payload.Body;
                                objlvl = 0;
                                --idx;

                                continue;
                            }

                            if (string.Compare(line, idx, "instance", 0, 8, true) == 0 && IsSeparator(line[idx + 8]))
                            {
                                // instance call (outside of objects)
                                idx += 9;

                                // get all the fields
                                var objname = GetNextToken(line, ref idx);
                                var instancename = GetNextToken(line, ref idx);
                                var specialblock = GetNextBlock(line, ref idx);
                                string constructorblock = null, definesblock = null;
                                if (GetCharacterToken(line, ref idx, ':'))
                                {
                                    constructorblock = GetNextBlock(line, ref idx);
                                    if (GetCharacterToken(line, ref idx, ':'))
                                        definesblock = GetNextBlock(line, ref idx);
                                    else
                                        --idx;
                                }
                                else
                                    --idx;
                                if (!GetCharacterToken(line, ref idx, ';'))
                                    throw new InvalidOperationException();

                                if (objlvl == -1)
                                {
                                    // process the defines block
                                    var objdef = Objects[objname];
                                    if (definesblock == null)
                                    {
                                        if (!objdef.Used)
                                        {
                                            // first time using this plain object
                                            objdef.Used = true;
                                            objdef.ContinuationPoint.Append("object " + objname + " ");
                                            objdef.ContinuationPoint.AppendLine(_Preprocess(objdef.Body.ToString(), defines).ToString());
                                        }
                                    }
                                    else
                                    {
                                        int didx = 1;
                                        var newdefines = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                                        do
                                        {
                                            var dkey = GetNextToken(definesblock, ref didx);
                                            if (!GetCharacterToken(definesblock, ref didx, '='))
                                                throw new InvalidOperationException();
                                            var endidx = didx;
                                            while (definesblock[endidx] != ',' && definesblock[endidx] != '}') ++endidx;
                                            var dval = definesblock.Substring(didx, endidx - didx);
                                            didx = endidx;

                                            // push it to the new defines list
                                            AddOrUpdate(newdefines, dkey, _Preprocess(dval, defines).ToString());

                                            // comma?
                                            if (!GetCharacterToken(definesblock, ref didx, ','))
                                                --didx;
                                        } while (definesblock[didx] != '}');

                                        // have we used this object before?
                                        int autogenidx;
                                        if (!objdef.FieldMapping.TryGetValue(newdefines, out autogenidx))
                                        {
                                            objdef.FieldMapping.Add(newdefines, autogenidx = MaxAutogenID++);
                                            objdef.Name = objname + "__autogen_" + autogenidx;
                                            objdef.ContinuationPoint.Append("object " + objdef.Name);
                                            objdef.ContinuationPoint.AppendLine(_Preprocess(objdef.Body.ToString(), AddOrUpdate(defines, newdefines)).ToString());
                                        }

                                        // update the object name to write the instance call later
                                        objname = objdef.Name;
                                    }

                                    // for blocks, only preprocess the value parts
                                    Func<string, string> preprocessblock = b =>
                                        "{" +
                                        string.Join(",", b.Substring(1, b.Length - 2).Split(',').Select(p =>
                                        {
                                            var eqidx = p.IndexOf('=');
                                            return p.Substring(0, eqidx + 1) + _Preprocess(p.Substring(eqidx + 1), defines).ToString();
                                        })) +
                                        "}";

                                    // and output the instance call
                                    specialblock = preprocessblock(specialblock).ToString();
                                    sb.Append($"instance {objname} {instancename} {specialblock} ");
                                    if (constructorblock != null)
                                    {
                                        constructorblock = preprocessblock(constructorblock).ToString();
                                        sb.Append($": {constructorblock}");
                                    }
                                    sb.Append(';');
                                }
                                else
                                {
                                    // if we're inside an object, write the call as is
                                    sb.Append($"instance {objname} {instancename} {specialblock} ");
                                    if (constructorblock != null)
                                        sb.Append($": {constructorblock}");
                                    if (definesblock != null)
                                        sb.Append($": {definesblock}");
                                    sb.Append(';');
                                }

                                --idx;

                                continue;
                            }

                            if (objlvl >= 0 && line[idx] == '{')
                            {
                                ++objlvl;
                                sb.Append('{');
                                continue;
                            }
                            else if (objlvl >= 0 && line[idx] == '}' && --objlvl == 0)
                            {
                                // done with the object
                                sb.Append('}');
                                objlvl = -1;
                                sb = mastersb;
                                continue;
                            }

                            if (string.Compare(line, idx, ".and.", 0, 5, true) == 0)
                            {
                                sb.Append(" .AND. ");
                                idx += 4;
                                continue;
                            }

                            if (string.Compare(line, idx, ".or.", 0, 4, true) == 0)
                            {
                                sb.Append(" .OR. ");
                                idx += 3;
                                continue;
                            }

                            // optimization: write separators as is
                            if (line[idx] != '_' && IsSeparator(line[idx]))
                            {
                                sb.Append(line[idx]);
                                continue;
                            }

                            // is this a define?
                            var len = 0;
                            while (idx + len < line.Length && (char.IsLetterOrDigit(line[idx + len]) || line[idx + len] == '_'))
                                len++;
                            var word = line.Substring(idx, len);

                            string val;
                            if (len > 0 && defines.TryGetValue(word, out val))
                            {
                                sb.Append(val);
                                idx += len - 1;
                            }
                            else if (len > 0)
                            {
                                sb.Append(word);
                                idx += len - 1;
                            }
                            else
                                sb.Append(line[idx]);
                        }
                    }
                }

            return mastersb;
        }
    }
}
