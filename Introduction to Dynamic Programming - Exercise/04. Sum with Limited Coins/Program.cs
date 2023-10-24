using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Sum_with_Limited_Coins
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
			var set = new HashSet<int> { 0 };
			var count = 0;

			foreach (var num in numbers)
			{
				var newSums = new HashSet<int>();
                foreach (var sum in set)
                {
					var newSum = sum + num;
					if (newSum == targetSum)
					{
						count++;
					}

					newSums.Add(newSum);
                }

				set.UnionWith(newSums);
            }

			return count;
		}
           
	}
}