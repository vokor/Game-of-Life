using System.Collections.Generic;

namespace GameOfLife
{
    public interface ITest
    {
        Dictionary<int, Pixel> GenerateTest(double height, double width);
    }
}