using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeDotNet;

namespace vip_sharp
{
    partial class VIPGenerator
    {
        enum SymbolType { Typedef, Struct, Function, Object, Variable, BitmapRes, DisplayList }
        class SymbolNode
        {
            private Dictionary<string, SymbolNode> Children { get; set; } = new Dictionary<string, SymbolNode>();
            private SymbolNode Parent;

            public void AddChild(SymbolNode node)
            {
                Children.Add(node.Name, node);
                node.Parent = this;
            }

            public SymbolNode this[string name] => Children[name];

            public SymbolType SymbolType;
            public string Name;
            public string[] TypeParts;
            public bool TypePointer;
            public int TypeIndices;
        }
        SymbolNode SymbolsRoot = new SymbolNode(), CurrentSymbolRoot;

        void AddVariableSymbol(string name, string type, bool pointer, int indices) => AddVariableSymbol(name, type.Split('.').Select(t => t.Trim()).ToArray(), pointer, indices);
        void AddVariableSymbol(string name, string[] type, bool pointer, int indices) => CurrentSymbolRoot.AddChild(new SymbolNode
        {
            Name = name,
            TypeParts = type,
            TypePointer = pointer,
            TypeIndices = indices,
            SymbolType = SymbolType.Variable
        });

        void AddBitmapRes(string name) => CurrentSymbolRoot.AddChild(new SymbolNode { Name = name, SymbolType = SymbolType.BitmapRes });

        void AddDisplayList(string name) => CurrentSymbolRoot.AddChild(new SymbolNode { Name = name, SymbolType = SymbolType.DisplayList });
    }
}
