using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace _03._Bitcoin_Transactions
{
    internal class Program
    {

        private static Stack<string> sequence;

        static void Main(string[] args)
        {
            var first = Console.ReadLine().Split();
            var second = Console.ReadLine().Split();

            var array = new int[first.Length + 1, second.Length + 1];

            for (int r = 1; r < array.GetLength(0); r++)
            {
                for (int c = 1; c < array.GetLength(1); c++)
                {
                    if (first[r - 1] == second[c - 1])
                    {
                        array[r, c] = array[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        array[r, c] = Math.Max(array[r, c - 1], array[r - 1, c]);
                    }
                }
            }

            //for (int i = 0; i < array.GetLength(0); i++)
            //{
            //    for (int k = 0; k < array.GetLength(1); k++)
            //    {
            //        Console.Write($"{array[i,k]}");

            //    }

            //    Console.WriteLine();
            //}

            var row = first.Length;
            var col = second.Length;

            var result = PrintSequence(row, col, first, second, array);
            Console.WriteLine($"[{string.Join(" ", sequence)}]");
        }

        private static Stack<string> PrintSequence(int row, int col, string[] first, string[] second, int[,] array)
        {
            sequence = new Stack<string>();

            while (row > 0 && col > 0)
            {
                if (first[row - 1] == second[col - 1])
                {
                    sequence.Push(first[row - 1]);
                    row--;
                    col--;
                }
                else if (array[row - 1, col] >= array[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }

            return sequence;
        }
    }
}