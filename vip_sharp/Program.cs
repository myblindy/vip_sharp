using System;
using System.Windows.Forms;

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

            VIPRuntime.RunGL(compiledfile);
        }
    }
}
