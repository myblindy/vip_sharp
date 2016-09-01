using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    public enum UnmanagedType { Double, Single, Int, Short, Char };

    [DebuggerDisplay("{Type} {Name} {ArrayIndex1} {ArrayIndex2}")]
    public class UnmanagedDefinition
    {
        public UnmanagedType Type;
        public string Name;
        public int? ArrayIndex1, ArrayIndex2;
    }

    public static class VIPHCompiler
    {
        public static IEnumerable<UnmanagedDefinition> Compile(string headersource)
        {
            var grammar = new VIPHGrammar();
            var parser = new Parser(grammar);
            var ast = parser.Parse(File.ReadAllText(headersource));

            var generator = new VIPHGenerator();
            ((VIPHNode)ast.Root.AstNode).Accept(generator);

            return generator.Variables;
        }
    }
}
