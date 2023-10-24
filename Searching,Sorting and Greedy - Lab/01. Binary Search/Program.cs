using System;
using System.Linq;

namespace _01._Binary_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var index = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch(elements, index));
        }

        public static int BinarySearch(int[] elements, int key)
        {
            var left = 0;
            var right = elements.Length - 1;

            while (left <= right)
            { 
                var mid = (left + right) / 2;
                var midElement = elements[mid];
                if (midElement == key)
                {
                    return mid;
                }
                else
                {
                    if (key > midElement)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

            }

            return -1;
        }
    }
}
