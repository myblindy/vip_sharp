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

        public static string Compile(string filename)
        {
            var vipcompilerpath = System.Reflection.Assembly.GetExecutingAssembly().GetLocalPath();

            // compile the grammar to C# code
            var grammar = new VIPGrammar();
            var parser = new Parser(grammar);
            var processedsource = VIPPreprocessor.Preprocess(filename);
            var ast = parser.Parse(processedsource);

            var generator = new VIPGenerator();
            ((VIPProgramNode)ast.Root.AstNode).Accept(generator);

            // compile the C# code
            var cspath = Path.ChangeExtension(filename, "cs");
            var cslibpath = Path.ChangeExtension(cspath, "dll");

            File.WriteAllText(cspath, generator.Code.ToString());

            var csc = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "csc.exe");
            var cscargs = $"/out:\"{cslibpath}\" /reference:\"{vipcompilerpath}\" /target:library /platform:x86 \"{cspath}\"";
            var p = Process.Start(new ProcessStartInfo(csc, cscargs) { RedirectStandardError = true, RedirectStandardOutput = true, UseShellExecute = false, CreateNoWindow = true });
            p.WaitForExit();
            if (p.ExitCode != 0)
            {
                // error
                File.WriteAllText(Path.ChangeExtension(filename, ".errorlog.txt"), p.StandardOutput.ReadToEnd());
                return null;
            }

            return cslibpath;
        }
    }
}
