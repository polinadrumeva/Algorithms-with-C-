using System;
using System.Collections.Generic;


namespace _01.Bitcoin_Miners___Second
{
    internal class Program
    {

        //Second way
        private static Dictionary<string, long> cache;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());

            cache = new Dictionary<string, long>();

            var result = SelectionTransactions(n, x);
            Console.WriteLine(result);
        }

        private static long SelectionTransactions(int n, int x)
        {
            if (x == 0 || n == x)
            {
                return 1;
            }

            var id = $"{n} {x}";
            if (cache.ContainsKey(id))
            {
                return cache[id];
            }

            var result = SelectionTransactions(n - 1, x - 1) + SelectionTransactions(n - 1, x);
            cache[id] = result;

            return result;
        }
    }
}