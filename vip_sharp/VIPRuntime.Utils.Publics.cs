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
using System.Drawing.Imaging;

namespace vip_sharp
{
    public partial class VIPRuntime
    {
        public class VIPSystemClassType
        {
            public double __dDT { get; set; }
            public double __fWheel { get; set; }
            public double __fCursor_XPos { get { return MouseX; } set { MouseX = value; } }
            public double __fCursor_YPos { get { return MouseY; } set { MouseY = value; } }

            public bool LeftButtonDown;
            public bool LastLeftButtonDown;
            public double MouseX, MouseY;
            public double ModelMinX = -15, ModelMaxX = 15, ModelMinY = -15, ModelMaxY = 15;
            public double WindowWidth = 400, WindowHeight = 400, WindowX = 200, WindowY = 200;
        }
        public VIPSystemClassType VIPSystemClass = new VIPSystemClassType();

        public enum BitmapType { RGB, RGBA, HardMask, SoftMask }
        public enum BitmapFilter { Linear, Nearest, MipMap }
        public enum BitmapClamp { Clamp, Repeat }
        public enum BitmapBlend { Blend, Modulate, Decal, Replace }
        public enum PositionRef { CTR, CC = CTR, CU, CL, LL, LC, LU, RU, RL, RC }
        public enum HotSpotTrigger { SelectEdge, Selected, ReleaseEdge, Hover, DoubleClicked }
        public enum HotSpotType { Momentary, Alternate }
        public enum HoverBox { Never, Always, Hover }

        public class BitmapRes
        {
            public uint TextureID;

            public BitmapRes(BitmapType type, BitmapFilter filter, BitmapClamp clamp, string path)
            {
                TextureID = LoadBitmap(type, filter, clamp, path);
            }
        }

        public class StringRes
        {
            public DisplayList BaseList;
            public double ScaleX;
            public double ScaleY;
            public double SpaceX;
            public double SpaceY;

            public StringRes(DisplayList baselist, double scalex, double scaley, double spacex, double spacey = 1.5)
            {
                BaseList = baselist; ScaleX = scalex; ScaleY = scaley; SpaceX = spacex; SpaceY = spacey;
            }
        }

        public class DisplayList
        {
            public uint ListID;

            public DisplayList(Action init)
            {
                ListID = gl.GenLists(1);
                gl.NewList(ListID, GL.COMPILE);
                init();
                gl.EndList();
            }
        }

        public void Scale(double s) => Scale(s, s);
        public void Scale(double x, double y) => gl.Scalef((float)x, (float)y, 1);

        public void Translate(double x, double y) => gl.Translatef((float)x, (float)y, 0);

        public void Rotate(double angle) => gl.Rotatef((float)angle, 0, 0, -1);

        public void Color<TColor>(TColor color)
        {
            var colorvals = DoublesFromStructure(color);
            if (colorvals.Count == 3)
                gl.Color3f((float)colorvals[0], (float)colorvals[1], (float)colorvals[2]);
            else
                gl.Color4f((float)colorvals[0], (float)colorvals[1], (float)colorvals[2], (float)colorvals[3]);
        }

        public void Polygon<TVertex, TColor>(BipolarArray<TVertex> vertexes, BipolarArray<TColor> colors)
        {
            var cnt = vertexes.N1;
            gl.Begin(GL.POLYGON);

            for (int idx = 0; idx < cnt; ++idx)
            {
                // colors
                Color(colors[idx]);

                // vertexes
                var vertexvals = DoublesFromStructure(vertexes[idx]);
                gl.Vertex2f((float)vertexvals[0], (float)vertexvals[1]);
            }

            gl.End();
        }

        public void Bitmap(uint texid, BitmapBlend blend, double x, double y, double w, double h, PositionRef @ref)
        {
            gl.Enable(GL.TEXTURE_2D);
            gl.BindTexture(GL.TEXTURE_2D, texid);
            gl.TexEnvi(GL.TEXTURE_ENV, GL.TEXTURE_ENV_MODE,
                blend == BitmapBlend.Modulate ? GL.MODULATE :
                blend == BitmapBlend.Decal ? GL.DECAL :
                blend == BitmapBlend.Blend ? GL.BLEND :
                GL.REPLACE);

            UpdateCoordsWithBoxInfo(ref x, ref y, w, h, @ref);

            gl.Begin(GL.QUADS);

            gl.TexCoord2f(0, 0);
            gl.Vertex2f((float)x, (float)y);

            gl.TexCoord2f(0, 1);
            gl.Vertex2f((float)x, (float)(y + h));

            gl.TexCoord2f(1, 1);
            gl.Vertex2f((float)(x + w), (float)(y + h));

            gl.TexCoord2f(1, 0);
            gl.Vertex2f((float)(x + w), (float)y);

            gl.End();

            gl.Disable(GL.TEXTURE_2D);
        }

