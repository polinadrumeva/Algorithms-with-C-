using System;
using System.Linq;

namespace _04._Variations_with_Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().ToArray();

            int k = int.Parse(Console.ReadLine());
            var variations = new string[k];

            Variations(0, elements, variations);
        }

        private static void Variations(int index, string[] elements, string[] variations)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                 
                    variations[index] = elements[i];
                    Variations(index + 1, elements, variations);

            }
        }
    }
}
