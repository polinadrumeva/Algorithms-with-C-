﻿using System;
using System.Collections.Generic;

namespace _02._Longest_Common_Subsequence
{
	internal class Program
	{

		static void Main(string[] args)
		{
			var first = Console.ReadLine();
			var second = Console.ReadLine();

			var lcs = new int[first.Length + 1, second.Length + 1];

			for (int r = 1; r < lcs.GetLength(0); r++)
			{
				for (int c = 1; c < lcs.GetLength(1); c++)
				{
					if (first[r-1] == second[c-1])
					{
						lcs[r, c] = lcs[r-1, c-1] + 1;
					}
					else
					{
						lcs[r,c] = Math.Max(lcs[r, c-1], lcs[r-1, c]);
					}
				}
			}

			Console.WriteLine(lcs[first.Length, second.Length]);

        }


	}

}
