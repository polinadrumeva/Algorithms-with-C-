using System;
using System.Linq;

namespace _02._Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            SelectionSort(elements);

            Console.WriteLine(String.Join(" ", elements));
        }

        private static void SelectionSort(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                var min = i;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[j] < elements[min])
                    {
                        min = j;
                    }
                }

                Swap(elements, i, min);
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
