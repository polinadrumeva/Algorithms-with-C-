using System;
using System.Numerics;

namespace _01._Bitcoin_Miners
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());

            BigInteger p = SelectionTransactions(n) / (SelectionTransactions(x) * SelectionTransactions(n-x));
            Console.WriteLine(p);

        }

        private static BigInteger SelectionTransactions(int n)
        {
            BigInteger factorial = 1;

            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

    }
}