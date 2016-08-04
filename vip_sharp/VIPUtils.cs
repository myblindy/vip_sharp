using OpenGL4NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Drawing;

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

        public enum BitmapType { RGB, RGBA, HardMask, SoftMask }
        public enum BitmapFilter { Linear, Nearest, MipMap }
        public enum BitmapClamp { Clamp, Repeat }
        public enum BitmapBlend { Blend, Modulate, Decal, Replace }
        public enum PositionRef { CTR, CC = CTR, CU, CL, LL, LC, LU, RU, RL, RC }

        public class BitmapRes
        {
            public BitmapType Type;
            public BitmapFilter Filter;
            public BitmapClamp Clamp;
            public string Path;

            private uint ListID;

            public BitmapRes(BitmapType type, BitmapFilter filter, BitmapClamp clamp, string path)
            {
                Type = type;
                Filter = filter;
                Clamp = clamp;
                Path = path;

                // load the bitmap
                ListID = gl.GenLists(1);
                gl.NewList(ListID, GL.COMPILE);

                gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_S, clamp == BitmapClamp.Clamp ? GL.CLAMP : GL.REPEAT);
                gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_T, clamp == BitmapClamp.Clamp ? GL.CLAMP : GL.REPEAT);

                gl.PixelStorei(GL.UNPACK_ALIGNMENT, 4);      // Force 4-byte alignment 
                gl.PixelStorei(GL.UNPACK_ROW_LENGTH, 0);
                gl.PixelStorei(GL.UNPACK_SKIP_ROWS, 0);
                gl.PixelStorei(GL.UNPACK_SKIP_PIXELS, 0);

                var bmp = Image.FromFile(path);
                var w = bmp.Width;
                var h = bmp.Height;

                if (h == 1 || w == 1)
                    throw new NotImplementedException();
                else
                    throw new NotImplementedException();
            }
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

        public void Rotate(double angle) => gl.Rotated(angle, 0, 0, -1);

        public void Polygon<TVertex, TColor>(TVertex[] vertexes, TColor[] colors)
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

        public void Bitmap<TVertex>(BitmapRes handle, BitmapBlend blend, double x, double y, double w, double h, PositionRef @ref, TVertex[] vertexes)
        {

        }
    }
}
