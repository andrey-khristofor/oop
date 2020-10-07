using System;
using System.Collections.Generic;
using System.Text;

namespace z5
{
    class Rhombus : Figure
    {
        private double Side , Angle;
        public Rhombus(double _side, double _angle)
        {
            Side = _side;
            Angle = _angle;
        }
        public override double CalculateArea()
        {
            return Side * Side * Math.Sin(Angle / 180 * Math.PI);
        }
        public override double CalculatePerimeter()
        {
            return 4 * Side;
        }
    }
}
