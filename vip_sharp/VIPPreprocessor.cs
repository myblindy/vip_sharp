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
        private static Regex UseRegex = new Regex(@"^\s*use\s+(.*)\s*$");

        public static string Preprocess(string filename)
        {
            var sb = new StringBuilder();

            foreach (var line in File.ReadLines(filename))
            {
                var m = UseRegex.Match(line);
                if (m.Success)
                {
                    // include the file instead of the line
                    sb.AppendLine(Preprocess(m.Groups[1].Value));
                }
                else
                    sb.AppendLine(line.Replace(".AND.", " .AND. ").Replace(".OR.", " .OR. "));
            }

            return sb.ToString();
        }
    }
}
