using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace GameOfLife
{
    public class Pixel
    {
        public const int Size = 15;

        public int X { get; }

        public int Y { get; }
        
        public Rectangle Rectangle { get; }

        public Pixel(int x, int y)
        {
            X = x;
            Y = y;
            Rectangle = new Rectangle();
            InitializeRectangle(X, Y);
        }
        
        private void InitializeRectangle(int x, int y)
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush {Color = Color.FromArgb(120, 255, 0, 0)};
            Rectangle.Fill = mySolidColorBrush;
            Rectangle.Width = Size;
            Rectangle.Height = Size;
            Rectangle.Margin = new Thickness(x * Size, y * Size, 0, 0);
        }
    }
}
