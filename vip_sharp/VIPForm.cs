using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenGL4NET;
using System.Runtime.InteropServices;

namespace vip_sharp
{
    public partial class VIPForm : Form
    {
        public VIPRuntime.VIPObject LibMainClass;
        bool Initialized = false;
        int Frames = 0;
        DateTime LastFPSCountedAt = DateTime.Now;
        DateTime LastRenderedAt = DateTime.Now;
        bool AutoRender;

        public VIPForm(bool autorender = true)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            InitializeComponent();
            AutoRender = autorender;
            Left = (int)VIPRuntime.Instance.VIPSystemClass.WindowX;
            Top = (int)VIPRuntime.Instance.VIPSystemClass.WindowY;
            ClientSize = new Size((int)VIPRuntime.Instance.VIPSystemClass.WindowWidth, (int)VIPRuntime.Instance.VIPSystemClass.WindowHeight);

            // events
            MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = true; else if (e.Button == MouseButtons.Right) VIPRuntime.Instance.VIPSystemClass.RightButtonDown = true; };
            MouseUp += (s, e) => { if (e.Button == MouseButtons.Left) VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = false; else if (e.Button == MouseButtons.Right) VIPRuntime.Instance.VIPSystemClass.RightButtonDown = false; };
            MouseMove += (s, e) => { VIPRuntime.Instance.VIPSystemClass.MouseX = ToX(e.X); VIPRuntime.Instance.VIPSystemClass.MouseY = ToY(e.Y); };
            MouseWheel += (s, e) => { VIPRuntime.Instance.VIPSystemClass.__fwheel = Math.Sign(e.Delta); };

            // ready
            Initialized = true;
            Application.Idle += Application_Idle;
        }

        public void InitGL()
        {
            gl.Disable(GL.DEPTH_TEST);
            gl.Disable(GL.LIGHTING);
            gl.Enable(GL.BLEND);
            gl.BlendFunc(GL.SRC_ALPHA, GL.ONE_MINUS_SRC_ALPHA);
            gl.ClearColor(0, 0, 0, 0);
            gl.AlphaFunc(GL.GREATER, 0.0f);
            gl.Enable(GL.ALPHA_TEST);
            gl.Enable(GL.LINE_SMOOTH);
            gl.Hint(GL.LINE_SMOOTH_HINT, GL.NICEST);
            gl.ColorMaterial(GL.FRONT, GL.AMBIENT);
        }

        double ToX(int x) => ((double)x) / ClientSize.Width * (VIPRuntime.Instance.VIPSystemClass.ModelMaxX - VIPRuntime.Instance.VIPSystemClass.ModelMinX) + VIPRuntime.Instance.VIPSystemClass.ModelMinX;
        double ToY(int y) => -(((double)y) / ClientSize.Height * (VIPRuntime.Instance.VIPSystemClass.ModelMaxY - VIPRuntime.Instance.VIPSystemClass.ModelMinY) + VIPRuntime.Instance.VIPSystemClass.ModelMinY);

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport("user32.dll")]
        public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);

        bool IsApplicationIdle()
        {
            NativeMessage result;
            return PeekMessage(out result, IntPtr.Zero, 0, 0, 0) == 0;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            if (AutoRender)
                while (IsApplicationIdle())
                    Render();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!Initialized) return;

            gl.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
            gl.MatrixMode(GL.PROJECTION);
            gl.LoadIdentity();
            gl.Ortho(VIPRuntime.Instance.VIPSystemClass.ModelMinX, VIPRuntime.Instance.VIPSystemClass.ModelMaxX,
                VIPRuntime.Instance.VIPSystemClass.ModelMinY, VIPRuntime.Instance.VIPSystemClass.ModelMaxY,
                -10, 10);
        }

        protected void Render()
        {
            gl.Clear(GL.COLOR_BUFFER_BIT);
            gl.MatrixMode(GL.MODELVIEW);
            gl.LoadIdentity();

            var now = DateTime.Now;
            VIPRuntime.Instance.VIPSystemClass.__ddt = (now - LastRenderedAt).TotalSeconds;
            LibMainClass.Run();
            VIPRuntime.Instance.VIPSystemClass.__fwheel = 0;
            LastRenderedAt = now;

            VIPRuntime.rc.SwapBuffers();

            ++Frames;
        }

        private void VIPForm_Load(object sender, EventArgs e) => OnSizeChanged(EventArgs.Empty);

        private void UIUpdate_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            Text = "VIP - " + Math.Round(Frames / (now - LastFPSCountedAt).TotalSeconds).ToString("0") + " fps";
            LastFPSCountedAt = now;
            Frames = 0;
        }
    }
}
