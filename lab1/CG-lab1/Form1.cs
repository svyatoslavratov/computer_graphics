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
    public partial class Form1 : Form
    {
        Bitmap image;
        Stack<Image> imageHistory = new Stack<Image>();

        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageHistory.Clear();
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                imageHistory.Push(pictureBox1.Image);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void фильтраГауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void оттенкиСерогоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BrightnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new EmbossingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void вращениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new RotationFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }


        private void внизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MoveDownFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void вправоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MoveRightFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void влевоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MoveLeftFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void вверхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MoveUpFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void горизонтальныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new FirstWavingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void вертикальныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SecondWavingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void эффектстеклаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void слабоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сильноеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MotionBlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сильнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SecondSharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void слабаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void операторЩарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharrOperatorFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void операторПриюттаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new PrewittOperatorFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Image is download");
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPG(*.JPG)|*.jpg";
            dialog.FileName = "Image";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(dialog.FileName);
            }
        }

        private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imageHistory.Count == 0)
                MessageBox.Show("Changing history is empty");
            else
            {
                pictureBox1.Image = imageHistory.Pop();
                image = (Bitmap)pictureBox1.Image;
                pictureBox1.Refresh();
            }
            
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayWorldFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void линейнаяКоррекцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new HistogramLinearStretchFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        float[,] structElem = new float[3, 3]{
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}};
        private void расширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Dilation(structElem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сужениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Erosion(structElem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void открытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Opening(structElem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void закрытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Closing(structElem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void медианныйФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void задатьСтруктурныйЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            structElem = form2.mask;
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new TopHat(structElem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void blackHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlackHat(structElem);
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void gradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Grad(structElem);
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
