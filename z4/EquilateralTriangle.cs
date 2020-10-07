using System;
using System.Collections.Generic;
using System.Text;

namespace z4
{
    class EquilateralTriangle : Triangle
    {
        private double Area;
        public EquilateralTriangle(double Side)
            : base(Side , Side , Side) { Area = Side * Side * Math.Sqrt(3) / 4; }
        public double GetArea() { return Area; }
    }
}
