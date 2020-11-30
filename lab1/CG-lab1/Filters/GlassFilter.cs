using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class GlassFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Random rand = new Random();

            int resX = (int)(x + (rand.NextDouble() - 0.5) * 10);
            int resY = (int)(y + (rand.NextDouble() - 0.5) * 10);

            resX = Clamp(resX, 0, sourceImage.Width - 1);
            resY = Clamp(resY, 0, sourceImage.Height - 1);

            Color resultColor = sourceImage.GetPixel(resX, resY);
            return resultColor;
        }
    }
}
