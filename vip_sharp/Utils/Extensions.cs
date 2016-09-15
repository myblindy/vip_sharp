using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    public static class Extensions
    {
        public static bool EqualsI(this string a, string b) => a.Equals(b, StringComparison.OrdinalIgnoreCase);

        // Since Uri.LocalPath chokes on # in the path, I have to write my own
        public static string GetLocalPath(this Assembly assembly)
        {
            var abspath = assembly.CodeBase;

            if (abspath.StartsWith("file:///"))
                abspath = abspath.Substring(8);
            else if (abspath.StartsWith("file://"))
                abspath = abspath.Substring(7);
            return abspath.Replace('/', '\\');
        }

    }
}
