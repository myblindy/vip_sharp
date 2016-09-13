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
using IniParser;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace vip_sharp
{
    public partial class VIPRuntime
    {
        public static VIPRuntime Instance { get; } = new VIPRuntime();
        static VIPRuntime()
        {
            // folor color lookup optimizations
            StandardColorsArray = StandardColors.Values.ToArray();
        }
        private VIPRuntime() { }

        public static RenderingContext rc;
        internal static void RunGL(string libpath)
        {
            if (!Path.IsPathRooted(libpath))
                libpath = Path.Combine(Directory.GetCurrentDirectory(), libpath);

            var frm = new VIPForm();
            var s = new RenderingContextSetting();
            rc = RenderingContext.CreateContext(frm, s);
            frm.InitGL();

            var libassembly = AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(libpath));
            VIPObject libmainclass = (VIPObject)libassembly.CreateInstance("MainClass");
            frm.LibMainClass = libmainclass;

            Application.Run(frm);
        }

        private static double INIValueToDouble(string val, double def = 0)
        {
            try
            {
                return Convert.ToDouble(Regex.Match(val, @"^((?:-\s*)?\d+(?:\.\d+)?)").Value);
            }
            catch { return def; }
        }

        private static string INIValueToString(string val, string def = null)
        {
            var m = Regex.Match(val, @"^([^;]+)");
            return m.Success ? m.Value.Trim() : def;
        }

        internal static void LoadINIFile(string inipath)
        {
            if (File.Exists(inipath))
            {
                var parser = new FileIniDataParser();
                var data = parser.ReadFile(inipath);
                Instance.VIPSystemClass.ModelMinX = INIValueToDouble(data["VIEW"]["X_Left_Corner"], -15);
                Instance.VIPSystemClass.ModelMaxX = INIValueToDouble(data["VIEW"]["X_Right_Corner"], 15);
                Instance.VIPSystemClass.ModelMinY = INIValueToDouble(data["VIEW"]["Y_Bottom_Corner"], -15);
                Instance.VIPSystemClass.ModelMaxY = INIValueToDouble(data["VIEW"]["Y_Upper_Corner"], 15);
                Instance.VIPSystemClass.WindowX = INIValueToDouble(data["HARDWARE"]["X-Pos"], 200);
                Instance.VIPSystemClass.WindowY = INIValueToDouble(data["HARDWARE"]["Y-Pos"], 200);
                Instance.VIPSystemClass.WindowWidth = INIValueToDouble(data["HARDWARE"]["X-Screen-Res"], 400);
                Instance.VIPSystemClass.WindowHeight = INIValueToDouble(data["HARDWARE"]["Y-Screen-Res"], 400);

                var VIPInFile = INIValueToString(data["VIP"]["VIP_In_File"]);
                var VIPOutFile = INIValueToString(data["VIP"]["VIP_Out_File"]);
                var VHPInFile = INIValueToString(data["VHP"]["VHP_In_File"]);
                var VHPOutFile = INIValueToString(data["VHP"]["VHP_Out_File"]);

                if (!string.IsNullOrWhiteSpace(VIPInFile))
                {
                    Instance.VIPSystemClass.VIPInVariables = LoadHeaderFile(VIPInFile);
                    BuildIOVariables(Instance.VIPSystemClass.VIPInVariables);
                }
                if (!string.IsNullOrWhiteSpace(VIPOutFile))
                {
                    Instance.VIPSystemClass.VIPOutVariables = LoadHeaderFile(VIPOutFile);
                    BuildIOVariables(Instance.VIPSystemClass.VIPOutVariables);
                }
                if (!string.IsNullOrWhiteSpace(VHPInFile))
                {
                    Instance.VIPSystemClass.VHPInVariables = LoadHeaderFile(VHPInFile);
                    BuildIOVariables(Instance.VIPSystemClass.VHPInVariables);
                }
                if (!string.IsNullOrWhiteSpace(VHPOutFile))
                {
                    Instance.VIPSystemClass.VHPOutVariables = LoadHeaderFile(VHPOutFile);
                    BuildIOVariables(Instance.VIPSystemClass.VHPOutVariables);
                }
            }
        }

        private static UnmanagedDefinition[] LoadHeaderFile(string path) => VIPHCompiler.Compile(path).ToArray();

        public abstract class VIPObject
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double S { get; set; } = 1;
            public double R { get; set; }

            public double x { get { return X; } set { X = value; } }
            public double y { get { return Y; } set { Y = value; } }
            public double s { get { return S; } set { S = value; } }
            public double r { get { return R; } set { R = value; } }

            public abstract void Run();
        }

        private class ObjectInformationType
        {
            public bool LastPressed;
            public bool LastHover;
            public double LastAngle = double.NaN;
        }
        private Dictionary<Tuple<uint, object>, ObjectInformationType> ObjectInformation = new Dictionary<Tuple<uint, object>, ObjectInformationType>();
        private ObjectInformationType GetObjectInformation(uint id, object obj)
        {
            ObjectInformationType t;
            var key = Tuple.Create(id, obj);
            if (!ObjectInformation.TryGetValue(key, out t))
                ObjectInformation.Add(key, t = new ObjectInformationType());
            return t;
        }

        private class VertexType
        {
            public double X, Y;
            public VertexType(double x, double y) { X = x; Y = y; }
        }

        private static Dictionary<string, Tuple<float, float, float>> StandardColors = new Dictionary<string, Tuple<float, float, float>>(StringComparer.OrdinalIgnoreCase)
        {
            { "BLACK", Tuple.Create(0.000f, 0.000f, 0.000f) },
            { "DARK_GREY", Tuple.Create(0.250f, 0.250f, 0.250f) },
            { "GREY", Tuple.Create(0.500f, 0.500f, 0.500f) },
            { "LIGHT_GREY", Tuple.Create(0.750f, 0.750f, 0.750f) },
            { "WHITE", Tuple.Create(1.000f, 1.000f, 1.000f) },

            { "RED", Tuple.Create(1.000f, 0.000f, 0.000f) },
            { "GREEN", Tuple.Create(0.000f, 1.000f, 0.000f) },
            { "BLUE", Tuple.Create(0.000f, 0.000f, 1.000f) },

            { "CYAN", Tuple.Create(0.000f, 1.000f, 1.000f) },
            { "MAGENTA", Tuple.Create(1.000f, 0.000f, 1.000f) },
            { "YELLOW", Tuple.Create(1.000f, 1.000f, 0.000f) },

            { "AMBER", Tuple.Create(0.980f, 0.666f, 0.235f) },
            { "ORANGE", Tuple.Create(1.000f, 0.647f, 0.000f) },
            { "VIOLET", Tuple.Create(0.541f, 0.169f, 0.886f) },
            { "BROWN", Tuple.Create(0.647f, 0.168f, 0.168f) },
            { "LIGHT_BROWN", Tuple.Create(0.824f, 0.412f, 0.118f) },
            { "DARK_GREEN", Tuple.Create(0.000f, 0.500f, 0.000f) },
            { "LIGHT_GREEN", Tuple.Create(0.157f, 1.000f, 0.157f) },
            { "LIGHT_RED", Tuple.Create(1.000f, 0.216f, 0.216f) },
            { "DARK_RED", Tuple.Create(0.500f, 0.000f, 0.000f) },
            { "DARK_CYAN", Tuple.Create(0.000f, 0.545f, 0.545f) },
            { "SOFT_BLUE", Tuple.Create(0.392f, 0.584f, 0.929f) },
            { "PINK", Tuple.Create(1.000f, 0.078f, 0.576f) },
            { "GOLD", Tuple.Create(1.000f, 0.843f, 0.000f) },
        };
        private static Tuple<float, float, float>[] StandardColorsArray;

        private static IList<double> DoublesFromStructure<T>(T o)
        {
            var lst = new List<double>();

            foreach (var field in typeof(T).GetFields())
                lst.Add(Convert.ToDouble(field.GetValue(o)));

            return lst;
        }

        private void UpdateCoordsWithBoxInfo(ref double x, ref double y, double w, double h, PositionRef @ref)
        {
            switch (@ref)
            {
                case PositionRef.cc:
                    x -= w / 2; y -= h / 2;
                    break;
                case PositionRef.cl:
                    x -= w / 2;
                    break;
                case PositionRef.cu:
                    x -= w / 2; y -= h;
                    break;
                case PositionRef.lc:
                    y -= h / 2;
                    break;
                case PositionRef.ll:
                    break;
                case PositionRef.lu:
                    y -= h;
                    break;
                case PositionRef.rc:
                    x -= w; y -= h / 2;
                    break;
                case PositionRef.rl:
                    x -= w;
                    break;
                case PositionRef.ru:
                    x -= w; y -= h;
                    break;
            }
        }

        private System.Windows.Media.Matrix GetModelViewMatrix()
        {
            // get the model view matrix 
            float[] mat = new float[16];
            gl.GetFloatv(GL.MODELVIEW_MATRIX, mat);

            // convert it to an usable matrix object
            return new System.Windows.Media.Matrix(mat[0], mat[1], mat[4], mat[5], mat[12], mat[13]);
        }

        private class LightDescription
        {
            internal double LightIntensity = 1;
            internal double[] LightValues = new double[4] { 1, 1, 1, 1 };
        }
        Stack<LightDescription> LightStack = new Stack<LightDescription>(Enumerable.Repeat(new LightDescription(), 1));

        private void UpdateAmbientColor()
        {
            var ld = LightStack.Peek();
            var light = new[] { (float)(ld.LightValues[0] * ld.LightIntensity), (float)(ld.LightValues[1] * ld.LightIntensity),
                (float)(ld.LightValues[2] * ld.LightIntensity), (float)(ld.LightValues[3] * ld.LightIntensity) };
            gl.LightModelfv(GL.LIGHT_MODEL_AMBIENT, light);
        }

        private class BitmapData
        {
            internal BitmapType Type;
            internal BitmapFilter Filter;
            internal BitmapClamp Clamp;
            internal string Path;

            internal BitmapData(BitmapType type, BitmapFilter filter, BitmapClamp clamp, string path)
            {
                Type = type;
                Filter = filter;
                Clamp = clamp;
                Path = path;
            }

            public override bool Equals(object obj)
            {
                var bmpdata = obj as BitmapData;
                return ReferenceEquals(bmpdata, null) ? base.Equals(obj)
                    : Type == bmpdata.Type && Filter == bmpdata.Filter && Clamp == bmpdata.Clamp && Path == bmpdata.Path;
            }

            public override int GetHashCode() =>
                ((Type.GetHashCode() * 23 + Filter.GetHashCode()) * 23 + Clamp.GetHashCode()) * 23 + Path.GetHashCode();
        }
        static Dictionary<BitmapData, uint> LoadedBitmaps = new Dictionary<BitmapData, uint>();

        private unsafe static uint LoadBitmap(BitmapType type, BitmapFilter filter, BitmapClamp clamp, string path)
        {
            var bmpkey = new BitmapData(type, filter, clamp, path);
            uint texid;
            if (LoadedBitmaps.TryGetValue(bmpkey, out texid))
                return texid;

            // load the bitmap
            texid = gl.GenTexture();
            gl.BindTexture(GL.TEXTURE_2D, texid);

            Bitmap bmp = null;
            try
            {
                bmp = new Bitmap(path);
                if (type == BitmapType.RGB || type == BitmapType.HardMask)
                    bmp.MakeTransparent(System.Drawing.Color.Black);
                else if (type == BitmapType.SoftMask)
                {
                    // we do this the hard way

                    // make it a 32bpp image
                    if (bmp.PixelFormat != PixelFormat.Format32bppArgb)
                    {
                        var newbmp = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format32bppArgb);
                        using (var g = Graphics.FromImage(newbmp))
                            g.DrawImageUnscaled(bmp, 0, 0);
                        bmp.Dispose();
                        bmp = newbmp;
                    }

                    // update the alpha channel
                    System.Drawing.Imaging.BitmapData bmpdata = null;
                    try
                    {
                        var w = bmp.Width;
                        var h = bmp.Height;

                        bmpdata = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                        var stride = bmpdata.Stride;

                        var scan0 = (byte*)bmpdata.Scan0.ToPointer();

                        for (int i = 0; i < h; ++i)
                            for (int j = 0; j < w; ++j)
                            {
                                var data = scan0 + i * stride + j * 4;

                                data[3] = (byte)((data[0] + data[1] + data[2]) / 3);
                            }
                    }
                    finally
                    {
                        bmp.UnlockBits(bmpdata);
                    }
                }

                gl.TexImage2D(GL.TEXTURE_2D, 0, bmp);
            }
            finally
            {
                bmp.Dispose();
            }

            if (filter == BitmapFilter.MipMap)
                gl.GenerateMipmap(GL.TEXTURE_2D);

            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_S, clamp == BitmapClamp.Clamp ? GL.CLAMP_TO_EDGE : GL.REPEAT);
            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_WRAP_T, clamp == BitmapClamp.Clamp ? GL.CLAMP_TO_EDGE : GL.REPEAT);
            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MAG_FILTER, filter == BitmapFilter.MipMap || filter == BitmapFilter.Linear ? GL.LINEAR : GL.NEAREST);
            gl.TexParameteri(GL.TEXTURE_2D, GL.TEXTURE_MIN_FILTER, filter == BitmapFilter.MipMap ? GL.LINEAR_MIPMAP_LINEAR : filter == BitmapFilter.Linear ? GL.LINEAR : GL.NEAREST);

            gl.BindTexture(GL.TEXTURE_2D, 0);

            LoadedBitmaps.Add(bmpkey, texid);
            return texid;
        }

        internal Dictionary<uint, DisplayList> DisplayLists = new Dictionary<uint, DisplayList>();
    }
}
