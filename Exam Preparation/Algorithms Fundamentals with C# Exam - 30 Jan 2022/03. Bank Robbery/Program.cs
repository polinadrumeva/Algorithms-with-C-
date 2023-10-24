using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Bank_Robbery
{
	public class Program
	{
		static void Main(string[] args)
		{
			var boxes = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			var allSums = GenAllSum(boxes);

			var totalSum = boxes.Sum();
			var half = totalSum / 2;

			var boxesJosh = FindSubsetForJosh(allSums, half, boxes);
			Console.WriteLine(string.Join(" ", boxesJosh.OrderBy(x=> x)));
			var sumPrakash = totalSum - half;
			//var boxesPrakash = FindSubsetForPrakash(boxes, boxesJosh);
			Console.WriteLine(string.Join(" ", boxes.OrderBy(x=>x)));

		}

		//private static List<int> FindSubsetForPrakash(List<int> boxes, List<int> boxesJosh)
		//{
		//	var subset = boxes;

		//	for (int i = 0; i < subset.Count; i++)
		//	{
		//		for (int k = 0; k < boxesJosh.Count(); k++)
		//		{
		//			if (subset[i] == boxesJosh[k])
		//			{ 
					
		//				subset.Remove(boxes[i]);
		//				i--;
		//			}
		//		}
		//	}

		//	return subset;
		//}

		private static List<int> FindSubsetForJosh(Dictionary<int, int> allSums, int half, List<int> boxes)
		{
			var subset = new List<int>();

			while (half != 0)
			{
				var element = allSums[half];
				subset.Add(element);

				half -= element;
				boxes.Remove(element);

			}

			return subset;
		}

		private static Dictionary<int, int> GenAllSum(List<int> boxes)
		{
			var sums = new Dictionary<int, int> { { 0, 0 } };
			foreach (var box in boxes)
			{
				var currentSum = sums.Keys.ToArray();
				foreach (var sum in currentSum)
				{
					var newSum = sum + box;

					if (sums.ContainsKey(newSum))
					{
						continue;
					}

					sums.Add(newSum, box);
				}
			}

			return sums;
		}
	}
}

