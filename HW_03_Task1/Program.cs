using System;

namespace HW_03_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello gues!");

            addition();
        }

        static void addition()
        {

            int num1;
            int num2;
            int sum;
            Console.WriteLine("enter number 1");
            string s_num1= Console.ReadLine();
            Console.WriteLine("enter numder 2");
            string s_num2= Console.ReadLine();
            num1= Convert.ToInt32(s_num1);
            num2= Convert.ToInt32(s_num2);
            sum= num1+num2;
            Console.WriteLine($"sum= {sum}");
        }





    }
}
