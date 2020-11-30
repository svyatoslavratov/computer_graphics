using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Windows.Forms;

namespace RayTracing
{
    public partial class Form1 : Form
    {
        View view;
        bool loaded = false;

        public Form1()
        {
            InitializeComponent();
            view = new View();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            view.Setup(glControl1.Width, glControl1.Height);
            view.InitShaders();
            view.DrawQuad();
            int MatID1 = GL.GetUniformLocation(view.BasicProgramID, "MaterialId"); 
            GL.Uniform1(MatID1, trackBar1.Value);
            int MatID2 = GL.GetUniformLocation(view.BasicProgramID, "RayTracingDepth"); 
            GL.Uniform1(MatID2, trackBar2.Value);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (loaded)
            {
                view.ReDraw();
                glControl1.SwapBuffers();
                GL.UseProgram(0);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            view.DrawQuad();
            int MatID = GL.GetUniformLocation(view.BasicProgramID, "MaterialId");
            GL.Uniform1(MatID, trackBar1.Value);
            view.ReDraw();
            glControl1.SwapBuffers();
            GL.UseProgram(0);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            view.DrawQuad();
            int MatID2 = GL.GetUniformLocation(view.BasicProgramID, "RayTracingDepth");
            GL.Uniform1(MatID2, trackBar2.Value);
            view.ReDraw();
            glControl1.SwapBuffers();
            GL.UseProgram(0);
        }
    }
}
