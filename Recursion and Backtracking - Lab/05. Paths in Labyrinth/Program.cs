using System;
using System.Collections.Generic;

namespace _05._Paths_in_Labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var colsData = Console.ReadLine();
                for (int j = 0; j < colsData.Length; j++)
                {
                    matrix[i, j] = colsData[j];
                }
            }

            FindPaths(matrix, 0, 0, new List<string>(), string.Empty);
        }

        private static void FindPaths(char[,] matrix, int row, int col, List<string> directions, string direction)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1) || matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }

            directions.Add(direction);

            if (matrix[row, col] == 'e')
            {
                Console.WriteLine(string.Join("", directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            matrix[row, col] = 'v';
          

            FindPaths(matrix, row - 1, col, directions, "U");
            FindPaths(matrix, row + 1, col, directions, "D");
            FindPaths(matrix, row, col - 1, directions, "L");
            FindPaths(matrix, row, col + 1, directions, "R");

            matrix[row, col] = '-';
            directions.RemoveAt(directions.Count-1);
        }
    }
}
