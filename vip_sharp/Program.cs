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
            var compiledfile = VIPCompiler.Compile(args[0]);
            if (compiledfile == null)
                return;

            VIPUtils.RunGL(compiledfile);
        }
    }
}
