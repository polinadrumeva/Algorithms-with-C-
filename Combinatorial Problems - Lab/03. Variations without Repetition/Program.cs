using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Variations_without_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().ToArray();
            var used = new bool[elements.Length];

            int k = int.Parse(Console.ReadLine());
            var variations = new string[k];

            Variations(0, elements, variations, used);
        }

        private static void Variations(int index, string[] elements, string[] variations, bool[] used)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    Variations(index + 1, elements, variations, used);
                    used[i] = false;
                }

            }
        }
    }
}
