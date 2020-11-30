using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace CG_lab1
{
    class Closing : Filters
    {
        protected float[,] mask;

        public Closing(float[,] Mask)
        {
            mask = Mask;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return sourceImage.GetPixel(x, y);
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Filters filter1 = new Dilation(mask);
            Bitmap result = filter1.processImage(sourceImage, worker);
            Filters filter2 = new Erosion(mask);
            result = filter2.processImage(result, worker);
            return result;
        }
    }
}
