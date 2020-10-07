using System;
using System.Collections.Generic;
using System.Text;

namespace z5
{
    class Circle : Figure
    {
        private double Radius;
        public Circle(double r)
        {
            Radius = r;
        }
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
