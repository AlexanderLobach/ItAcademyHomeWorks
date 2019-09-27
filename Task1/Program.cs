using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // explicit type conversion
             Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("       explicit type conversion \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" enter a number between -128 and 127 (sbyte type)");
            string num= Console.ReadLine();
            sbyte num1;
            num1= Convert.ToSByte(num);        
            Int16 num2;
            num2 = Convert.ToInt16(num1);
            Int32 num3;
            num3 = Convert.ToInt32 (num1);
            float num4;
            num4 = Convert.ToSingle(num1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("Int16={0} Int32={1} float={2}", num2,  num3, num4 ));
            Console.ReadKey();
        }
    }
}
