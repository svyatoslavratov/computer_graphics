using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class MotionBlurFilter : MatrixFilter
    {
        public MotionBlurFilter()
        {
            int size = 9;
            kernel = new float[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                        kernel[i, j] = 1.0f / size;
                    else
                        kernel[i, j] = 0;
                }
        }
    }
}
