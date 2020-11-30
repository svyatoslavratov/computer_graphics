using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace CG_lab1
{
    class TopHat : Filters
    {
        protected float[,] mask;

        public TopHat(float[,] Mask)
        {
            mask = Mask;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return sourceImage.GetPixel(x, y);
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            float resultR;
            float resultG;
            float resultB;
            Filters filter = new Erosion(mask);
            Bitmap result = filter.processImage(sourceImage, worker);
            for(int i = 0; i  < sourceImage.Width; i++)
                for(int j = 0; j < sourceImage.Height; j++)
                {
                    resultR = sourceImage.GetPixel(i, j).R - result.GetPixel(i, j).R;
                    resultG = sourceImage.GetPixel(i, j).G - result.GetPixel(i, j).G;
                    resultB = sourceImage.GetPixel(i, j).B - result.GetPixel(i, j).B;
                    result.SetPixel(i, j, Color.FromArgb(
                        Clamp((int)resultR, 0, 255),
                        Clamp((int)resultG, 0, 255),
                        Clamp((int)resultB, 0, 255)));
                }
            return result;
        }
    }
}
