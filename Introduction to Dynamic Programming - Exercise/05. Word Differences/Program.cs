using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Word_Differences
{
	class Program
	{
		static void Main(string[] args)
		{
			var first = Console.ReadLine();
			var second = Console.ReadLine();

			var dp = new int[first.Length + 1, second.Length + 1];

			for (int i = 1; i < dp.GetLength(0); i++)
			{
				dp[i, 0] = i;
			}

			for (int i = 1; i < dp.GetLength(1); i++)
			{
				dp[0, i] = i;
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
						dp[row, col] = Math.Min(dp[row - 1, col], dp[row, col - 1]) + 1;
					}
				}
			}

			Console.WriteLine($"Deletions and Insertions: {dp[first.Length, second.Length]}");

		}
	}
}