        public void Bitmap(BitmapRes res, BitmapBlend blend, double x, double y, double w, double h, PositionRef @ref) =>
            Bitmap(res.TextureID, blend, x, y, w, h, @ref);
        public void Bitmap(BitmapType type, BitmapFilter filter, BitmapClamp clamp, string path, BitmapBlend blend, double x, double y, double w, double h, PositionRef @ref) =>
            Bitmap(LoadBitmap(type, filter, clamp, path), blend, x, y, w, h, @ref);

        public void Bitmap<TVertex>(uint texid, BitmapBlend blend, double x, double y, double w, double h, PositionRef @ref, BipolarArray<TVertex> uv)
        {
            gl.Enable(GL.TEXTURE_2D);
            gl.BindTexture(GL.TEXTURE_2D, texid);
            gl.TexEnvi(GL.TEXTURE_ENV, GL.TEXTURE_ENV_MODE,
                blend == BitmapBlend.Modulate ? GL.MODULATE :
                blend == BitmapBlend.Decal ? GL.DECAL :
                blend == BitmapBlend.Blend ? GL.BLEND :
                GL.REPLACE);

            UpdateCoordsWithBoxInfo(ref x, ref y, w, h, @ref);

            gl.Begin(GL.QUADS);

            var texvals = DoublesFromStructure(uv[0]);
            gl.TexCoord2f((float)texvals[0], (float)(1 - texvals[1]));
            gl.Vertex2f((float)x, (float)y);

            texvals = DoublesFromStructure(uv[1]);
            gl.TexCoord2f((float)texvals[0], (float)(1 - texvals[1]));
            gl.Vertex2f((float)x, (float)(y + h));

            texvals = DoublesFromStructure(uv[2]);
            gl.TexCoord2f((float)texvals[0], (float)(1 - texvals[1]));
            gl.Vertex2f((float)(x + w), (float)(y + h));

            texvals = DoublesFromStructure(uv[3]);
            gl.TexCoord2f((float)texvals[0], (float)(1 - texvals[1]));
            gl.Vertex2f((float)(x + w), (float)y);

            gl.End();

            gl.Disable(GL.TEXTURE_2D);
        }

        public void Bitmap<TVertex>(BitmapRes res, BitmapBlend blend, double x, double y, double w, double h, PositionRef @ref, BipolarArray<TVertex> uv) =>
            Bitmap(res.TextureID, blend, x, y, w, h, @ref, uv);
        public void Bitmap<TVertex>(BitmapType type, BitmapFilter filter, BitmapClamp clamp, string path, BitmapBlend blend, double x, double y, double w, double h, PositionRef @ref, BipolarArray<TVertex> uv) =>
            Bitmap(LoadBitmap(type, filter, clamp, path), blend, x, y, w, h, @ref, uv);

        public void Draw(VIPObject obj)
        {
            MatrixSave();
            if (obj.X != 0 || obj.Y != 0) Translate(obj.X, obj.Y);
            if (obj.R != 0) Rotate(obj.R);
            if (obj.S != 1) Scale(obj.S);
            obj.Run();
            MatrixRestore();
        }

        public void Circle(double x, double y, double r, double steps, bool filled)
        {
            if (filled)
            {
                gl.Begin(GL.TRIANGLE_FAN);
                gl.Vertex2f((float)x, (float)y);
            }
            else
                gl.Begin(GL.LINE_LOOP);

            for (int idx = 0; idx <= steps; ++idx)
                gl.Vertex2f(
                    (float)(x + r * Math.Cos(idx * Math.PI * 2 / steps)),
                    (float)(y + r * Math.Sin(idx * Math.PI * 2 / steps)));

            gl.End();
        }

        public void Line(params double[] vals)
        {
            gl.Begin(GL.LINE_STRIP);
            for (int i = 0; i < vals.Length; i += 2)
                gl.Vertex2f((float)vals[i], (float)vals[i + 1]);
            gl.End();
        }

        public void LineStrip(params double[] vals)
        {
            gl.Begin(GL.LINE_STRIP);
            for (int i = 0; i < vals.Length; i += 2)
                gl.Vertex2f((float)vals[i], (float)vals[i + 1]);
            gl.End();
        }

