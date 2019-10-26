using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Field
    {
        private int[] X = {1, -1, 1, 1, -1, -1, 0, 0};
        
        private int[] Y = {0, 0, 1, -1, -1, 1, -1, 1};

        public Dictionary<int, Pixel> Pixels { get; }
        
        public int[,] Neighbors { get; }
        
        public int Width { get; }
        
        public int Height { get; }
        
        public int GetHash(int x, int y)
        {
            return Width * y + x;
        }
        
        public Field(double height, double width, Dictionary<int, Pixel> pixels)
        {
            Pixels = pixels;
            Height = (int)Math.Floor(height);
            Width = (int)Math.Floor(width);
            Neighbors = new int[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Neighbors[i, j] = 0;
                }
            }
            
            foreach (var value in Pixels.Values)
            {
                int x = value.X;
                int y = value.Y;
                for (int i = 0; i < 8; i++)
                {
                    if (CheckCoordinates(x + X[i], y + Y[i]))
                    {
                        Neighbors[y + Y[i], x + X[i]]++;
                    }
                }
            }
        }

        public Field(int[,] neighbors, Dictionary<int, Pixel> pixels, int height, int width)
        {
            Neighbors = neighbors;
            Pixels = pixels;
            Height = height;
            Width = width;
        }

        public bool CheckCoordinates(int x, int y)
        {
            x = x * Pixel.Size;
            y = y * Pixel.Size;
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}