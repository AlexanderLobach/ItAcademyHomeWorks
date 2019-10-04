using System;

namespace HW_05_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("Hello gyus!");
            int i;
            int [] mass1 = new int[5];
            Random rand = new Random();
            for (i = 0; i < mass1.Length; i++)
            {
                mass1[i] = rand.Next(0, 100);
                Console.WriteLine($"mass1[{i}] = {mass1[i]}");
            }  
            int [] mass2 = new int[5];
            for (i = 0; i < mass2.Length; i++)
            {

                Console.WriteLine($"Enter value {i} for array mass2");
                mass2[i] =Convert.ToInt32(Console.ReadLine());
            }

            int [] mass3 = new int[5];
            for (i = 0; i < mass3.Length; i++)
            {

                mass3[i] = mass1[i] + mass2[i];
                Console.WriteLine($"mass1[{i}] = {mass1[i]}      mass2[{i}] = {mass2[i]}       mass3[{i}] = {mass3[i]}"); 
            }


        }
    }
}
