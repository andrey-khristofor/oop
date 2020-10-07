using System;
using System.Collections.Generic;
using System.Text;

namespace z6
{
    class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(double A, double angle)
            : base(A, A, angle) { }
        public override double CalculateArea()
        {
            return SideA * SideA * Math.Sin(Angle) / 2;
        }
        public override double CalculatePerimeter()
        {
            return SideA + SideA + Math.Sqrt(2 * SideA * SideA * (1 - Math.Cos(Angle)));
        }
    }
}