        public void Polygon(params double[] vals)
        {
            gl.Begin(GL.POLYGON);
            for (int i = 0; i < vals.Length; i += 2)
                gl.Vertex2f((float)vals[i], (float)vals[i + 1]);
            gl.End();
        }

        public void ClosedLine(params double[] vals)
        {
            gl.Begin(GL.LINE_LOOP);
            for (int i = 0; i < vals.Length; i += 2)
                gl.Vertex2f((float)vals[i], (float)vals[i + 1]);
            gl.End();
        }

        public void Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            gl.Begin(GL.LINE_LOOP);
            gl.Vertex2f((float)x1, (float)y1);
            gl.Vertex2f((float)x2, (float)y2);
            gl.Vertex2f((float)x3, (float)y3);
            gl.End();
        }

        public void Quad(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            gl.Begin(GL.QUADS);
            gl.Vertex2f((float)x1, (float)y1);
            gl.Vertex2f((float)x2, (float)y2);
            gl.Vertex2f((float)x3, (float)y3);
            gl.Vertex2f((float)x4, (float)y4);
            gl.End();
        }

        public void LineWidth(double width)
        {
            gl.LineWidth((float)width);
        }

        public void ArcLine(double x, double y, double r, double start, double end, double steps)
        {
            gl.Begin(GL.LINE_STRIP);

            var inc = (end - start) / steps;
            for (int idx = 0; idx <= steps; ++idx)
                gl.Vertex2f(
                    (float)(x + r * Math.Cos((start + idx * inc + 90) * Math.PI * 2 / 360)),
                    (float)(y + r * Math.Sin((start + idx * inc + 90) * Math.PI * 2 / 360)));

            gl.End();
        }

        public void Color(int c) => gl.Color3f(StandardColors[c].Item1, StandardColors[c].Item2, StandardColors[c].Item3);
        public void Color(int c, double a) => gl.Color4f(StandardColors[c].Item1, StandardColors[c].Item2, StandardColors[c].Item3, (float)(a / 100));
        public void Color(double r, double g, double b) => gl.Color3f((float)(r / 100), (float)(g / 100), (float)(b / 100));
        public void Color(double r, double g, double b, double a) => gl.Color4f((float)(r / 100), (float)(g / 100), (float)(b / 100), (float)(a / 100));

        public void LightColor(int c)
        {
            var ld = LightStack.Peek();
            ld.LightValues[0] = StandardColors[c].Item1;
            ld.LightValues[1] = StandardColors[c].Item2;
            ld.LightValues[2] = StandardColors[c].Item3;
            ld.LightValues[3] = 1;
            UpdateAmbientColor();
        }
        public void LightColor(int c, double a)
        {
            var ld = LightStack.Peek();
            ld.LightValues[0] = StandardColors[c].Item1;
            ld.LightValues[1] = StandardColors[c].Item2;
            ld.LightValues[2] = StandardColors[c].Item3;
            ld.LightValues[3] = a;
            UpdateAmbientColor();
        }
        public void LightColor(double r, double g, double b)
        {
            var ld = LightStack.Peek();
            ld.LightValues[0] = r / 100;
            ld.LightValues[1] = g / 100;
            ld.LightValues[2] = b / 100;
            ld.LightValues[3] = 1;
            UpdateAmbientColor();
        }
        public void LightColor(double r, double g, double b, double a)
        {
            var ld = LightStack.Peek();
            ld.LightValues[0] = r / 100;
            ld.LightValues[1] = g / 100;
            ld.LightValues[2] = b / 100;
            ld.LightValues[3] = a / 100;
            UpdateAmbientColor();
        }
        public void Light(double intensity)
        {
            var ld = LightStack.Peek();
            ld.LightIntensity = intensity;
            UpdateAmbientColor();
        }

        public void MatrixSave() => gl.PushMatrix();
        public void MatrixRestore() => gl.PopMatrix();
        public void MatrixIdentity() => gl.LoadIdentity();

        public void ColorSave() => gl.PushAttrib(GL.CURRENT_BIT);
        public void ColorRestore() => gl.PopAttrib();

        public void LightSave()
        {
            LightStack.Push(new LightDescription());
            UpdateAmbientColor();
        }
        public void LightRestore()
        {
            LightStack.Pop();
            UpdateAmbientColor();
        }

        public void LightOn()
        {
            gl.Enable(GL.LIGHTING);
            gl.Enable(GL.COLOR_MATERIAL);
        }
        public void LightOff()
        {
            gl.Disable(GL.LIGHTING);
            gl.Disable(GL.COLOR_MATERIAL);
        }

