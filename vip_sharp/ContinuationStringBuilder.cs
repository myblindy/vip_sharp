using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    public class MyStringBuilder
    {
        private StringBuilder sb = new StringBuilder();

        public virtual void Append(string s) => sb.Append(s);
        public virtual void Append(char c) => sb.Append(c);
        public virtual void AppendLine(string s) => sb.AppendLine(s);
        public virtual void Append(double d) => sb.Append(d);

        public override string ToString() => sb.ToString();
    }

    public class ContinuationStringBuilder : MyStringBuilder
    {
        private List<MyStringBuilder> Builders = new List<MyStringBuilder>() { new MyStringBuilder() };
        private MyStringBuilder CurrentBuilder => Builders[Builders.Count - 1];

        public override void Append(string s) => CurrentBuilder.Append(s);
        public override void Append(char c) => CurrentBuilder.Append(c);
        public override void AppendLine(string s) => CurrentBuilder.AppendLine(s);
        public override void Append(double d) => CurrentBuilder.Append(d);

        public MyStringBuilder InsertContinuation()
        {
            var sb = CurrentBuilder;
            Builders.Add(new MyStringBuilder());
            return sb;
        }

        public override string ToString() =>
            Builders.Select(b => b.ToString()).Aggregate("", (a, b) => a + b);
    }
}
