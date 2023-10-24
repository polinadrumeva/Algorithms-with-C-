using System;
using System.Collections.Generic;
using System.Linq;


namespace _02._Move_Down_Right
{
	internal class Program
	{
		
		static void Main(string[] args)
		{
			var rows = int.Parse(Console.ReadLine());
			var cols = int.Parse(Console.ReadLine());

			var matrix = new int[rows, cols];

			for (int r = 0; r < rows; r++)
			{
				var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				for (int c = 0; c < cols; c++)
				{
					matrix[r, c] = line[c];
				}
			}

			var table = new int[rows, cols];
			table[0, 0] = matrix[0, 0];

			for (int c = 1; c < cols; c++)
			{
				table[0, c] = table[0, c - 1] + matrix[0, c];
			}

			for (int r = 1; r < rows; r++)
			{
				table[r, 0] = table[r - 1, 0] + matrix[r, 0];
			}

			for (int r = 1; r < rows; r++)
			{
				for (int c = 1; c < cols; c++)
				{
					var upper = table[r - 1, c];
					var left = table[r, c - 1];

					table[r, c] = Math.Max(upper, left) + matrix[r, c];
				}
			}
			var path = new Stack<string>();
			var row = rows - 1;
			var col = cols - 1;

			while (row > 0 && col > 0)
			{
				path.Push($"[{row}, {col}]");
				var upper = table[row - 1, col];
				var left = table[row, col - 1];

				if (upper > left)
				{
					row--;
				}
				else
				{
					col--;
				}
			}

			while (row > 0)
			{
				path.Push($"[{row}, {col}]");
				row--;
			}

			while (col > -1)
			{
				path.Push($"[{row}, {col}]");
				col--;
			}

            Console.WriteLine(string.Join(" ", path));
        }

		
	}

}
