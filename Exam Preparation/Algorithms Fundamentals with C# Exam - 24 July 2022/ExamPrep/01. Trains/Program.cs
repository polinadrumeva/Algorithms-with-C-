using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Train
{
	public class Program
	{
		public static void Main()
		{
			var arrivals = Console.ReadLine().Split().Select(double.Parse).OrderBy(n => n).ToArray();
			var departs = Console.ReadLine().Split().Select(double.Parse).OrderBy(n => n).ToArray();

            Console.WriteLine(FindPlatforms(arrivals, departs));
        }

		private static int FindPlatforms(double[] arrivals, double[] departs)
		{
			var result = 0;
			var platforms = 0;
			var arrivalIndex = 0;
			var departIndex = 0;

			while (arrivalIndex < arrivals.Length)
			{
				var arrivalTime = arrivals[arrivalIndex];
				var departTime = departs[departIndex];

				if (arrivalTime < departTime)
				{
					platforms++;
					arrivalIndex++;
					result = Math.Max(result, platforms);
				}
				else
				{
					departIndex++;
					platforms--;
				}
			}

			return result;
		}
	}
}