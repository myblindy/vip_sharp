using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    public class VIPHGenerator : IVIPHNodeVisitor
    {
        public List<UnmanagedDefinition> Variables { get; private set; } = new List<UnmanagedDefinition>();

        private UnmanagedType TypeNameToUnmanagedType(string t)
        {
            if (t == "char") return UnmanagedType.Char;
            if (t == "double") return UnmanagedType.Double;
            if (t == "int") return UnmanagedType.Int;
            if (t == "short") return UnmanagedType.Short;
            if (t == "float") return UnmanagedType.Single;

            throw new InvalidOperationException();
        }

        public void Visit(VIPHDefNode node)
        {
            Variables.Add(new UnmanagedDefinition
            {
                Name = node.VariableName,
                Type = TypeNameToUnmanagedType(node.TypeName),
                ArrayIndex1 = node.ArrayIndex1,
                ArrayIndex2 = node.ArrayIndex2,
            });
        }

        public void Visit(VIPHPlainIdentifierNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPHOptArrNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPHNumberNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPHTypeNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPHDefsNode node)
        {
            throw new NotImplementedException();
        }

        public void Visit(VIPHStructNode node)
        {
            foreach (VIPHNode subnode in node.ChildNodes)
                subnode.Accept(this);
        }

        public void Visit(VIPHProgramNode node)
        {
            foreach (VIPHNode subnode in node.ChildNodes)
                subnode.Accept(this);
        }
    }
}
