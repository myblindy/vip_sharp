using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Irony.Parsing;

namespace vip_sharp
{
    public static class VIPPreprocessor
    {
        private static Regex UseRegex = new Regex(@"^\s*use\s+(.*)\s*$", RegexOptions.IgnoreCase);

        public static string Preprocess(string filename)
        {
            var sb = new StringBuilder();

            foreach (var line in File.ReadLines(filename))
            {
                var m = UseRegex.Match(line);
                if (m.Success)
                {
                    // include the file instead of the line
                    var f = m.Groups[1].Value;
                    if (f.StartsWith("\"") && f.EndsWith("\""))
                        f = f.Substring(1, f.Length - 2);
                    sb.AppendLine(Preprocess(f));
                }
                else
                    sb.AppendLine(line.Replace(".AND.", " .AND. ").Replace(".OR.", " .OR. "));
            }

            return sb.ToString();
        }
    }
}
