using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._String_Mashup
{
	public class Program
	{
		public static void Main()
		{ 
			var str = Console.ReadLine();
			var charArray = str.OrderBy(x=> x).ToArray();
			var n = int.Parse(Console.ReadLine());

			var combinations = new string[n];

			GetCombinations(0, 0, charArray, combinations);

        }

		private static void GetCombinations(int idx, int start, char[] charArray, string[] combinations)
		{
			if (idx == combinations.Length)
			{
                Console.WriteLine(string.Join("",combinations));
                return;
            }

			for (int i = start; i < charArray.Length; i++)
			{
				combinations[idx] = charArray[i].ToString();
				GetCombinations(idx + 1, i, charArray, combinations);
			}

			
		}
	}
}
