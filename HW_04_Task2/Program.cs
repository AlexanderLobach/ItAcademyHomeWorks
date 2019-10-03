using System;

namespace HW_04_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello gues!");
            ConsoleKey cki;
            do 
            {
            cki = Console.ReadKey().Key;
            if (cki == ConsoleKey.W || cki == ConsoleKey.S || cki == ConsoleKey.D || cki == ConsoleKey.A )
            {
            if ( cki == ConsoleKey.W)
            {
                Console.Clear();
                Console.WriteLine(" \n UP!");
            }
            if (cki == ConsoleKey.S)
            {
                Console.Clear();
                Console.WriteLine(" \n Down!");
            }
            if (cki == ConsoleKey.A)
            {
                Console.Clear();
                Console.WriteLine(" \n Leftward!");
            }
            if (cki == ConsoleKey.D)
            {
                Console.Clear();
                Console.WriteLine(" \n Rightwards!");
            }
            }
            else 
            {
                Console.Clear();
                Console.WriteLine("\n Stand still!");
            }
            } while (cki != ConsoleKey.Escape);
        }
    }
}
