using System;
using System.Collections.Generic;
using System.Text;

namespace z6
{
    abstract class Triangle
    {
        public double SideA, SideB, Angle;
        public Triangle(double A, double B, double an)
        {
            SideA = A;
            SideB = B;
            Angle = an * 180 / Math.PI;
        }
        virtual public double CalculateArea()
        {
            return SideA * SideB * Math.Sin(Angle) / 2;
        }
        virtual public double CalculatePerimeter()
        {
            return SideA + SideB + Math.Sqrt(SideA * SideA + SideB * SideB - 2 * SideA * SideB * Math.Cos(Angle));
        }
    }
}
