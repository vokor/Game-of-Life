using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    internal class Sample1 : ITest
    {
        public Dictionary<int, Pixel> GenerateTest(double height, double width)
        {
            int rwidth = (int)Math.Floor(width);
            Dictionary<int, Pixel> pixels = new Dictionary<int, Pixel>();
            pixels[GetHash(rwidth, 0, 0)] = new Pixel(0, 0);
            pixels[GetHash(rwidth, 1, 1)] = new Pixel(1, 1);
            pixels[GetHash(rwidth, 2, 1)] = new Pixel(2, 1);
            pixels[GetHash(rwidth, 0, 2)] = new Pixel(0, 2);
            pixels[GetHash(rwidth, 1, 2)] = new Pixel(1, 2);
            

            return pixels;
        }
        
        private int GetHash(int width, int x, int y)
        {
            return width * y + x;
        }
    }
}
