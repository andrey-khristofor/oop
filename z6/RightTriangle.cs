using System;
using System.Collections.Generic;
using System.Text;

namespace z6
{
    class RightTriangle : Triangle
    {
        public RightTriangle(double A, double B)
            : base(A, B, 90) { }
        public override double CalculateArea()
        {
            return SideA * SideB / 2;
        }
        public override double CalculatePerimeter()
        {
            return SideA + SideB + Math.Sqrt(SideA * SideA + SideB * SideB);
        }
    }
}
