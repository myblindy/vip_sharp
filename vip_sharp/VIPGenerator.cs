using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    public class VIPGenerator : IVIPNodeVisitor
    {
        public StringBuilder Code = new StringBuilder();

        public VIPGenerator()
        {
        }

        public void Visit(VIPStringNode node)
        {
        }

        public void Visit(VIPPrintCommandNode node)
        {
            Code.AppendLine($"Console.WriteLine(\"{node.ChildNodes[0].AsString}\");");
        }

        public void Visit(VIPCommandNode node)
        {
        }

        public void Visit(VIPCommandsNode node)
        {
        }

        public void Visit(VIPProgramNode node)
        {
            Code.AppendLine("using System;public static class __MainClass { public static void Main(string[] __args) { ");
            foreach (VIPNode command in node.ChildNodes)
                command.Accept(this);
            Code.AppendLine("} }");
        }
    }
}
