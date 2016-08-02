using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Irony.Interpreter;
using Irony.Parsing;

namespace vip_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var grammar = new VIPGrammar();
            var parser = new Parser(grammar);
            var ast = parser.Parse(File.ReadAllText("test.vip"));

            var generator = new VIPGenerator();
            ((VIPProgramNode)ast.Root.AstNode).Accept(generator);

            // run it
            var cspath = Path.GetTempFileName();
            var csexepath = Path.ChangeExtension(cspath, "exe");
            try
            {
                File.WriteAllText(cspath, generator.Code.ToString());
                Process.Start(Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "csc.exe"), $"/out:{csexepath} {cspath}").WaitForExit();
                Process.Start(csexepath).WaitForExit();
            }
            finally { File.Delete(cspath); File.Delete(csexepath); }
        }
    }
}
