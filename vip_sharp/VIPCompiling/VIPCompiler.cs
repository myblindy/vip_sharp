using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace vip_sharp
{
    public static class VIPCompiler
    {
        // Since Uri.LocalPath chokes on # in the path, I have to write my own
        private static string GetLocalPath(string abspath)
        {
            if (abspath.StartsWith("file:///"))
                abspath = abspath.Substring(8);
            else if (abspath.StartsWith("file://"))
                abspath = abspath.Substring(7);
            return abspath.Replace('/', '\\');
        }

        public static Tuple<byte[], byte[]> Compile(string filename, bool debug = true)
        {
            // compile the grammar to C# code
            var grammar = new VIPGrammar();
            var parser = new Parser(grammar);
            var processedsource = new VIPPreprocessor().Preprocess(filename);
            var ast = parser.Parse(processedsource);

            var generator = new VIPGenerator();
            ((VIPProgramNode)ast.Root.AstNode).Accept(generator);

            // compile the C# code
            //var cspath = Path.ChangeExtension(filename, "cs");
            //var cslibpath = Path.ChangeExtension(cspath, "dll");

            var code = generator.Code.ToString();
            //File.WriteAllText(cspath, code);

            var csst = CSharpSyntaxTree.ParseText(code);
            var references = new[]
            {
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),                                                     // mscorlib.dll
                MetadataReference.CreateFromFile(typeof(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException).Assembly.Location),      // Microsoft.CSharp.dll
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),                                                 // System.dll
                MetadataReference.CreateFromFile(typeof(VIPRuntime).Assembly.Location),                                                 // this
            };

            var csc = CSharpCompilation.Create("vip_compiled_assembly", new[] { csst }, references, new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary,
                platform: Platform.X86,
                optimizationLevel: debug ? OptimizationLevel.Debug : OptimizationLevel.Release,
                warningLevel: 0));

            using (var msobj = new MemoryStream())
            using (var mspdb = debug ? new MemoryStream() : null)
            {
                var result = csc.Emit(msobj, mspdb);

                if (!result.Success)
                {
                    var failures = result.Diagnostics.Where(w => w.IsWarningAsError || w.Severity == DiagnosticSeverity.Error);
                    File.WriteAllLines(Path.ChangeExtension(filename, ".errorlog.txt"), failures.Select(w => w.Id + ": " + w.GetMessage()));
                    return null;
                }

                return Tuple.Create(msobj.ToArray(), mspdb?.ToArray());
            }
        }
    }
}
