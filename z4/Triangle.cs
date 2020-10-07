using System;
using System.Collections.Generic;
using System.Text;

namespace z4
{
    class Triangle
    {
        private double SideA, SideB, SideC;
        public Triangle(double FirstSide, double SecondSide, double ThirdSide)
        {
            SideA = FirstSide;
            SideB = SecondSide;
            SideC = ThirdSide;
        }
        public void ChangeSideA(double Side) { SideA = Side; }
        public void ChangeSideB(double Side) { SideB = Side; }
        public void ChangeSideC(double Side) { SideC = Side; }

        public double CalculatePerimeter() { return SideA + SideB + SideC; }

        private double CalculateAngle(string Angle)
        {
            if (Angle == "A")
            {
                if(SideA == 0 || SideB == 0 || SideC == 0) { return 0; }
                return Math.Acos((SideB * SideB + SideC * SideC - SideA * SideA) / (2 * SideB * SideC)) * (180 / Math.PI);
            }
            if (Angle == "B")
            {
                if (SideA == 0 || SideB == 0 || SideC == 0) { return 0; }
                return Math.Acos((SideA * SideA + SideC * SideC - SideB * SideB) / (2 * SideA * SideC)) * (180 / Math.PI);
            }
            if (Angle == "A")
            {
                if (SideA == 0 || SideB == 0 || SideC == 0) { return 0; }
                return Math.Acos((SideB * SideB + SideA * SideA - SideC * SideC) / (2 * SideB * SideA)) * (180 / Math.PI);
            }
            return 0;
        }
        public void GetAngles()
        {
            Console.WriteLine("Angle A is " + CalculateAngle("A") + "degrees");
            Console.WriteLine("Angle B is " + CalculateAngle("B") + "degrees");
            Console.WriteLine("Angle C is " + CalculateAngle("C") + "degrees");
        }
    }
}
