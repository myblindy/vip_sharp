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

        public interface IVIPObject
        {
            double GetX();
            double GetY();
            void Run();
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

            private bool Initialized = false;
            public uint TextureID;

            public BitmapRes(BitmapType type, BitmapFilter filter, BitmapClamp clamp, string path)
            {
                Type = type;
                Filter = filter;
                Clamp = clamp;
                Path = path;
            }

            public void EnsureInitialized()
            {
                if (Initialized) return;

                // load the bitmap
                TextureID = gl.GenTexture();
                gl.BindTexture(GL.TEXTURE_2D, TextureID);

                gl.TexImage2D(GL.TEXTURE_2D, 0, Path);
                if (Filter == BitmapFilter.MipMap)
                    gl.GenerateMipmap(GL.TEXTURE_2D);

                gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_S, Clamp == BitmapClamp.Clamp ? GL.CLAMP_TO_EDGE : GL.REPEAT);
                gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_T, Clamp == BitmapClamp.Clamp ? GL.CLAMP_TO_EDGE : GL.REPEAT);
                gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MAG_FILTER, Filter == BitmapFilter.MipMap || Filter == BitmapFilter.Linear ? GL.LINEAR : GL.NEAREST);
                gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MIN_FILTER, Filter == BitmapFilter.MipMap ? GL.LINEAR_MIPMAP_LINEAR : Filter == BitmapFilter.Linear ? GL.LINEAR : GL.NEAREST);

                gl.BindTexture(GL.TEXTURE_2D, 0);

                Initialized = true;
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
            handle.EnsureInitialized();

            gl.Enable(GL.TEXTURE_2D);
            gl.BindTexture(GL.TEXTURE_2D, handle.TextureID);
            gl.TexEnvi(GL.TEXTURE_ENV, GL.TEXTURE_ENV_MODE,
                blend == BitmapBlend.Modulate ? GL.MODULATE :
                blend == BitmapBlend.Decal ? GL.DECAL :
                blend == BitmapBlend.Blend ? GL.BLEND :
                GL.REPLACE);

            gl.Begin(GL.QUADS);

            var texvals = DoublesFromStructure(vertexes[0]);
            gl.TexCoord2d(texvals[0], texvals[1]);
            gl.Vertex2d(x - w / 2, y - h / 2);

            texvals = DoublesFromStructure(vertexes[1]);
            gl.TexCoord2d(texvals[0], texvals[1]);
            gl.Vertex2d(x - w / 2, y + h / 2);

            texvals = DoublesFromStructure(vertexes[2]);
            gl.TexCoord2d(texvals[0], texvals[1]);
            gl.Vertex2d(x + w / 2, y + h / 2);

            texvals = DoublesFromStructure(vertexes[3]);
            gl.TexCoord2d(texvals[0], texvals[1]);
            gl.Vertex2d(x + w / 2, y - h / 2);

            gl.End();
        }

        public void Draw(IVIPObject obj)
        {
            gl.PushMatrix();
            gl.Translated(obj.GetX(), obj.GetY(), 0);
            obj.Run();
            gl.PopMatrix();
        }
    }
}
