using System;
using System.Collections.Generic;

namespace _01._Fibonacci
{
	internal class Program
	{
		private static Dictionary<int, long> memo;
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());
			memo = new Dictionary<int, long>();
			
			Console.WriteLine(Fibonacci(n));
		}

		private static long Fibonacci(int n)
		{
			if (memo.ContainsKey(n))
			{
				return memo[n];
			}

			if (n == 0)
			{
				return 0;
			}

			if (n == 1)
			{
				return 1;
			}

			var result = Fibonacci(n - 1) + Fibonacci(n - 2);
			memo[n] = result;

			return result;
		}
	}
		
}
