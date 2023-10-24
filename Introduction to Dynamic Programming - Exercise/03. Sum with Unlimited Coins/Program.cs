using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Sum_with_Unlimited_Coins
{
	class Program
	{
		static void Main(string[] args)
		{
			var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
			var targetSum = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcComb(numbers, targetSum));
        }

		private static int CalcComb(int[] numbers, int targetSum)
		{
			var sums = new int[targetSum + 1];
			sums[0] = 1;

			foreach (var num in numbers)
			{
				for (int i = num; i <= targetSum; i++)
				{
					sums[i] += sums[i - num];

				}
			}


			return sums[targetSum];

		}
	}
}