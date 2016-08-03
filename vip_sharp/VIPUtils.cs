using OpenGL4NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace vip_sharp
{
    public class VIPUtils
    {
        public static VIPUtils Instance => new VIPUtils();
        private VIPUtils() { }

        internal static RenderingContext rc;
        internal static void RunGL(string libpath)
        {
            if (!Path.IsPathRooted(libpath))
                libpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), libpath);

            var libdomain = AppDomain.CreateDomain("LibDomain");
            var libassembly = libdomain.Load(AssemblyName.GetAssemblyName(libpath));
            dynamic libmainclass = Activator.CreateInstance(libassembly.GetType("__MainClass"));

            var frm = new VIPForm(libmainclass);
            rc = RenderingContext.CreateContext(frm);
            Application.Run(frm);

            AppDomain.Unload(libdomain);
        }

        private static IList<double> DoublesFromStructure<T>(T o)
        {
            var lst = new List<double>();

            foreach (var field in typeof(T).GetFields())
                if (field.FieldType == typeof(double))
                    lst.Add((double)field.GetValue(o));

            return lst;
        }

        public void Scale(double s) => gl.Scaled(s, s, 1);

        public void Translate(double x, double y) => gl.Translated(x, y, 0);

        unsafe public void Polygon<TVertex, TColor>(TVertex[] vertexes, TColor[] colors)
        {
            var cnt = vertexes.Length;
            gl.Begin(GL.POLYGON);

            for (int idx = 0; idx < cnt; ++idx)
            {
                // colors
                var colorvals = DoublesFromStructure(colors[idx]);
                if (colorvals.Count == 3)
                    gl.Color3d(colorvals[0], colorvals[1], colorvals[2]);
                else
                    gl.Color4d(colorvals[0], colorvals[1], colorvals[2], colorvals[3]);

                // vertexes
                var vertexvals = DoublesFromStructure(vertexes[idx]);
                gl.Vertex2d(vertexvals[0], vertexvals[1]);
            }

            gl.End();
        }
    }
}
