using System;

namespace HW_06_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("write poem separating the string symbol of \";\"");
            string poem = Convert.ToString(Console.ReadLine());
            string [] words = poem.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            int i;
            for (i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Replace("o", "a");
                Console.WriteLine(words[i]);
            }
            Console.ReadKey();
        }
    }
}

