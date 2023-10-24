using System;
using System.Collections.Generic;

namespace _06._8_Queens_Puzzle
{
    internal class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            var board = new bool[8, 8];
            PutQueen(board, 0);
        }

        private static void PutQueen(bool[,] board, int index)
        {
            if (index >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }
            for (int i = 0; i < board.GetLength(1); i++)
            {
                if (CanPlaceQueen(index, i))
                {
                    attackedRows.Add(index);
                    attackedCols.Add(i);
                    attackedLeftDiagonals.Add(index - i);
                    attackedRightDiagonals.Add(index + i);
                    board[index, i] = true;

                    PutQueen(board, index + 1);

                    attackedRows.Remove(index);
                    attackedCols.Remove(i);
                    attackedLeftDiagonals.Remove(index - i);
                    attackedRightDiagonals.Remove(index + i);
                    board[index, i] = false;
                }
            }


        }

        private static void PrintBoard(bool[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i,j])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static bool CanPlaceQueen(int index, int i)
        {
            return !attackedRows.Contains(index) && !attackedCols.Contains(i) && !attackedLeftDiagonals.Contains(index-i) && !attackedRightDiagonals.Contains(index+ i);
        }
    }
}
