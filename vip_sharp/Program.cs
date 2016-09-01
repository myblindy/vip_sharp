using System;
using System.IO;
using System.Windows.Forms;

namespace vip_sharp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            VIPRuntime.LoadINIFile(Path.ChangeExtension(args[0], "ini"));

            var compiledfile = VIPCompiler.Compile(args[0]);
            if (compiledfile == null)
                return;

            VIPRuntime.RunGL(compiledfile);
        }
    }
}
