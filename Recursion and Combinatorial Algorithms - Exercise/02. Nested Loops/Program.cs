namespace _02._Nested_Loops
{
    using System;

    public class Program
    {
        private static int[] elements;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            elements = new int[n];

            GenerateVectors(0);
        }

        private static void GenerateVectors(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                elements[index] = i;
                GenerateVectors(index + 1);
            }
        }
    }
}