﻿using System;
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
        public dynamic LibMainClass;
        bool Initialized = false;
        int Frames = 0;
        DateTime LastFPSCountedAt = DateTime.Now;
        DateTime LastRenderedAt = DateTime.Now;
        bool AutoRender;

        const double MinX = -15, MaxX = 15, MinY = -15, MaxY = 15;

        public VIPForm(bool autorender = true)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            InitializeComponent();
            AutoRender = autorender;

            // events
            MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = true; };
            MouseUp += (s, e) => { if (e.Button == MouseButtons.Left) VIPRuntime.Instance.VIPSystemClass.LeftButtonDown = false; };
            MouseMove += (s, e) => { VIPRuntime.Instance.VIPSystemClass.MouseX = ToX(e.X); VIPRuntime.Instance.VIPSystemClass.MouseY = ToY(e.Y); };

            // set up the rc
            gl.DepthMask(false);
            gl.Disable(GL.LIGHTING);
            wgl.SwapInterval(0);

            // ready
            Initialized = true;
            Application.Idle += Application_Idle;
        }

        double ToX(int x) => ((double)x) / ClientSize.Width * (MaxX - MinX) + MinX;
        double ToY(int y) => -(((double)y) / ClientSize.Height * (MaxY - MinY) + MinY);

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
            gl.Ortho(MinX, MaxX, MinY, MaxY, -10, 10);
        }

        protected void Render()
        {
            gl.Clear(GL.COLOR_BUFFER_BIT);
            gl.MatrixMode(GL.MODELVIEW);
            gl.LoadIdentity();

            var now = DateTime.Now;
            VIPRuntime.Instance.VIPSystemClass.__dDT = (now - LastRenderedAt).TotalSeconds;
            LibMainClass.Run();
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
