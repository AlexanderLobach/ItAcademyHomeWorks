using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // explicit type conversion
             Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n       explicit type conversion \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" enter a number between -128 and 127 (sbyte type)");
            string num= Console.ReadLine();
            sbyte num1;
            num1= Convert.ToSByte(num);        
            Int16 num2;
            num2 = Convert.ToInt16(num1);
            Int32 num3;
            num3 = Convert.ToInt32 (num2);
            float num4;
            num4 = Convert.ToSingle(num3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("sbyte to int16= {0}   int16 to int32= {1}   int 32 to float= {2}", num2,  num3, num4 ));

                    //implicit type conversion
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n       implicit type conversion \n");
            Console.ForegroundColor = ConsoleColor.Green;
            float num5= num1;
            double num6= num2;
            decimal num7= num3;
            Console.WriteLine(string.Format("sbyte to float= {0}   int16 to doble= {1}   int32 to decimal= {2}", num5,  num6, num7 ));
            
            // boxing operation
            Console.WriteLine("boxin operation a into o");
            int a= 23;
            object o= a;
            Console.WriteLine($"a= {a},  o= {o}");

            //unboxing operation

            Console.WriteLine("unboxin operation o into c");
            int c = Convert.ToInt32(o);
            Console.WriteLine($"c= {c}");
            
            
            Console.ReadKey();
        }
    }
}
