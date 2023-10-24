
namespace _01._Reverse_Array
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split();

            ReverseArray(array, 0);

            Console.WriteLine(string.Join(" ", array));
        }

        private static void ReverseArray(string[] array, int index)
        {
            if (index == array.Length / 2)
            {
                return;
            }

            var temp = array[index];
            array[index] = array[array.Length - index - 1];
            array[array.Length - index - 1] = temp;

            ReverseArray(array, index + 1);
        }
    }
}