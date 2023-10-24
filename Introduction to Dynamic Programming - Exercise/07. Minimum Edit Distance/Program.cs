using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Minimum_Edit_Distance
{
	class Program
	{
		static void Main(string[] args)
		{
			var replaceCost = int.Parse(Console.ReadLine());
			var insertCost = int.Parse(Console.ReadLine());
			var deleteCost = int.Parse(Console.ReadLine());

			var first = Console.ReadLine();
			var second = Console.ReadLine();

			var dp = new int[first.Length + 1, second.Length + 1];
			for (int col = 1; col < dp.GetLength(1); col++)
			{
				dp[0, col] = dp[0, col - 1] + insertCost;
			}

			for (int row = 1; row < dp.GetLength(0); row++)
			{
				dp[row, 0] = dp[row - 1, 0] + deleteCost;
			}

			for (int row = 1; row < dp.GetLength(0); row++)
			{
				for (int col = 1; col < dp.GetLength(1); col++)
				{
					if (first[row-1] == second[col-1])
					{
						dp[row, col] = dp[row - 1, col - 1];
					}
					else
					{
						var replace = dp[row - 1, col - 1] + replaceCost;
						var insert = dp[row, col - 1] + insertCost;
						var delete = dp[row - 1, col] + deleteCost;

						dp[row, col] = Math.Min(replace, Math.Min(insert, delete));
					}
				}
			}

			Console.WriteLine($"Minimum edit distance: {dp[first.Length,second.Length]}");

		}
	}
}