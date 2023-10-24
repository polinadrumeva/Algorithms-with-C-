using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace _02._Dividing_Presents
{
	class Program
	{
		static void Main(string[] args)
		{
			var presents = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			var allSums = GenAllSum(presents);

			var totalSum = presents.Sum();
			var half = totalSum / 2;

			while (true)
			{
				if (allSums.ContainsKey(half))
				{
					var alanPresents = FindSubset(allSums, half);

					var bobSum = totalSum - half;
                    Console.WriteLine($"Difference: {bobSum-half}");
                    Console.WriteLine($"Alan:{half} Bob:{bobSum}");
                    Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
                    Console.WriteLine("Bob takes the rest.");

                    break;
				}

				half--;
			}

		}

		private static List<int> FindSubset(Dictionary<int, int> allSums, int half)
		{
			var subset = new List<int>();

			while (half != 0)
			{
				var element = allSums[half];
				subset.Add(element);

				half -= element;
			}

			return subset;
		}

		private static Dictionary<int, int> GenAllSum(int[] presents)
		{
			var sums= new Dictionary<int, int> { { 0, 0 } };
			foreach ( var present in presents) 
			{
				var currentSum = sums.Keys.ToArray();
				foreach (var sum in currentSum)
				{
					var newSum = sum + present;

					if (sums.ContainsKey(newSum))
					{
						continue;
					}

					sums.Add(newSum, present);
				}
			}

			return sums;
		}
	}
}