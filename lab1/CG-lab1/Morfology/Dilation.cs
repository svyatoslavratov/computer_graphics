using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class Dilation : Filters
    {
        protected float[,] mask;

        public Dilation(float[,] Mask)
        {
            mask = Mask;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int j = -1; j <= 1; j++)
                for (int i = -1; i <= 1; i++)
                {
                    int idX = Clamp(x + i, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + j, 0, sourceImage.Height - 1);
                    if (mask[i + 1, j + 1] == 1.0f)
                    {
                        resultR = Math.Max(sourceImage.GetPixel(idX, idY).R, resultR);
                        resultG = Math.Max(sourceImage.GetPixel(idX, idY).G, resultG);
                        resultB = Math.Max(sourceImage.GetPixel(idX, idY).B, resultB);
                    }
                }
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255));
        }
    }
}
