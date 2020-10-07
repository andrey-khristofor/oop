using System;
using System.Collections.Generic;
using System.Text;

namespace z5
{
    class Triangle : Figure
    {
        private double SideA, SideB, SideC;
        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }
        public override double CalculateArea()
        {
            double p = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }
        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }
    }
}
