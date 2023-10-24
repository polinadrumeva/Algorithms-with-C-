using System;
using System.Collections.Generic;

namespace _SubsetSum
{
	internal class Program
	{

		static void Main(string[] args)
		{
			var nums = new int[] { 3, 5, 1, 4, 2, 9, 6 };
			var target = 10;

			var possibleSums = GetAllPossibleSums(nums);
            Console.WriteLine(string.Join(" ", possibleSums));
            Console.WriteLine(possibleSums.Contains(target));
        }

		private static HashSet<int> GetAllPossibleSums(int[] nums)
		{
			var sums = new HashSet<int> { 0 };
			foreach (var num in nums) 
			{
				 var newSums = new HashSet<int>();
				foreach (var sum in sums)
				{
					newSums.Add(sum + num);
				}

				sums.UnionWith(newSums);
			}

			return sums;
		}
	}

}