        public void DrawString(double x, double y, PositionRef @ref, IEnumerable<char> s, int cnt, StringRes res) =>
            DrawString(x, y, @ref, s, cnt, res.BaseList, res.ScaleX, res.ScaleY, res.SpaceX, res.SpaceY);
        public void DrawString(double x, double y, PositionRef @ref, IEnumerable<char> s, int cnt, DisplayList baselist, double scalex, double scaley, double spacex, double spacey = 1.5)
        {
            if (cnt == 0)
                cnt = s.TakeWhile(c => c != '\0').Count();

            // figure out the bounding box
            double h = 1, w = 0, maxw = 0;
            foreach (var c in s.Take(cnt))
                if (c == '|')
                {
                    ++h;
                    if (maxw < w) maxw = w;
                    w = 0;
                }
                else
                    ++w;
            if (maxw < w) maxw = w;

            // and update the x and y coords based on the box and ref
            UpdateCoordsWithBoxInfo(ref x, ref y, maxw * spacex * scalex, h * spacey * scaley, @ref);

            MatrixSave();

            Translate(x, y);
            Scale(scalex, scaley);
            MatrixSave();

            int linecnt = 0;

            foreach (var c in s.Take(cnt))
                if (c == '|')
                {
                    // new line
                    MatrixSave();
                    Translate(0, ++linecnt * -spacey);
                    MatrixRestore();
                }
                else
                {
                    gl.CallList(baselist.ListID + c);
                    Translate(spacex, 0);
                }

            MatrixRestore();
            MatrixRestore();
        }

        /// <summary>
        /// Represents a VIP hotspot. 
        /// </summary>
        /// <remarks>
        /// Triggers: 
        ///  - Selected means it triggers as long as the mouse is held down inside the hotspot
        ///  - SelectEdge means it triggers once when held down. Moving the mouse outside and back in re-triggers it.
        /// </remarks>
        public void HotSpot<T>(uint objid, object _this, double x, double y, double w, double h, PositionRef @ref, ref T var, HotSpotTrigger trigger,
            HotSpotType type, T trueval, T falseval, HoverBox hoverbox, BitmapRes bmp = null)
        {
            UpdateCoordsWithBoxInfo(ref x, ref y, w, h, @ref);

            // info needed to store select_edge state
            ObjectInformationType info = null;
            if (trigger == HotSpotTrigger.SelectEdge)
                info = GetObjectInformation(objid, _this);

            // get the model view matrix and use it to convert the mouse position to transformed space
            var matrix = GetModelViewMatrix();
            matrix.Invert();
            var pt = matrix.Transform(new System.Windows.Vector(VIPSystemClass.MouseX, VIPSystemClass.MouseY));
            pt.X += matrix.OffsetX; pt.Y += matrix.OffsetY;

            var hover = pt.X >= x && pt.X <= x + w && pt.Y >= y && pt.Y <= y + h;
            var sel = VIPSystemClass.LeftButtonDown && hover;
            if (trigger == HotSpotTrigger.SelectEdge)
            {
                // handle re-entering the hover area to allow re-triggering 
                if (hover && !info.LastHover)
                {
                    info.LastHover = true;
                    info.LastPressed = false;
                }
                else if (!hover && info.LastHover)
                    info.LastHover = false;

                // trigger only once per mouse down
                if (!info.LastPressed && sel)
                    info.LastPressed = true;
                else if (info.LastPressed && sel)
                    sel = false;
                else if (!VIPSystemClass.LeftButtonDown)
                    info.LastPressed = false;
            }
            var = sel ? trueval : falseval;

            if (bmp != null)
                if (sel)
                    Bitmap(bmp, BitmapBlend.Replace, x, y, w, h, PositionRef.LL,
                        new BipolarArray<VertexType>(4) { new VertexType(0, 1), new VertexType(0, 0), new VertexType(.5f, 0), new VertexType(.5f, 1) });
                else
                    Bitmap(bmp, BitmapBlend.Replace, x, y, w, h, PositionRef.LL,
                        new BipolarArray<VertexType>(4) { new VertexType(.5f, 1), new VertexType(.5f, 0), new VertexType(1, 0), new VertexType(1, 1) });

            if (hoverbox == HoverBox.Always || (hoverbox == HoverBox.Hover && hover))
            {
                ColorSave();
                Color(100, 100, 0);
                ClosedLine(x, y, x + w, y, x + w, y + h, x, y + h);
                ColorRestore();
            }
        }

