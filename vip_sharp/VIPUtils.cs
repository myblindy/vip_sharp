using OpenGL4NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vip_sharp
{
    public class VIPUtils
    {
        public static VIPUtils Instance => new VIPUtils();
        private VIPUtils() { }

        private static double[] DoublesFromStructure<T>(T o)
        {
            var lst = new List<double>();

            foreach (var field in typeof(T).GetFields(System.Reflection.BindingFlags.DeclaredOnly))
                if (field.FieldType == typeof(double))
                    lst.Add((double)field.GetValue(o));

            return lst.ToArray();
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
                if (colorvals.Length == 3)
                    gl.Color3dv(colorvals);
                else
                    gl.Color4dv(colorvals);

                // vertexes
                var vertexvals = DoublesFromStructure(vertexes[idx]);
                gl.Vertex2dv(vertexvals);
            }

            gl.End();
        }
    }
}
