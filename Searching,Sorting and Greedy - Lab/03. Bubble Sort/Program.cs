using System;
using System.Linq;

namespace _03._Bubble_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            BubbleSort(elements);

            Console.WriteLine(String.Join(" ", elements));
        }

        private static void BubbleSort(int[] elements)
        {
            var sortedCount = 0;
            var isSorted = false;
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 1; i < elements.Length -sortedCount; i++)
                {
                    var j = i - 1;
                    if (elements[j] > elements[i])
                    {
                        Swap(elements, j, i);
                        isSorted = false;
                    }
                }

                sortedCount++;
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
