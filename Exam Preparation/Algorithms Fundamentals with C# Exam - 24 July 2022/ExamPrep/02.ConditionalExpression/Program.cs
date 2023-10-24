using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.ConditionalExpression
{
	public class Program
	{
		public static void Main()
		{
			var expression = Console.ReadLine().Split().Select(x=> x[0]).ToArray();
			Console.WriteLine(CalculateExpression(expression, 0));
		}

		public static int CalculateExpression(char[] expression, int idx)
		{
			if (char.IsDigit(expression[idx]))
			{
				return expression[idx] - '0';
			}

			if (expression[idx] == 't')
			{
				return CalculateExpression(expression, idx + 2);
			}

			var foundCondition = 0;
			for (int i = idx + 2; i < expression.Length; i++)
			{
				var curentChar = expression[i];
				if (curentChar == '?')
				{
					foundCondition++;
				}
				else if (curentChar == ':')
				{
					foundCondition--;
					if (foundCondition < 0)
					{
						return CalculateExpression(expression, i + 1);
					}
				}

			}

			return -1;
		}
	}
}