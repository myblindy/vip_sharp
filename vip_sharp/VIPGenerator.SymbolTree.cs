using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeDotNet;

namespace vip_sharp
{
    partial class VIPGenerator
    {
        enum SymbolType { Typedef, Struct, Function, Object, Variable, BitmapRes, StringRes, DisplayList, BuiltInType, Root }
        [DebuggerDisplay("{Name}")]
        class SymbolDetailsType
        {
            public string Name;
            public SymbolNode TypeNode;
            public bool TypePointer;
            public int TypeIndices;
        }
        [DebuggerDisplay("{SymbolType} {Details.Name}")]
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
            public SymbolNode Return;
        }
        SymbolNode SymbolsRoot = new SymbolNode { SymbolType = SymbolType.Root }, CurrentSymbolRoot;

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

            // check the parameters first
            var arg = n.Arguments.FirstOrDefault(w => w.Name == path[0]);

            if (arg == null)
            {
                // first part can bubble up
                while (n != null && !n.Contains(path[0]))
                    n = n.Parent;
                if (n == null)
                    throw new InvalidOperationException();
                n = n[path[0]];
            }
            else
                n = arg.TypeNode;

            // everything else only bubbles down
            for (int idx = 1; idx < path.Length; ++idx)
                if (!n.Contains(path[idx]))
                    throw new InvalidOperationException();
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
            CurrentSymbolRoot.AddChild(s);
        }

        void AddStringResSymbol(string name)
        {
            var s = new SymbolNode { SymbolType = SymbolType.StringRes };
            s.Details.Name = name;
            CurrentSymbolRoot.AddChild(s);
        }

        void AddDisplayListSymbol(string name)
        {
            var s = new SymbolNode { SymbolType = SymbolType.DisplayList };
            s.Details.Name = name;
            CurrentSymbolRoot.AddChild(s);
        }

        void AddTypeDefSymbolAndGoDown(string name)
        {
            var s = AddTypeSymbol(name);
            s.SymbolType = SymbolType.Typedef;
            CurrentSymbolRoot = s;
        }

        void AddStructSymbolAndGoDown(string name)
        {
            var s = AddTypeSymbol(name);
            s.SymbolType = SymbolType.Struct;
            CurrentSymbolRoot = s;
        }

        void AddObjectSymbolAndGoDown(string name)
        {
            var s = AddTypeSymbol(name);
            s.SymbolType = SymbolType.Object;
            CurrentSymbolRoot = s;
        }

        void AddFunctionSymbol(string name, string returntype, IEnumerable<Tuple<string, string>> @params)
        {
            var s = AddTypeSymbol(name);
            s.SymbolType = SymbolType.Function;
            if (!string.IsNullOrWhiteSpace(returntype))
                s.Return = GetSymbolNode(returntype);
            CurrentSymbolRoot = s;

            if (@params != null)
                foreach (var param in @params)
                {
                    var d = new SymbolDetailsType
                    {
                        // TODO handle pointers and arrays
                        Name = param.Item2,
                        TypeNode = GetSymbolNode(param.Item1)
                    };
                    s.Arguments.Add(d);
                }
        }

        void GoUpSymbol() => CurrentSymbolRoot = CurrentSymbolRoot.Parent;

        void AddBuiltInTypeSymbol(string name)
        {
            var s = new SymbolNode { SymbolType = SymbolType.BuiltInType };
            s.Details.Name = name;
            CurrentSymbolRoot.AddChild(s);
        }
    }
}
