using System;

namespace HW_05_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] mass = new int[5];
            Console.WriteLine("enter values for array 'mass' ");
            int i;
            int x;
            for (i = 0; i < mass.Length-1; i++)
            {
                Console.WriteLine($"mass[{i}]");
                mass[i] = Convert.ToInt32( Console.ReadLine());
            }
            for ( i = 0; i < mass.Length; i++)
            {
                Console.WriteLine($"mass[{i}] = {mass[i]}");
            }    
            Console.WriteLine($"enter the value 'mass[]'");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the position number in the array 'mass' ");
            i = Convert.ToInt32(Console.ReadLine());
            for (x = mass.Length-1 ; x >i ; x--)
            {
                mass[x] = mass[x-1];
            }
            mass[i] = y;
            i = 0;
            for ( i = 0; i < mass.Length; i++)
            {
                Console.WriteLine($"mass[{i}] = {mass[i]}");
            }
        }
    }
}
