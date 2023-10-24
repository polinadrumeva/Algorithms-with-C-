using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Areas_in_Matrix
{
    internal class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;
        private static IDictionary<char, int> areas;
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new SortedDictionary<char, int>();

            for (int r = 0; r < rows; r++)
            {
                var elements = Console.ReadLine();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = elements[c];
                }
            }
            var areaCount = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (!visited[r, c])
                    {
                        var nodeValue = matrix[r, c];
                        
                        DFS(r, c, nodeValue);

                        areaCount++;
                        if (areas.ContainsKey(nodeValue))
                        {
                            areas[nodeValue]++;
						}
                        else
                        {
                            areas[nodeValue] = 1;
                        }
                    }
                }
            }
            Console.WriteLine($"Areas: {areaCount}");
            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col, char nodeValue)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1) || visited[row, col])
            {
                return;
            }

            if (matrix[row, col] != nodeValue)
            {
                return;
            }

            visited[row, col] = true;

            DFS(row, col + 1, nodeValue);
            DFS(row, col - 1, nodeValue);
            DFS(row + 1, col, nodeValue);
            DFS(row - 1, col, nodeValue);


		}
	}
}