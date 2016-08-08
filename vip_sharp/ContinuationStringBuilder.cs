using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    internal class ContinuationStringBuilder
    {
        private List<StringBuilder> Builders = new List<StringBuilder>() { new StringBuilder() };
        private StringBuilder CurrentBuilder => Builders[Builders.Count - 1];

        public void Append(string s) => CurrentBuilder.Append(s);
        public void Append(char c) => CurrentBuilder.Append(c);
        public void AppendLine(string s) => CurrentBuilder.AppendLine(s);

        public StringBuilder InsertContinuation()
        {
            var sb = new StringBuilder();
            Builders.Add(sb);
            Builders.Add(new StringBuilder());
            return sb;
        }

        public override string ToString() =>
            Builders.Select(b => b.ToString()).Aggregate("", (a, b) => a + b);
    }
}
