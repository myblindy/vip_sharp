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

        private static int StartProcessAndReadOutput(Process process, StringBuilder stdout, StringBuilder stderr)
        {
            var timeout = 10000; // 10s

            using (var outputWaitHandle = new AutoResetEvent(false))
            using (var errorWaitHandle = new AutoResetEvent(false))
            {
                process.OutputDataReceived += (sender, e) =>
                {
                    if (e.Data == null)
                        outputWaitHandle.Set();
                    else
                        stdout.AppendLine(e.Data);
                };
                process.ErrorDataReceived += (sender, e) =>
                {
                    if (e.Data == null)
                        errorWaitHandle.Set();
                    else
                        stderr.AppendLine(e.Data);
                };

                process.Start();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                if (process.WaitForExit(timeout) &&
                    outputWaitHandle.WaitOne(timeout) &&
                    errorWaitHandle.WaitOne(timeout))
                {
                    var exitcode = process.ExitCode;
                    process.Close();
                    return exitcode;
                }
                else
                {
                    // Timed out.
                    return -1;
                }
            }
        }

        public static string Compile(string filename, bool debug = true)
        {
            var vipcompilerpath = System.Reflection.Assembly.GetExecutingAssembly().GetLocalPath();

            // compile the grammar to C# code
            var grammar = new VIPGrammar();
            var parser = new Parser(grammar);
            var processedsource = new VIPPreprocessor().Preprocess(filename);
            var ast = parser.Parse(processedsource);

            var generator = new VIPGenerator();
            ((VIPProgramNode)ast.Root.AstNode).Accept(generator);

            // work around for Irony holding a reference to our (large) grammar too long
            new Grammar();

            // compile the C# code
            var cspath = Path.ChangeExtension(filename, "cs");
            var cslibpath = Path.ChangeExtension(cspath, "dll");

            File.WriteAllText(cspath, generator.Code.ToString());

            var csc = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "csc.exe");
            var cscargs = debug
                ? $"/out:\"{cslibpath}\" /reference:\"{vipcompilerpath}\" /target:library /platform:x86 /warn:0 /nologo /debug \"{cspath}\""
                : $"/out:\"{cslibpath}\" /reference:\"{vipcompilerpath}\" /target:library /platform:x86 /warn:0 /nologo /optimize \"{cspath}\"";
            var p = new Process { StartInfo = new ProcessStartInfo(csc, cscargs) { RedirectStandardError = true, RedirectStandardOutput = true, UseShellExecute = false, CreateNoWindow = true } };

            StringBuilder stdout = new StringBuilder(), stderr = new StringBuilder();
            if (StartProcessAndReadOutput(p, stdout, stderr) != 0)
            {
                // error
                File.WriteAllText(Path.ChangeExtension(filename, ".errorlog.txt"), stdout.ToString());
                return null;
            }

            return cslibpath;
        }
    }
}
