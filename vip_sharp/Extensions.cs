using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    public static class Extensions
    {
        public static bool EqualsI(this string a, string b) => a.Equals(b, StringComparison.OrdinalIgnoreCase);
    }
}
