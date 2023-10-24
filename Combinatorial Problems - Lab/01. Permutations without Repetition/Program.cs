using System;
using System.Linq;

namespace _01._Permutations_without_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().ToArray();
            var permutations = new string[elements.Length];
            var used = new bool[elements.Length];

            Permutate(0, elements, permutations, used);
        }

        private static void Permutate(int index, string[] elements, string[] permutations, bool[] used)
        {
            if (index >= permutations.Length)
            {
                Console.WriteLine(string.Join(" ", permutations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permutations[index] = elements[i];
                    Permutate(index + 1, elements, permutations, used);
                    used[i] = false;
                }
               
            }
        }
    }
}
