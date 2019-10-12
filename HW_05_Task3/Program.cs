using System;

namespace HW_05_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] mass = new int [5];
            Random rand = new Random();
            int i;
            for (i = 0; i < mass.Length; i++)
            {
                mass[i] = rand.Next(0, 100);
                Console.WriteLine($"mass[{i}] = {mass[i]}");
            }
            Console.WriteLine("\n  reversing an array:\n");
            int [] massBuff = new int [mass.Length];
            for (i = 0; i < mass.Length; i++)
            {
                massBuff[i] = mass[i];
            }
            for (i = 0; i < mass.Length; i++)
            {
                mass[i] = massBuff[mass.Length - 1 - i];
                Console.WriteLine($"mass[{i}] = {mass[i]}");
            }
        }
    }
}
