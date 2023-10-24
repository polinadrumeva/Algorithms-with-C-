using System;
using System.Linq;

namespace _04._Insertion_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            InsertionSort(elements);

            Console.WriteLine(String.Join(" ", elements));
        }

        private static void InsertionSort(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                var j = i;
                while (j > 0 && elements[j-1] > elements[j])
                {
                    Swap(elements, j, j - 1);
                    j--;
                }
            }

        }

        private static void Swap(int[] elements, int i, int min)
        {
            var temp = elements[i];
            elements[i] = elements[min];
            elements[min] = temp;
        }
    }
}
