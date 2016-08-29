using OpenGL4NET;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using vip_sharp;

namespace tests
{
    public static class VIPTestFramework
    {
        public static dynamic PrepareFile(string path)
        {
            var tmpcs = Path.ChangeExtension(Path.GetTempFileName(), "cs");
            VIPRuntime.VIPObject libmainclass;

            try
            {
                var tmplib = VIPCompiler.Compile(path);

                var frm = new VIPForm(false);
                RenderingContext.CreateContext(frm);

                var libassembly = AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(tmplib));
                libmainclass = (VIPRuntime.VIPObject)Activator.CreateInstance(libassembly.GetType("MainClass"));
            }
            finally
            {
                File.Delete(tmpcs);
            }

            return libmainclass;
        }

        public static dynamic PrepareSource(string source)
        {
            var tmpvip = Path.ChangeExtension(Path.GetTempFileName(), "vip");
            File.WriteAllText(tmpvip, source);

            try
            {
                return PrepareFile(tmpvip);
            }
            finally
            {
                File.Delete(tmpvip);
            }
        }

        public static void Step(dynamic obj)
        {
            gl.Clear(GL.COLOR_BUFFER_BIT);
            gl.MatrixMode(GL.MODELVIEW);
            gl.LoadIdentity();

            obj.Run();
        }

        public static bool Equals(double a, double b) => Math.Abs(a - b) < 0.0001;
    }
}
