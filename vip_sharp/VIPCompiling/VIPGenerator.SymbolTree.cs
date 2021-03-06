﻿using System;
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
        enum SymbolType { Typedef, Struct, Function, Object, Variable, BitmapRes, StringRes, CalRes, DisplayList, BuiltInType, BuiltInFunction, IOVar, Root }
        [DebuggerDisplay("{Name}")]
        class SymbolDetailsType
        {
            public string Name, RuntimeName;
            public SymbolNode TypeNode;
            public bool TypePointer;
            public int TypeIndices;
        }

        [DebuggerDisplay("{SymbolType} {Details.Name}")]
        class SymbolNode
        {
            private Dictionary<string, SymbolNode> Children { get; set; } = new Dictionary<string, SymbolNode>(StringComparer.OrdinalIgnoreCase);
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
            public List<SymbolNode> Arguments = new List<SymbolNode>();
            public SymbolNode Return;

            public string FullName
            {
                get
                {
                    string name = Details.Name;
                    var n = this;
                    while (n != null && (n = n.Parent).Parent != null)
                        name = n.Details.Name + "." + name;
                    return name;
                }
            }

            public string ConvertCall
            {
                get
                {
                    switch (Details.Name)
                    {
                        case "bool": return "Convert.ToBoolean";
                        case "int": return "Convert.ToInt32";
                        case "short": return "Convert.ToInt16";
                        case "double": return "Convert.ToDouble";
                        case "float": return "Convert.ToSingle";
                        case "char": return "Convert.ToChar";
                        default: return "(" + FullName + ")";
                    }
                }
            }

            public bool IsFunctionScope => SymbolType == SymbolType.Function || SymbolType == SymbolType.DisplayList;
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

        SymbolNode GetSymbolNode(VIPQualifiedIdentifierNode qnode) => GetSymbolNode(qnode.Parts.Select(w => "__" + w.Item1).ToArray());
        SymbolNode GetSymbolNode(string path) => GetSymbolNode(path.Split('.').Select(w => w.Trim()).ToArray());
        SymbolNode GetSymbolNode(string[] path)
        {
            // TODO handle arrays 
            var rooted = path.Length >= 3 && path[0].EqualsI("globalstate") && path[1].EqualsI("mainclass");
            var n = rooted ? SymbolsRoot : CurrentSymbolRoot;
            var startidx = rooted ? 2 : 0;

            // check the parameters first
            var arg = n.Arguments.FirstOrDefault(w => w.Details.Name == path[startidx]);

            if (arg == null)
            {
                // first part can bubble up
                while (n != null && !n.Contains(path[startidx]))
                    n = n.Parent;
                if (n == null)
                    throw new InvalidOperationException();
                n = n[path[startidx]];
            }
            else
                n = arg;

            // everything else only bubbles down
            for (int idx = startidx + 1; idx < path.Length; ++idx)
            {
                n = n.Details.TypeNode;
                if (!n.Contains(path[idx]))
                    throw new InvalidOperationException();
                else
                    n = n[path[idx]];
            }

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

        void AddIOVariableSymbol(string name, string type, int indices)
        {
            var s = new SymbolNode { SymbolType = SymbolType.IOVar };

            s.Details.Name = name;
            s.Details.TypeNode = GetSymbolNode(type);
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

        void AddCalResSymbol(string name)
        {
            var s = new SymbolNode { SymbolType = SymbolType.CalRes };
            s.Details.Name = name;
            CurrentSymbolRoot.AddChild(s);
        }

        void AddDisplayListSymbolAndGoDown(string name)
        {
            var s = new SymbolNode { SymbolType = SymbolType.DisplayList };
            s.Details.Name = name;
            CurrentSymbolRoot.AddChild(s);
            CurrentSymbolRoot = s;
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

        void AddFunctionSymbolAndGoDown(string name, string returntype, IEnumerable<Tuple<string[], string, bool>> @params)
        {
            var s = AddTypeSymbol(name);
            s.SymbolType = SymbolType.Function;
            if (!string.IsNullOrWhiteSpace(returntype))
                s.Return = GetSymbolNode(returntype);
            CurrentSymbolRoot = s;

            if (@params != null)
                foreach (var param in @params)
                {
                    var argnode = new SymbolNode { SymbolType = SymbolType.Variable };
                    argnode.Details.Name = param.Item2;
                    argnode.Details.TypeNode = GetSymbolNode(param.Item1);
                    argnode.Details.TypePointer = param.Item3;
                    s.Arguments.Add(argnode);
                };
        }

        void GoUpSymbol() => CurrentSymbolRoot = CurrentSymbolRoot.Parent;

        void AddBuiltInTypeSymbol(string name)
        {
            var s = new SymbolNode { SymbolType = SymbolType.BuiltInType };
            s.Details.Name = name;
            CurrentSymbolRoot.AddChild(s);
        }

        void AddBuiltInFunctionSymbol(string name, string runtimename, string returntype, params Tuple<string, bool>[] @params)
        {
            var s = AddTypeSymbol(name);
            s.Details.RuntimeName = runtimename;
            s.SymbolType = SymbolType.BuiltInFunction;
            if (!string.IsNullOrWhiteSpace(returntype))
                s.Return = GetSymbolNode(returntype);

            foreach (var param in @params)
            {
                var argnode = new SymbolNode { SymbolType = SymbolType.Variable };
                argnode.Details.TypeNode = GetSymbolNode(param.Item1);
                argnode.Details.TypePointer = param.Item2;
                s.Arguments.Add(argnode);
            };
        }
    }
}
