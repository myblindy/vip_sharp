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
        public static string Preprocess(string filename)
        {
            return Regex.Replace(
                Regex.Replace(File.ReadAllText(filename), @"\.[aA][nN][dD]\.", " .and. "),
                 @"\.[oO][rR]\.", " .or. ");
        }
    }
}
