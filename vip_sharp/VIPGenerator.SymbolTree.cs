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
        class SymbolDetailsType
        {
            public string Name;
            public SymbolNode TypeNode;
            public bool TypePointer;
            public int TypeIndices;
        }
        class SymbolNode
        {
            private Dictionary<string, SymbolNode> Children { get; set; } = new Dictionary<string, SymbolNode>();
            public SymbolNode Parent { get; private set; }

            public void AddChild(SymbolNode node)
            {
                Children.Add(node.Details.Name, node);
                node.Parent = this;
            }

            public SymbolNode this[string name] => Children[name];
            public bool Contains(string name) => Children.ContainsKey(name);

            public SymbolType SymbolType;
            public SymbolDetailsType Details = new SymbolDetailsType();
            public List<SymbolDetailsType> Arguments = new List<SymbolDetailsType>();
        }
        SymbolNode SymbolsRoot = new SymbolNode(), CurrentSymbolRoot;

        SymbolNode AddTypeSymbol(string name)
        {
            var symbol = new SymbolNode();
            symbol.Details.Name = name;
            symbol.Details.TypeNode = symbol;
            CurrentSymbolRoot.AddChild(symbol);
            return symbol;
        }

        SymbolNode GetSymbolNode(string path) => GetSymbolNode(path.Split('.').Select(w => w.Trim()).ToArray());
        SymbolNode GetSymbolNode(string[] path)
        {
            // TODO handle arrays 
            var n = CurrentSymbolRoot;

            // first part can bubble up
            if (!n.Contains(path[0]))
            {
                n = SymbolsRoot;
                if (!n.Contains(path[0]))
                    return null;
            }
            n = n[path[0]];

            // everything else only bubbles down
            for (int idx = 1; idx < path.Length; ++idx)
                if (!n.Contains(path[idx]))
                    return null;
                else
                    n = n[path[idx]];

            // and done
            return n;
        }

        void AddVariableSymbol(string name, string type, bool pointer, int indices) => AddVariableSymbol(name, type.Split('.').Select(w => w.Trim()).ToArray(), pointer, indices);
        void AddVariableSymbol(string name, string[] type, bool pointer, int indices)
        {
            var s = new SymbolNode { SymbolType = SymbolType.Variable };

            s.Details.Name = name;
            s.Details.TypeNode = GetSymbolNode(type);
            s.Details.TypePointer = pointer;
            s.Details.TypeIndices = indices;
            CurrentSymbolRoot.AddChild(s);
        }

        void AddBitmapResSymbol(string name)
        {
            var s = new SymbolNode { SymbolType = SymbolType.BitmapRes };
            s.Details.Name = name;
            s.Details.TypeNode = s;
            CurrentSymbolRoot.AddChild(s);
        }

        void AddDisplayListSymbol(string name)
        {
            var s = new SymbolNode { SymbolType = SymbolType.DisplayList };
            s.Details.Name = name;
            s.Details.TypeNode = s;
            CurrentSymbolRoot.AddChild(s);
        }

        void AddTypeDefSymbolAndGoDown(string name)
        {
            var s = AddTypeSymbol(name);
            s.SymbolType = SymbolType.Typedef;
            s.Details.TypeNode = s;
            CurrentSymbolRoot = s;
        }

        void AddStructSymbolAndGoDown(string name)
        {
            var s = AddTypeSymbol(name);
            s.SymbolType = SymbolType.Struct;
            s.Details.TypeNode = s;
            CurrentSymbolRoot = s;
        }

        void AddObjectSymbolAndGoDown(string name, IEnumerable<Tuple<string, string>> @params)
        {
            var s = AddTypeSymbol(name);
            s.SymbolType = SymbolType.Object;
            s.Details.TypeNode = s;
            CurrentSymbolRoot = s;

            foreach (var param in @params)
            {
                var d = new SymbolDetailsType
                {
                    // TODO handle pointers and arrays
                    Name = param.Item2,
                    TypeNode = GetSymbolNode(param.Item1)
                };
            }
        }

        void GoUpSymbol() => CurrentSymbolRoot = CurrentSymbolRoot.Parent;
    }
}
