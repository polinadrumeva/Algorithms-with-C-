using System;
using System.Linq;

namespace _05._Combinations_without_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().ToArray();

            int k = int.Parse(Console.ReadLine());
            var combinations = new string[k];

            GetCombinations(0,0, elements, combinations);
        }

        private static void GetCombinations(int index, int startIndex, string[] elements, string[] combinations)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = startIndex; i < elements.Length; i++)
            {
               
                    combinations[index] = elements[i];
                    GetCombinations(index + 1, i+1, elements, combinations);
                   
            }
        }
    }
}
