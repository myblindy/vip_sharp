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

namespace vip_sharp
{
    public partial class VIPRuntime
    {
        public static VIPRuntime Instance { get; } = new VIPRuntime();
        private VIPRuntime() { }

        internal static RenderingContext rc;
        internal static void RunGL(string libpath)
        {
            if (!Path.IsPathRooted(libpath))
                libpath = Path.Combine(Directory.GetCurrentDirectory(), libpath);

            LoadINIFile(Path.ChangeExtension(libpath, "ini"));

            var frm = new VIPForm();
            rc = RenderingContext.CreateContext(frm);

            var libassembly = AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(libpath));
            VIPObject libmainclass = (VIPObject)libassembly.CreateInstance("MainClass");
            frm.LibMainClass = libmainclass;

            Application.Run(frm);
        }

        internal static void LoadINIFile(string inipath)
        {
            try
            {
                var parser = new FileIniDataParser();
                var data = parser.ReadFile(inipath);
                Instance.VIPSystemClass.ModelMinX = Convert.ToDouble(data["VIEW"]["X_Left_Corner"]);
                Instance.VIPSystemClass.ModelMaxX = Convert.ToDouble(data["VIEW"]["X_Right_Corner"]);
                Instance.VIPSystemClass.ModelMinY = Convert.ToDouble(data["VIEW"]["Y_Bottom_Corner"]);
                Instance.VIPSystemClass.ModelMaxY = Convert.ToDouble(data["VIEW"]["Y_Upper_Corner"]);
            }
            catch { }
        }

        public abstract class VIPObject
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double s { get; set; }
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

        private Tuple<float, float, float>[] StandardColors = new[]
        {
            Tuple.Create(0.000f, 0.000f, 0.000f),          //BLACK
            Tuple.Create(0.250f, 0.250f, 0.250f),          //DARK_GREY
            Tuple.Create(0.500f, 0.500f, 0.500f),          //GREY
            Tuple.Create(0.750f, 0.750f, 0.750f),          //LIGHT_GREY
            Tuple.Create(1.000f, 1.000f, 1.000f),          //WHITE

            Tuple.Create(1.000f, 0.000f, 0.000f),          //RED
            Tuple.Create(0.000f, 1.000f, 0.000f),          //GREEN
            Tuple.Create(0.000f, 0.000f, 1.000f),          //BLUE

            Tuple.Create(0.000f, 1.000f, 1.000f),          //CYAN
            Tuple.Create(1.000f, 0.000f, 1.000f),          //MAGENTA
            Tuple.Create(1.000f, 1.000f, 0.000f),          //YELLOW

            Tuple.Create(0.980f, 0.666f, 0.235f),          //AMBER
            Tuple.Create(1.000f, 0.647f, 0.000f),          //ORANGE
            Tuple.Create(0.541f, 0.169f, 0.886f),          //VIOLET
            Tuple.Create(0.647f, 0.168f, 0.168f),          //BROWN
            Tuple.Create(0.824f, 0.412f, 0.118f),          //LIGHT_BROWN
            Tuple.Create(0.000f, 0.500f, 0.000f),          //DARK_GREEN
            Tuple.Create(0.157f, 1.000f, 0.157f),          //LIGHT_GREEN
            Tuple.Create(1.000f, 0.216f, 0.216f),          //LIGHT_RED
            Tuple.Create(0.500f, 0.000f, 0.000f),          //DARK_RED
            Tuple.Create(0.000f, 0.545f, 0.545f),          //DARK_CYAN
            Tuple.Create(0.392f, 0.584f, 0.929f),          //SOFT_BLUE
            Tuple.Create(1.000f, 0.078f, 0.576f),          //PINK
            Tuple.Create(1.000f, 0.843f, 0.000f),          //GOLD
        };

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
                case PositionRef.CC:
                    x -= w / 2; y -= h / 2;
                    break;
                case PositionRef.CL:
                    x -= w / 2;
                    break;
                case PositionRef.CU:
                    x -= w / 2; y -= h;
                    break;
                case PositionRef.LC:
                    y -= h / 2;
                    break;
                case PositionRef.LL:
                    break;
                case PositionRef.LU:
                    y -= h;
                    break;
                case PositionRef.RC:
                    x -= w; y -= h / 2;
                    break;
                case PositionRef.RL:
                    x -= w;
                    break;
                case PositionRef.RU:
                    x -= w; y -= h;
                    break;
            }
        }

        private System.Windows.Media.Matrix GetModelViewMatrix()
        {
            // get the model view matrix 
            float[] mat = new float[16];
            gl.GetFloatv(GL.MODELVIEW_MATRIX, mat);

            // use it to convert the mouse position to transformed space
            return new System.Windows.Media.Matrix(mat[0], mat[1], mat[4], mat[5], mat[12], mat[13]);
        }

        private class LightDescription
        {
            internal double LightIntensity = 1;
            internal double[] LightValues = new double[4];
        }
        Stack<LightDescription> LightStack = new Stack<LightDescription>(Enumerable.Repeat(new LightDescription(), 1));

        private void UpdateAmbientColor()
        {
            var ld = LightStack.Peek();
            var light = new[] { (float)(ld.LightValues[0] * ld.LightIntensity), (float)(ld.LightValues[1] * ld.LightIntensity),
                (float)(ld.LightValues[2] * ld.LightIntensity), (float)(ld.LightValues[3] * ld.LightIntensity) };
            gl.LightModelfv(GL.LIGHT_MODEL_AMBIENT, light);
        }
    }
}
