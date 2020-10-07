using System;
using System.Collections.Generic;
using System.Text;

namespace z5
{
    class Square : Figure
    {
        private double Side;
        public Square(double a)
        {
            Side = a;
        }
        public override double CalculateArea()
        {
            return Side * Side;
        }
        public override double CalculatePerimeter()
        {
            return 4 * Side;
        }
    }
}
