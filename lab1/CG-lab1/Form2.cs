using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_lab1
{
    public partial class Form2 : Form
    {
        public float[,] mask;
        public Form2()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            mask = new float[3, 3]{
                {float.Parse(textBox1.Text), float.Parse(textBox4.Text), float.Parse(textBox5.Text)},
                {float.Parse(textBox2.Text), float.Parse(textBox6.Text), float.Parse(textBox9.Text)},
                {float.Parse(textBox3.Text), float.Parse(textBox7.Text), float.Parse(textBox8.Text)}};
            this.Close();
        }
    }
}
