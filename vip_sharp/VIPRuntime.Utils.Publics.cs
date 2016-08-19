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
        public class VIPSystemClassType
        {
            public double __dDT;
            public bool LeftButtonDown;
            public bool LastLeftButtonDown;
            public double MouseX, MouseY;
        }
        public VIPSystemClassType VIPSystemClass = new VIPSystemClassType();

        public enum BitmapType { RGB, RGBA, HardMask, SoftMask }
        public enum BitmapFilter { Linear, Nearest, MipMap }
        public enum BitmapClamp { Clamp, Repeat }
        public enum BitmapBlend { Blend, Modulate, Decal, Replace }
        public enum PositionRef { CTR, CC = CTR, CU, CL, LL, LC, LU, RU, RL, RC }
        public enum HotSpotTrigger { SelectEdge, Selected, ReleaseEdge, Hover, DoubleClicked }
        public enum HotSpotType { Momentary, Alternate }
        public enum HotSpotHoverBox { Never, Always, Hover }

        public class BitmapRes
        {
            private BitmapType Type;
            private BitmapFilter Filter;
            private BitmapClamp Clamp;
            private string Path;

            public uint TextureID;

            public BitmapRes(BitmapType type, BitmapFilter filter, BitmapClamp clamp, string path)
            {
                Type = type;
                Filter = filter;
                Clamp = clamp;
                Path = path;

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

        public void Scale(double s) => gl.Scaled(s, s, 1);

        public void Translate(double x, double y) => gl.Translated(x, y, 0);

        public void Rotate(double angle) => gl.Rotated(angle, 0, 0, -1);

        public void Color<TColor>(TColor color)
        {
            var colorvals = DoublesFromStructure(color);
            if (colorvals.Count == 3)
                gl.Color3d(colorvals[0], colorvals[1], colorvals[2]);
            else
                gl.Color4d(colorvals[0], colorvals[1], colorvals[2], colorvals[3]);
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
                gl.Vertex2d(vertexvals[0], vertexvals[1]);
            }

            gl.End();
        }

        public void Bitmap(BitmapRes handle, BitmapBlend blend, double x, double y, double w, double h, PositionRef @ref)
        {
            gl.Enable(GL.TEXTURE_2D);
            gl.BindTexture(GL.TEXTURE_2D, handle.TextureID);
            gl.TexEnvi(GL.TEXTURE_ENV, GL.TEXTURE_ENV_MODE,
                blend == BitmapBlend.Modulate ? GL.MODULATE :
                blend == BitmapBlend.Decal ? GL.DECAL :
                blend == BitmapBlend.Blend ? GL.BLEND :
                GL.REPLACE);

            UpdateCoordsWithBoxInfo(ref x, ref y, w, h, @ref);

            gl.Begin(GL.QUADS);

            gl.TexCoord2d(0, 0);
            gl.Vertex2d(x, y);

            gl.TexCoord2d(0, 1);
            gl.Vertex2d(x, y + h);

            gl.TexCoord2d(1, 1);
            gl.Vertex2d(x + w, y + h);

            gl.TexCoord2d(1, 0);
            gl.Vertex2d(x + w, y);

            gl.End();

            gl.Disable(GL.TEXTURE_2D);
        }

        public void Bitmap<TVertex>(BitmapRes handle, BitmapBlend blend, double x, double y, double w, double h, PositionRef @ref, BipolarArray<TVertex> uv)
        {
            gl.Enable(GL.TEXTURE_2D);
            gl.BindTexture(GL.TEXTURE_2D, handle.TextureID);
            gl.TexEnvi(GL.TEXTURE_ENV, GL.TEXTURE_ENV_MODE,
                blend == BitmapBlend.Modulate ? GL.MODULATE :
                blend == BitmapBlend.Decal ? GL.DECAL :
                blend == BitmapBlend.Blend ? GL.BLEND :
                GL.REPLACE);

            UpdateCoordsWithBoxInfo(ref x, ref y, w, h, @ref);

            gl.Begin(GL.QUADS);

            var texvals = DoublesFromStructure(uv[0]);
            gl.TexCoord2d(texvals[0], 1 - texvals[1]);
            gl.Vertex2d(x, y);

            texvals = DoublesFromStructure(uv[1]);
            gl.TexCoord2d(texvals[0], 1 - texvals[1]);
            gl.Vertex2d(x, y + h);

            texvals = DoublesFromStructure(uv[2]);
            gl.TexCoord2d(texvals[0], 1 - texvals[1]);
            gl.Vertex2d(x + w, y + h);

            texvals = DoublesFromStructure(uv[3]);
            gl.TexCoord2d(texvals[0], 1 - texvals[1]);
            gl.Vertex2d(x + w, y);

            gl.End();

            gl.Disable(GL.TEXTURE_2D);
        }

        public void Draw(VIPObject obj)
        {
            gl.PushMatrix();
            gl.Translated(obj.X, obj.Y, 0);
            obj.Run();
            gl.PopMatrix();
        }

        public void Circle(double x, double y, double r, double steps, bool filled)
        {
            if (filled)
            {
                gl.Begin(GL.TRIANGLE_FAN);
                gl.Vertex2d(x, y);
            }
            else
                gl.Begin(GL.LINE_LOOP);

            for (int idx = 0; idx <= steps; ++idx)
                gl.Vertex2d(
                    x + r * Math.Cos(idx * Math.PI * 2 / steps),
                    y + r * Math.Sin(idx * Math.PI * 2 / steps));

            gl.End();
        }

        public void Line(params double[] vals)
        {
            gl.Begin(GL.LINE_STRIP);
            for (int i = 0; i < vals.Length; i += 2)
                gl.Vertex2d(vals[i], vals[i + 1]);
            gl.End();
        }

        public void LineStrip(params double[] vals)
        {
            gl.Begin(GL.LINE_STRIP);
            for (int i = 0; i < vals.Length; i += 2)
                gl.Vertex2d(vals[i], vals[i + 1]);
            gl.End();
        }

        public void Polygon(params double[] vals)
        {
            gl.Begin(GL.POLYGON);
            for (int i = 0; i < vals.Length; i += 2)
                gl.Vertex2d(vals[i], vals[i + 1]);
            gl.End();
        }

        public void ClosedLine(params double[] vals)
        {
            gl.Begin(GL.LINE_LOOP);
            for (int i = 0; i < vals.Length; i += 2)
                gl.Vertex2d(vals[i], vals[i + 1]);
            gl.End();
        }

        public void Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            gl.Begin(GL.LINE_LOOP);
            gl.Vertex2d(x1, y1);
            gl.Vertex2d(x2, y2);
            gl.Vertex2d(x3, y3);
            gl.End();
        }

        public void Quad(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            gl.Begin(GL.LINE_LOOP);
            gl.Vertex2d(x1, y1);
            gl.Vertex2d(x2, y2);
            gl.Vertex2d(x3, y3);
            gl.Vertex2d(x4, y4);
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
                gl.Vertex2d(
                    x + r * Math.Cos((start + idx * inc + 90) * Math.PI * 2 / 360),
                    y + r * Math.Sin((start + idx * inc + 90) * Math.PI * 2 / 360));

            gl.End();
        }

        public void Color(int c) => gl.Color3d(StandardColors[c].Item1, StandardColors[c].Item2, StandardColors[c].Item3);
        public void Color(int c, double a) => gl.Color4d(StandardColors[c].Item1, StandardColors[c].Item2, StandardColors[c].Item3, a);
        public void Color(double r, double g, double b) => gl.Color3d(r / 100, g / 100, b / 100);
        public void Color(double r, double g, double b, double a) => gl.Color4d(r / 100, g / 100, b / 100, a / 100);

        public void MatrixSave() => gl.PushMatrix();
        public void MatrixRestore() => gl.PopMatrix();
        public void MatrixIdentity() => gl.LoadIdentity();

        public void ColorSave() => gl.PushAttrib(GL.CURRENT_BIT);
        public void ColorRestore() => gl.PopAttrib();

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

            gl.PushMatrix();

            gl.Translated(x, y, 0);
            gl.Scaled(scalex, scaley, 1);
            gl.PushMatrix();

            int linecnt = 0;

            foreach (var c in s.Take(cnt))
                if (c == '|')
                {
                    // new line
                    gl.PopMatrix();
                    gl.Translated(0, ++linecnt * -spacey, 0);
                    gl.PushMatrix();
                }
                else
                {
                    gl.CallList(baselist.ListID + c);
                    gl.Translated(spacex, 0, 0);
                }

            gl.PopMatrix();
            gl.PopMatrix();
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
            HotSpotType type, T trueval, T falseval, HotSpotHoverBox hoverbox, BitmapRes bmp = null)
        {
            UpdateCoordsWithBoxInfo(ref x, ref y, w, h, @ref);

            // info needed to store select_edge state
            HotspotInformationType info = null;
            if (trigger == HotSpotTrigger.SelectEdge)
                info = GetHotspotInformation(objid, _this);

            // get the model view matrix 
            float[] mat = new float[16];
            gl.GetFloatv(GL.MODELVIEW_MATRIX, mat);

            // use it to convert the mouse position to transformed space
            var matrix = new System.Windows.Media.Matrix(mat[0], mat[1], mat[4], mat[5], mat[12], mat[13]);
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
                    Bitmap(bmp, BitmapBlend.Replace, x, y, w, h, PositionRef.LL, new BipolarArray<VertexType>(4) { new VertexType(0, 1), new VertexType(0, 0), new VertexType(.5f, 0), new VertexType(.5f, 1) });
                else
                    Bitmap(bmp, BitmapBlend.Replace, x, y, w, h, PositionRef.LL, new BipolarArray<VertexType>(4) { new VertexType(.5f, 1), new VertexType(.5f, 0), new VertexType(1, 0), new VertexType(1, 1) });

            if (hoverbox == HotSpotHoverBox.Always || (hoverbox == HotSpotHoverBox.Hover && hover))
            {
                ColorSave();
                Color(100, 100, 0);
                Quad(x, y, x + w, y, x + w, y + h, x, y + h);
                ColorRestore();
            }
        }
    }
}
