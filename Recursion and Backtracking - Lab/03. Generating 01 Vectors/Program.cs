using System;

namespace _03._Generating_01_Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var array = new int[n];

            Generate(array, 0);
        }

        private static void Generate(int[] array, int index)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(String.Join(String.Empty, array));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                array[index] = i;
                Generate(array, index + 1);
            }
        }
    }
}
