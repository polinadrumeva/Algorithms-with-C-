namespace _05._School_Teams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var girlsCombination = new string[3];
            var girlsCombinations = new List<string[]>();

            GenerateCombinations(0, 0, girls, girlsCombination, girlsCombinations);

            var boys = Console.ReadLine().Split(", ");
            var boysCombination = new string[2];
            var boysCombinations = new List<string[]>();

            GenerateCombinations(0, 0, boys, boysCombination, boysCombinations);

            foreach (var girlComb in girlsCombinations)
            {
                foreach (var boyComb in boysCombinations)
                {
                    Console.WriteLine($"{string.Join(", ", girlComb)}, {string.Join(", ", boyComb)}");
                }
            }
        }

        private static void GenerateCombinations(int index, int start, string[] girls, string[] girlsCombination, List<string[]> girlsCombinations)
        {
            if (index >= girlsCombination.Length)
            {
                girlsCombinations.Add(girlsCombination.ToArray());
                return;
            }

            for (int i = start; i < girls.Length; i++)
            {
                girlsCombination[index] = girls[i];
                GenerateCombinations(index + 1, i + 1, girls, girlsCombination, girlsCombinations);
            }
        }
    }
}