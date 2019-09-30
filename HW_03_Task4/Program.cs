using System;

namespace HW_03_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("            Hello gues!");

            addition();
        }

        static void addition()
        {

            int num1;
            int num2;
            int result=0;
            int result_user=0;
            Console.WriteLine("    please enter the number 1");
            string s_num1= Console.ReadLine();
            Console.WriteLine("    please enter the number 2");
            string s_num2= Console.ReadLine();
            num1= Convert.ToInt32(s_num1);
            num2= Convert.ToInt32(s_num2);
            
            Console.WriteLine("please enter the operator '+' '-' '*' or '/' ");
            ConsoleKeyInfo operator_user= new ConsoleKeyInfo();
            operator_user= Console.ReadKey(true);

            if (operator_user.Key== ConsoleKey.Add)
            {
                Console.WriteLine(" +");
                result= num1+num2;
                Console.WriteLine(" please enter the sum of the numbers");
                string s_result_user= Console.ReadLine();
                result_user=Convert.ToInt32(s_result_user);
            } 
           
           if (operator_user.Key== ConsoleKey.Subtract)
            {
                Console.WriteLine(" -");
                result= num1-num2;
                Console.WriteLine(" please enter the sum of the numbers");
                string s_result_user= Console.ReadLine();
                result_user=Convert.ToInt32(s_result_user);
            } 

            if (operator_user.Key== ConsoleKey.Divide)
            {
                Console.WriteLine(" /");
                result= num1/num2;
                Console.WriteLine(" please enter the sum of the numbers");
                string s_result_user= Console.ReadLine();
                result_user=Convert.ToInt32(s_result_user);
            } 

            if (operator_user.Key== ConsoleKey.Multiply)
            {
                Console.WriteLine(" *");
                result= num1*num2;
                Console.WriteLine(" please enter the sum of the numbers");
                string s_result_user= Console.ReadLine();
                result_user=Convert.ToInt32(s_result_user);
            } 

            Console.ForegroundColor= ConsoleColor.Red;

            if (result_user== result)
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("         Correctly!");
            }
            else 
                Console.WriteLine("           Wrong!");

            //Console.ForegroundColor=ConsoleColor.White;
            if (result_user< result)
            {
                Console.WriteLine("  this number should be greater!");
            }       
            if (result_user> result)
            {
                Console.WriteLine("    this numder should be less");
            }
                



        }





    }
}
