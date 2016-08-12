using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSharp.DataStructures.TrieSpace;
using Irony.Parsing;

namespace vip_sharp
{
    public static class VIPPreprocessor
    {
        private static Regex InstructionRegex = new Regex(@"^\s*(use|define)\s+(.*)\s*$", RegexOptions.IgnoreCase);
        private static Dictionary<string, string> Defines = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public static string Preprocess(string filename)
        {
            // init defines
            Defines.Clear();
            Defines.Add("BLACK", "0");
            Defines.Add("DARK_GREY", "1");
            Defines.Add("GREY", "2");
            Defines.Add("LIGHT_GREY", "3");
            Defines.Add("WHITE", "4");
            Defines.Add("RED", "5");
            Defines.Add("GREEN", "6");
            Defines.Add("BLUE", "7");
            Defines.Add("CYAN", "8");
            Defines.Add("MAGENTA", "9");
            Defines.Add("YELLOW", "10");
            Defines.Add("AMBER", "11");
            Defines.Add("ORANGE", "12");
            Defines.Add("VIOLET", "13");
            Defines.Add("BROWN", "14");
            Defines.Add("LIGHT_BROWN", "15");
            Defines.Add("DARK_GREEN", "16");
            Defines.Add("LIGHT_GREEN", "17");
            Defines.Add("LIGHT_RED", "18");
            Defines.Add("DARK_RED", "19");
            Defines.Add("DARK_CYAN", "20");
            Defines.Add("SOFT_BLUE", "21");
            Defines.Add("PINK", "22");
            Defines.Add("GOLD", "23");

            return _Preprocess(filename);
        }

        private static string _Preprocess(string filename)
        {
            var sb = new StringBuilder();

            foreach (var line in File.ReadLines(filename))
            {
                var m = InstructionRegex.Match(line);
                if (m.Success)
                {
                    if (m.Groups[1].Value.EqualsI("use"))
                    {
                        // include the file instead of the line
                        var f = m.Groups[2].Value;
                        if (f.StartsWith("\"") && f.EndsWith("\""))
                            f = f.Substring(1, f.Length - 2);
                        sb.AppendLine(_Preprocess(f));
                    }
                    else
                    {
                        // define
                        var idx = m.Groups[2].Value.IndexOfAny(new[] { ' ', '\t' });
                        var key = m.Groups[2].Value.Substring(0, idx);
                        var val = m.Groups[2].Value.Substring(idx + 1);

                        if (Defines.ContainsKey(key))
                            Defines[key] = val;
                        else
                            Defines.Add(key, val);
                    }
                }
                else
                {
                    for (int idx = 0; idx < line.Length; ++idx)
                    {
                        if (string.Compare(line, idx, ".and.", 0, 5, true) == 0)
                        {
                            sb.Append(" .AND. ");
                            idx += 4;
                        }
                        else if (string.Compare(line, idx, ".or.", 0, 4, true) == 0)
                        {
                            sb.Append(" .OR. ");
                            idx += 3;
                        }
                        else
                        {
                            // is this a define?
                            var len = 0;
                            while (idx + len < line.Length && (char.IsLetterOrDigit(line[idx + len]) || line[idx + len] == '_'))
                                len++;
                            var word = line.Substring(idx, len);

                            string val;
                            if (len > 0 && Defines.TryGetValue(word, out val))
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

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
