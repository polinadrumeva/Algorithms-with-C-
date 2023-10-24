using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Binomial_Coefficients
{
	class Program
	{
		private static Dictionary<string, long> memo;
		static void Main(string[] args)
		{
			int row = int.Parse(Console.ReadLine());
			int col = int.Parse(Console.ReadLine());
			memo = new Dictionary<string, long>();

            Console.WriteLine(BinomialCoefficient(row, col));
        }

		private static long BinomialCoefficient(int row, int col)
		{
			if (col == 0 || col == row)
			{
				return 1;
			}
			var key = $"{row}-{col}";
			if (memo.ContainsKey(key))
			{
				return memo[key];
			}
			
			var result = BinomialCoefficient(row -1, col-1) + BinomialCoefficient(row - 1, col);
			memo[key] = result;

			return result;
		}
	}
}