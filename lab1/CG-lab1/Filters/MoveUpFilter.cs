using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class MoveUpFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int resX = Clamp(x, 0, sourceImage.Width - 1);
            int resY = Clamp(y + 100, 0, sourceImage.Height - 1);

            Color resultColor = sourceImage.GetPixel(resX, resY);
            return resultColor;
        }
    }
}
