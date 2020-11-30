using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class SecondWavingFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int resX = (int)(x + 20 * Math.Sin((2 * Math.PI * x) / 30));
            int resY = y;

            resX = Clamp(resX, 0, sourceImage.Width - 1);
            resY = Clamp(resY, 0, sourceImage.Height - 1);

            Color resultColor = sourceImage.GetPixel(resX, resY);
            return resultColor;
        }
    }
}
