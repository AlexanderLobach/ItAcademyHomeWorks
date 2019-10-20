using System;
using System.Linq;

namespace HW_06_Task2
{
    class Program
    { 
                static void RemoveMaxWord(string[] words)
            {
                int i = 0;
                int maxIndex = i;
                for (i = 1; i < words.Length; i++)
            {
                if (words[i].Length > words[i-1].Length)
                {
                    maxIndex = i;
                }
            } 
                string[] wordsClearMax = new string[words.Length - 1];
                int x = 0;
                for (i = 0; i < words.Length; i++)
                {
                    if (i != maxIndex)
                   {
                        wordsClearMax[x] = words[i];
                        x++;
                   } 
                }
                 Console.WriteLine("   {0}", String.Join(" ", wordsClearMax));
            }
                static void ReplacMinMaxWord(string[] words)
            {
                int i = 0;
                int maxIndex = i;
                int minIndex = i;
                for (i = 1; i < words.Length; i++)
            {
                if (words[i].Length > words[i-1].Length)
                {
                    maxIndex = i;
                }
                if (words[i].Length < words[i-1].Length)
                {
                    minIndex = i;
                }
            } 
                string maxWords = words[maxIndex];
                words[maxIndex] = words[minIndex];
                words[minIndex] = maxWords;
                Console.WriteLine("   {0}", String.Join(" ", words));
            } 
            static void CountLetterMark(string[] words)
            {
                int i;
                int countLetter = 0;
                int countMark = 0;
                for (i = 0; i < words.Length; i++)
                {
                    countLetter += words[i].Count(char.IsLetter);
                    countMark += words[i].Count(char.IsPunctuation);
                }
                Console.WriteLine($"    letter in the string = {countLetter}");
                Console.WriteLine($"    mark in the string = {countMark}");
            }
            static void SortingDecreas(string[] words)
            {
                int i;
                int x;
                string temp;
                string[] wordsDecreas = new string[words.Length];
                for(i = 0; i < words.Length; i++)
                {
                    for (x = i+1; x < words.Length; x++)
                {
                    if (words[x].Length > words[i].Length)
                {
                    temp = words[i];
                    words[i] = words[x];
                    words[x] = temp;
                }
                }
                Console.WriteLine(words[i]);
                }
            }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sring:");
            string word = Convert.ToString(Console.ReadLine());
            string [] words = word.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            RemoveMaxWord(words);
            ReplacMinMaxWord(words);
            CountLetterMark(words);
            SortingDecreas(words);
        }
    }
}
