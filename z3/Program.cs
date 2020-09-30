using System;

namespace z3
{
    class Converter
    {
        double usd, euro;
        public Converter(double x, double y)
        {
            usd = x;
            euro = y;
        }
        public double UahToUsd(double x)
        {
            return x / usd;
        }
        public double UsdToUah(double x)
        {
            return x * usd;
        }
        public double UahToEuro(double x)
        {
            return x / euro;
        }
        public double EuroToUah(double x)
        {
            return x * euro;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Converter changer = new Converter(28.35, 32.92);
            Console.WriteLine(changer.UahToUsd(100) + " is 100 uah in usd");
            Console.WriteLine(changer.UahToEuro(100) + " is 100 uah in euro");
            Console.WriteLine(changer.UsdToUah(100) + " is 100 usd in uah");
            Console.WriteLine(changer.EuroToUah(100) + " is 100 euro in uah");
        }
    }
}
