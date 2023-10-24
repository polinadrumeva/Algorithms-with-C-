using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01._Two_Minutes_to_Midnight
{
	internal class Program
	{ 
		static void Main(string[] args)
		{
			var items = int.Parse(Console.ReadLine());
			var k = int.Parse(Console.ReadLine());

			var result = GetFactorial(items) / (GetFactorial(k) * GetFactorial(items - k));
            Console.WriteLine(result);

        }

		private static BigInteger GetFactorial(int items)
		{
			BigInteger factorial = 1;

			for (int i = 2; i <= items; i++)
			{
				factorial *= i;
			}

			return factorial;
		}
	}
}