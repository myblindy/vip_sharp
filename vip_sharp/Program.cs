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
        [STAThread]
        static void Main(string[] args)
        {
            var filepath = "test.vip";
            var vipcompilerpath = AppDomain.CurrentDomain.FriendlyName;

            // compile the grammar to C# code
            var grammar = new VIPGrammar();
            var parser = new Parser(grammar);
            var ast = parser.Parse(File.ReadAllText(filepath));

            var generator = new VIPGenerator();
            ((VIPProgramNode)ast.Root.AstNode).Accept(generator);

            // compile the C# code
            var cspath = Path.ChangeExtension(filepath, "cs");
            var cslibpath = Path.ChangeExtension(cspath, "dll");

            Console.WriteLine(generator.Code.ToString());
            File.WriteAllText(cspath, generator.Code.ToString());
            Process.Start(
                Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "csc.exe"),
                $"/out:{cslibpath} /reference:{vipcompilerpath} /target:library /platform:x86 {cspath}").WaitForExit();

            // run it
            VIPUtils.RunGL(cslibpath);
        }
    }
}
