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
            var compilerpath = AppDomain.CurrentDomain.FriendlyName;

            var grammar = new VIPGrammar();
            var parser = new Parser(grammar);
            var ast = parser.Parse(File.ReadAllText(filepath));

            var generator = new VIPGenerator();
            ((VIPProgramNode)ast.Root.AstNode).Accept(generator);

            // run it
            var cspath = Path.ChangeExtension(filepath, "cs");
            var csexepath = Path.ChangeExtension(cspath, "dll");
            try
            {
                Console.WriteLine(generator.Code.ToString());
                File.WriteAllText(cspath, generator.Code.ToString());
                Process.Start(Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "csc.exe"), $"/out:{csexepath} /reference:{compilerpath} /target:library /platform:x86 {cspath}").WaitForExit();

                VIPUtils.RunGL(csexepath);
            }
            finally { File.Delete(cspath); }
        }
    }
}
