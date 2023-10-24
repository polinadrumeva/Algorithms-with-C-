using System;
using System.Collections.Generic;


namespace _03_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine().Split();
            var second = Console.ReadLine().Split();

            var list  = new List<string>();

            var length = 0;
            var secondLength = 0;
            var bigger = new string[length];
            var smaller = new string[secondLength];

            if (first.Length > second.Length)
            {
                length = first.Length;
                bigger = first;
                secondLength = second.Length;
                smaller = second;
            }
            else
            {
                length = second.Length;
                bigger = second;
                secondLength = first.Length;
                smaller = first;
            }
            
            for (int i = 0; i < secondLength; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (smaller[i] == bigger[j])
                    {
                        list.Add(smaller[i]);
                    }
                }
            }

            
                Console.WriteLine($"[{string.Join(" ", list)}]");
            

           
        }
    }
}