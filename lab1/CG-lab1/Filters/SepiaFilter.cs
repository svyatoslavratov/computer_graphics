using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            int intensity = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            int K = 15; 

            Color resultColor = Color.FromArgb(
                Clamp(intensity + 2 * K, 0, 255),
                Clamp((int)(intensity + 0.5 * K), 0, 255),
                Clamp(intensity - K, 0, 255));
            return resultColor;
        }
    }
}
