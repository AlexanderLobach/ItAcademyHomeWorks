using System;

namespace HW_04_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 26; i++)
            {
                char symbol = (char)(90 - i);
                Console.Write(symbol);
            }
            Console.ReadLine();
    
        }
    }
}