        public void RotaryKnob<T>(uint objid, object _this, double x, double y, double r, ref T var,
            double anglemin, double anglemax, double valuemin, double valuemax,
            HoverBox hoverbox, double wheeldelta, DisplayList list = null)
        {
            Func<double, double> normangle = a =>
              {
                  while (a < 0) a += 360;
                  while (a >= 360) a -= 360;
                  return a;
              };

            var info = GetObjectInformation(objid, _this);

            // get the model view matrix and use it to convert the mouse position to transformed space
            var matrix = GetModelViewMatrix();
            matrix.Invert();
            var pt = matrix.Transform(new System.Windows.Vector(VIPSystemClass.MouseX, VIPSystemClass.MouseY));
            pt.X += matrix.OffsetX; pt.Y += matrix.OffsetY;

            anglemin = normangle(anglemin);
            anglemax = normangle(anglemax);
            var revangle = anglemin > anglemax;
            if (revangle)
                anglemax += 360;

            var hover = (pt.X - x) * (pt.X - x) + (pt.Y - y) * (pt.Y - y) <= r * r;
            if (hover && VIPSystemClass.LeftButtonDown)
                info.LastPressed = true;
            if (info.LastPressed && VIPSystemClass.LeftButtonDown)
            {
                var angle = normangle(Math.Atan2(pt.X - x, pt.Y - y) / 2 / Math.PI * 360);
                if (!double.IsNaN(info.LastAngle))
                {
                    var delta = angle - info.LastAngle;
                    if (delta > 180) delta -= 360; else if (delta < -180) delta += 360;
                    var newvar = Convert.ToDouble(var) + delta / (anglemax - anglemin) * (valuemax - valuemin);
                    if (newvar < valuemin) newvar = valuemin; else if (newvar > valuemax) newvar = valuemax;
                    var = (T)Convert.ChangeType(newvar, typeof(T));
                }
                info.LastAngle = angle;
            }
            else if (!VIPSystemClass.LeftButtonDown)
            {
                info.LastAngle = double.NaN;
                info.LastPressed = false;
            }

            if (list != null)
            {
                MatrixSave();
                Translate(x, y);
                Rotate(180 + (Math.Max(Convert.ToDouble(var), valuemin) - valuemin) / (valuemax - valuemin) * (anglemax - anglemin) + anglemin);
                gl.CallList(list.ListID);
                MatrixRestore();
            }

            if (hoverbox == HoverBox.Always || (hoverbox == HoverBox.Hover && hover))
            {
                ColorSave();
                Color(100, 100, 0);
                Circle(x, y, r, 12, false);
                ColorRestore();
            }
        }

        public void Slider<T>(uint objid, object _this, double x, double y, double w, double h,
            PositionRef @ref, double angle, ref T var, double valuemin, double valuemax,
            HoverBox hoverbox, double wheeldelta, DisplayList list = null)
        {
            UpdateCoordsWithBoxInfo(ref x, ref y, w, h, @ref);

            // info needed to store select_edge state
            ObjectInformationType info = GetObjectInformation(objid, _this);

            // use the angle to rotate the actual control
            MatrixSave();
            Translate(x, y);
            Rotate(angle);
            Translate(-x, -y);

            // get the model view matrix and use it to convert the mouse position to transformed space
            var matrix = GetModelViewMatrix();
            matrix.Invert();
            var pt = matrix.Transform(new System.Windows.Vector(VIPSystemClass.MouseX, VIPSystemClass.MouseY));
            pt.X += matrix.OffsetX; pt.Y += matrix.OffsetY;

            var hover = pt.X >= x && pt.X <= x + w && pt.Y >= y && pt.Y <= y + h;

            if (hover && VIPSystemClass.LeftButtonDown && !info.LastPressed)
                info.LastPressed = true;
            if (!VIPSystemClass.LeftButtonDown)
                info.LastPressed = false;
            else if (info.LastPressed)
            {
                var val = pt.Y - y;
                if (val < 0) val = 0; else if (val > h) val = h;
                var = (T)Convert.ChangeType(val / h * (valuemax - valuemin) + valuemin, typeof(T));
            }

            if (list != null)
            {
                MatrixSave();
                Translate(x + w / 2, y + (Convert.ToDouble(var) - valuemin) / (valuemax - valuemin) * h);
                gl.CallList(list.ListID);
                MatrixRestore();
            }

            if (hoverbox == HoverBox.Always || (hoverbox == HoverBox.Hover && hover))
            {
                ColorSave();
                Color(100, 100, 0);
                ClosedLine(x, y, x + w, y, x + w, y + h, x, y + h);
                ColorRestore();
            }

            // restore the angle rotation
            MatrixRestore();
        }
    }
}
