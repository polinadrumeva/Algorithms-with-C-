using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Connecting_Cables
{
	class Program
	{
		static void Main(string[] args)
		{
			var cables = Console.ReadLine().Split().Select(int.Parse).ToArray();

			var positions = Enumerable.Range(1, cables.Length).ToArray();
			var dp = new int[cables.Length + 1, positions.Length + 1];

			for (int row = 1; row < dp.GetLength(0); row++)
			{
				for (int col = 1; col < dp.GetLength(1); col++)
				{
					if (cables[row-1] == positions[col-1])
					{
						dp[row, col] = dp[row - 1, col - 1] + 1;
					}
					else
					{
						dp[row, col] = Math.Max(dp[row - 1, col], dp[row, col - 1]);
					}

				}
			}

			Console.WriteLine($"Maximum pairs connected: {dp[cables.Length, positions.Length]}");

		}
	}
}