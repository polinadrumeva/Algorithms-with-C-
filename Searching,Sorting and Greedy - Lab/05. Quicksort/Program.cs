using System;
using System.Linq;

namespace _05._Quicksort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            QuickSort(elements, 0, elements.Length - 1);

            Console.WriteLine(String.Join(" ", elements));
        }

        private static void QuickSort(int[] elements, int i, int numbersLength)
        {
            if (i >= numbersLength)
            {
                return;
            }

            var pivot = i;
            var left = i + 1;
            var right = numbersLength;

            while (left <= right)
            {
                if (elements[left] > elements[pivot] && elements[right] < elements[pivot])
                {
                    Swap(elements, left, right);
                }

                if (elements[left] <= elements[pivot])
                {
                    left++;
                }

                if (elements[right] >= elements[pivot])
                { 
                right--;
                }
            }

            Swap(elements, pivot, right);

            QuickSort(elements, i, right - 1);
            QuickSort(elements, right + 1, numbersLength);
        }

        private static void Swap(int[] elements, int i, int min)
        {
            var temp = elements[i];
            elements[i] = elements[min];
            elements[min] = temp;
        }
    }
}
