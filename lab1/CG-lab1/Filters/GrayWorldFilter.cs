using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class GrayWorldFilter : Filters
    {
        int avgR;
        int avgG;
        int avgB;
        int avg = -1;

        void calculateAverageBrightness(Bitmap sourceImage)
        {
            for(int i = 0; i < sourceImage.Width; i++)
                for(int j = 0; j < sourceImage.Height; j++)
                {
                    Color sourceColor = sourceImage.GetPixel(i, j);
                    avgR += sourceColor.R;
                    avgG += sourceColor.G;
                    avgB += sourceColor.B;
                }
            int countOfPixels = sourceImage.Height * sourceImage.Width;
            avgR /= countOfPixels;
            avgG /= countOfPixels;
            avgB /= countOfPixels;
            avg = (avgR + avgG + avgB) / 3;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            if(avg == -1)
                calculateAverageBrightness(sourceImage);
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(
                Clamp(sourceColor.R * avg / avgR, 0, 255),
                Clamp(sourceColor.G * avg / avgG, 0, 255),
                Clamp(sourceColor.B * avg / avgB, 0, 255));
            return resultColor;
        }
    }
}
