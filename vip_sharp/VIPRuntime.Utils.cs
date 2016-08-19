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
    public partial class VIPRuntime
    {
        public static VIPRuntime Instance { get; } = new VIPRuntime();
        private VIPRuntime() { }

        internal static RenderingContext rc;
        internal static void RunGL(string libpath)
        {
            if (!Path.IsPathRooted(libpath))
                libpath = Path.Combine(Directory.GetCurrentDirectory(), libpath);

            var frm = new VIPForm();
            rc = RenderingContext.CreateContext(frm);

            var libassembly = AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(libpath));
            dynamic libmainclass = Activator.CreateInstance(libassembly.GetType("MainClass"));
            frm.LibMainClass = libmainclass;

            Application.Run(frm);
        }

        public abstract class VIPObject
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double s { get; set; }
            public abstract void Run();
        }

        private Tuple<double, double, double>[] StandardColors = new[]
        {
            Tuple.Create(0.000, 0.000, 0.000),          //BLACK
            Tuple.Create(0.250, 0.250, 0.250),          //DARK_GREY
            Tuple.Create(0.500, 0.500, 0.500),          //GREY
            Tuple.Create(0.750, 0.750, 0.750),          //LIGHT_GREY
            Tuple.Create(1.000, 1.000, 1.000),          //WHITE

            Tuple.Create(1.000, 0.000, 0.000),          //RED
            Tuple.Create(0.000, 1.000, 0.000),          //GREEN
            Tuple.Create(0.000, 0.000, 1.000),          //BLUE

            Tuple.Create(0.000, 1.000, 1.000),          //CYAN
            Tuple.Create(1.000, 0.000, 1.000),          //MAGENTA
            Tuple.Create(1.000, 1.000, 0.000),          //YELLOW

            Tuple.Create(0.980, 0.666, 0.235),          //AMBER
            Tuple.Create(1.000, 0.647, 0.000),          //ORANGE
            Tuple.Create(0.541, 0.169, 0.886),          //VIOLET
            Tuple.Create(0.647, 0.168, 0.168),          //BROWN
            Tuple.Create(0.824, 0.412, 0.118),          //LIGHT_BROWN
            Tuple.Create(0.000, 0.500, 0.000),          //DARK_GREEN
            Tuple.Create(0.157, 1.000, 0.157),          //LIGHT_GREEN
            Tuple.Create(1.000, 0.216, 0.216),          //LIGHT_RED
            Tuple.Create(0.500, 0.000, 0.000),          //DARK_RED
            Tuple.Create(0.000, 0.545, 0.545),          //DARK_CYAN
            Tuple.Create(0.392, 0.584, 0.929),          //SOFT_BLUE
            Tuple.Create(1.000, 0.078, 0.576),          //PINK
            Tuple.Create(1.000, 0.843, 0.000),          //GOLD
        };

        private static IList<double> DoublesFromStructure<T>(T o)
        {
            var lst = new List<double>();

            foreach (var field in typeof(T).GetFields())
                if (field.FieldType == typeof(double))
                    lst.Add((double)field.GetValue(o));

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
    }
}
