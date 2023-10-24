using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Permutations_with_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().ToArray();

            Permutate(0, elements);
        }

        private static void Permutate(int index, string[] elements)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permutate(index + 1, elements);
            var used = new HashSet<string> { elements[index] };

            for (int i = index + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    Swap(index, i, elements);
                    Permutate(index + 1, elements);
                    Swap(index, i, elements);

                    used.Add(elements[i]);  
                }

            }
        }

        private static void Swap(int index, int i, string[] elements)
        {
            string temp = elements[i];
            elements[i] = elements[index];
            elements[index] = temp;
        }
    }
}
