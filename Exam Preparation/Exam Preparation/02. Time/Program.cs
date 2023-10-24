using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _02._Time
{
	internal class Program
	{
		private static int[][] matrix;
		static void Main(string[] args)
		{

			var first = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var second = Console.ReadLine().Split().Select(int.Parse).ToArray();

			InitializeMatrix(first, second);

			var result = new Stack<int>();
			var row = first.Length;
			var col = second.Length;

			while (row > 0 && col > 0)
			{
				if (first[row-1] == second[col-1])
				{
					result.Push(first[row - 1]);
					row--;
					col--;
				}
				else if (matrix[row][col-1] >= matrix[row - 1][col])
				{
					col--;
				}
                else
                {
					row--;
				}
            }

			int count = matrix[^1][^1];
            Console.WriteLine(string.Join(" ", result));
            Console.WriteLine(count);

        }

		private static void InitializeMatrix(int[] first, int[] second)
		{
			matrix = new int[first.Length + 1][];
			for (int i = 0; i < matrix.Length; i++)
			{
				matrix[i] = new int[second.Length + 1];
			}

			for (int r = 1; r < matrix.Length; r++)
			{
				for (int c = 1; c < matrix[r].Length; c++)
				{
					if (first[r-1] == second [c-1])
					{
						matrix[r][c] = matrix[r - 1][c - 1] + 1;
					}
					else
					{
						matrix[r][c] = Math.Max(matrix[r - 1][c], matrix[r][c - 1]);
					}
				}

			}
		}
	}
}