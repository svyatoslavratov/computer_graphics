using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class RotationFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int centerX = sourceImage.Width / 2;
            int centerY = sourceImage.Height / 2;

            int resX = (int)((x - centerX) * 0 - (y - centerY) * 1 + centerX);
            int resY = (int)((x - centerX) * 1 + (y - centerY) * 0 + centerY);

            resX = Clamp(resX, 0, sourceImage.Width - 1);
            resY = Clamp(resY, 0, sourceImage.Height - 1);

            Color resultColor = sourceImage.GetPixel(resX, resY);
            return resultColor;
        }
    }
}
