using System;
using System.Collections.Generic;
using System.Data;

namespace z3new
{
    /*
        В даному конвертері зберігається значення курсу певної валюти до гривні. 
        Курс гривні до самої себе наперед заданий в конвертері і рівний 1.
        Переведення різних валют між собою відбувається через їх курс до гривні.
     */
    class Converter
    {
        Dictionary<string, double> Currency = new Dictionary<string, double>
        {
            {"uah" , 1}
        };
        public void AddCurrency(string CurrencyName, double CurrencyValue)
        {
            Currency.Add(CurrencyName, CurrencyValue);
        }
        public void DeleteCurrency(string CurrencyName)
        {
            Currency.Remove(CurrencyName);
        }
        public void ChangeCurrency(string CurrencyName, double NewCurrencyValue)
        {
            Currency[CurrencyName] = NewCurrencyValue;
        }
        public double ShowCurrency(string CurrencyName)
        {
            return Currency[CurrencyName];
        }
        public double Convert(string FirstCurrencyName, string SecondCurrencyName, double Value)
        {
            if (Currency.ContainsKey(FirstCurrencyName) && Currency.ContainsKey(SecondCurrencyName))
            {
                return Value * Currency[FirstCurrencyName] / Currency[SecondCurrencyName];
            }
            return -1;
        }
        public void PrintConverted(string FirstCurrencyName, string SecondCurrencyName, double Value)
        {
            if (Currency.ContainsKey(FirstCurrencyName) && Currency.ContainsKey(SecondCurrencyName))
            {
                double result = Value * Currency[FirstCurrencyName] / Currency[SecondCurrencyName];
                Console.WriteLine(Value + " " + FirstCurrencyName + " is " + result + " " + SecondCurrencyName);
            }
            else Console.WriteLine("Inquiry is incorrect");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Converter conv = new Converter();
            conv.AddCurrency("USD", 28.32);
            conv.AddCurrency("EUR", 33.26);
            conv.AddCurrency("PLN", 7);
            conv.AddCurrency("JPY", 0.27);
            conv.AddCurrency("CZK", 1.24);
            conv.ChangeCurrency("PLN", 7.42);
            conv.DeleteCurrency("CZK");
            
            Console.WriteLine(conv.Convert("UAH", "USD", 100));
            conv.PrintConverted("EUR", "JPY", 1);
            conv.PrintConverted("incorrect", "inquiry", 1);
        }
    }
}
