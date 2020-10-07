using System;
using System.Collections.Generic;
using System.Text;

namespace z5
{
    class Rectangle : Figure
    {
        private double SideA, SideB;
        public Rectangle(double a, double b)
        {
            SideA = a;
            SideB = b;
        }
        public override double CalculateArea()
        {
            return SideA * SideB;
        }
        public override double CalculatePerimeter()
        {
            return 2 * (SideA + SideB);
        }
    }
}
