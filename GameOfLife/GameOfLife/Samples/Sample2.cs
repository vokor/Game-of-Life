using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameOfLife
{
    public class Sample2 : ITest
    {
        public Dictionary<int, Pixel> GenerateTest(double height, double width)
        {
            int[] X = new[] {1, 2, 1, 2, 12, 12, 12, 13, 14, 15, 16, 16, 16, 15, 14, 13, 17, 17, 17, 22, 22, 22, 23, 23, 23, 23, 24, 24, 24, 24, 25, 25, 25, 25, 25, 26, 26, 26, 26, 31, 31, 35, 35, 36, 36};
            int[] Y = new[] {5, 5, 6, 6, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 4, 5, 6, 7, 5, 4, 3, 5, 6, 2, 3, 5, 6, 2, 3, 2, 3, 4, 5, 6, 1, 2, 6, 7, 5, 6, 3, 4, 3, 4};
            int rwidth = (int)Math.Floor(width);
            Dictionary<int, Pixel> pixels = new Dictionary<int, Pixel>();
            for (int i = 0; i < X.Length; i++)
            {
                pixels[GetHash(rwidth, X[i], Y[i])] = new Pixel(X[i], Y[i]);
            }
            return pixels;
        }
        
        private int GetHash(int width, int x, int y)
        {
            return width * y + x;
        }
    }
}