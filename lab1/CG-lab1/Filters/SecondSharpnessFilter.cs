using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_lab1
{
    class SecondSharpnessFilter : MatrixFilter
    {
        public SecondSharpnessFilter()
        {
            int size = 3;
            kernel = new float[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] = -1.0f;
            kernel[1, 1] = 9;
        }
    }
}
