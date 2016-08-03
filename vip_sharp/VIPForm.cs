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

namespace vip_sharp
{
    public partial class VIPForm : Form
    {
        dynamic LibMainClass;
        bool Initialized = false;

        public VIPForm(dynamic libmainclass)
        {
            LibMainClass = libmainclass;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            InitializeComponent();

            // set up the rc
            gl.DepthMask(false);

            // ready
            Initialized = true;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!Initialized) return;

            gl.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
            gl.MatrixMode(GL.PROJECTION);
            gl.LoadIdentity();
            gl.Ortho(-10, 10, -10, 10, -10, 10);
        }

        protected void Render()
        {
            gl.Clear(GL.COLOR_BUFFER_BIT);
            gl.MatrixMode(GL.MODELVIEW);
            gl.LoadIdentity();

            LibMainClass.Run();

            VIPUtils.rc.SwapBuffers();
        }

        private void VIPForm_Load(object sender, EventArgs e) => OnSizeChanged(EventArgs.Empty);

        private void RenderTimer_Tick(object sender, EventArgs e) => Render();
    }
}
