using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class GameStep
    {
        private int[] X = {1, -1, 1, 1, -1, -1, 0, 0};
        
        private int[] Y = {0, 0, 1, -1, -1, 1, -1, 1};

        private Field Field;

        private Field NewField;
        
        private List<Pixel> AddPixels;
        
        private List<Pixel> RemovePixels;
        
        public GameStep(Field field)
        {
            Field = field;
            AddPixels = new List<Pixel>();
            RemovePixels = new List<Pixel>();
        }

        public Field GetNewField()
        {
            return NewField;
        }

        public List<Pixel> GetAddPixels()
        {
            return AddPixels;
        }
        
        public List<Pixel> GetRemovePixels()
        {
            return RemovePixels;
        }
        
        public void ExecuteStep()
        {
            int[,] neighbors = new int[Field.Height,Field.Width];
            Dictionary<int, Pixel> pixels = new Dictionary<int, Pixel>();
            
            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.Width; j++)
                {
                    neighbors[i, j] = Field.Neighbors[i, j];
                }
            }

            foreach (var (key, value) in Field.Pixels)
            {
                if (CellAnalyzer(Field.Neighbors[value.Y, value.X], false))
                {
                    pixels[key] = value;
                }
                else
                {
                    RemovePixels.Add(value);
                    for (int i = 0; i < 8; i++)
                    {
                        if (Field.CheckCoordinates(value.X + X[i], value.Y + Y[i]))
                        {
                            neighbors[value.Y + Y[i], value.X + X[i]]--;
                        }
                    }
                }
            }

            for (int i = 0; i < Field.Height; i++)
            {
                for (int j = 0; j < Field.Width; j++)
                {
                    if (!Field.Pixels.ContainsKey(Field.GetHash(j,i)) &&
                        CellAnalyzer(Field.Neighbors[i, j], true))
                    {
                        Pixel pixel = new Pixel(j, i);
                        AddPixels.Add(pixel);
                        pixels[Field.GetHash(j, i)] = pixel;
                        
                        for (int k = 0; k < 8; k++)
                        {
                            if (Field.CheckCoordinates(j + X[k], i + Y[k]))
                            {
                                neighbors[i + Y[k], j + X[k]]++;
                            }
                        }
                    }
                }
            }
            
            NewField = new Field(neighbors, pixels, Field.Height,Field.Width);
        }

        public bool CellAnalyzer(int cell, bool isEmpty)
        {
            if (isEmpty)
            {
                return cell == 3;
            }
            else
            {
                return cell == 2 || cell == 3;
            }
        }
    }
}