using System;
using System.Globalization;

namespace HW_04_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("cash savings");
            NumberFormatInfo nfi = new CultureInfo( "ru-RU", false ).NumberFormat;
            int money = 1000;
            int moneySave = 0;
            int gain;
            for (int i = 1; i <= 12; i++)
            {
                moneySave = money;
                gain = (moneySave/50*i);
                moneySave = (moneySave + moneySave/ 50 * i);
                nfi.CurrencyDecimalDigits = 2;
                Console.WriteLine( "gain{0}= {1}", i, gain.ToString( "C", nfi ));
            }
                moneySave = money;
            for (int i = 1; i <= 12; i++)
            {
                moneySave = (moneySave + moneySave/ 50 * i);
                nfi.CurrencyDecimalDigits = 2;
                Console.WriteLine( "money{0}= {1}", i, (moneySave.ToString( "C", nfi )));
            }
        }
    }
}
