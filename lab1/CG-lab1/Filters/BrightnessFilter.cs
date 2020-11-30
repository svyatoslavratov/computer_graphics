using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class BrightnessFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int K = 10;

            Color resultColor = Color.FromArgb(
                Clamp(sourceColor.R + K, 0, 255),
                Clamp(sourceColor.G + K, 0, 255),
                Clamp(sourceColor.B + K, 0, 255));
            return resultColor;
        }
    }
}
