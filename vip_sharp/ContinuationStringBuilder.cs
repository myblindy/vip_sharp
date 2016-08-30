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
        public virtual void Append(double d) => sb.Append(d);
        public virtual void AppendLine(string s) => sb.AppendLine(s);
        public virtual void AppendLine() => sb.AppendLine();
        public virtual void Remove(int start, int end) => sb.Remove(start, end);
        public virtual int Length => sb.Length;

        public override string ToString() => sb.ToString();
    }

    public class ContinuationStringBuilder : MyStringBuilder
    {
        private List<MyStringBuilder> Builders = new List<MyStringBuilder>() { new MyStringBuilder() };
        private MyStringBuilder CurrentBuilder => Builders[Builders.Count - 1];

        public override void Append(string s) => CurrentBuilder.Append(s);
        public override void Append(char c) => CurrentBuilder.Append(c);
        public override void Append(double d) => CurrentBuilder.Append(d);
        public void Append(ContinuationStringBuilder csb)
        {
            if (csb != null)
                Builders.AddRange(csb.Builders);
        }
        public void AppendLine(ContinuationStringBuilder csb)
        {
            if (csb != null)
                Builders.AddRange(csb.Builders);
            CurrentBuilder.AppendLine();
        }
        public override void AppendLine(string s) => CurrentBuilder.AppendLine(s);
        public override void AppendLine() => CurrentBuilder.AppendLine();
        public override void Remove(int start, int end) => CurrentBuilder.Remove(start, end);
        public override int Length => CurrentBuilder.Length;

        public MyStringBuilder InsertContinuation()
        {
            var sb = CurrentBuilder;
            Builders.Add(new MyStringBuilder());
            return sb;
        }

        public void RemoveRange(Range r)
        {
            r.FromSB.Remove(r.FromChar, r.FromSB.Length - r.FromChar);
            r.ToSB.Remove(0, r.ToChar);

            // remove anything inbetween
            int idx = 0, from = -1, to = -1;
            foreach (var sb in Builders)
            {
                if (sb == r.FromSB)
                    from = idx;
                else if (sb == r.ToSB)
                {
                    to = idx;
                    break;
                }
                ++idx;
            }
            Builders.RemoveRange(from, to - from);
        }

        public override string ToString() =>
            Builders.Select(b => b.ToString()).Aggregate("", (a, b) => a + b);

        public class Range
        {
            public MyStringBuilder FromSB, ToSB;
            public int FromChar, ToChar;

            public void MarkBeginning(ContinuationStringBuilder csb)
            {
                FromSB = csb.CurrentBuilder;
                FromChar = csb.CurrentBuilder.Length;
            }

            public void MarkEnding(ContinuationStringBuilder csb)
            {
                ToSB = csb.CurrentBuilder;
                ToChar = csb.CurrentBuilder.Length;
            }
        }
    }
}
