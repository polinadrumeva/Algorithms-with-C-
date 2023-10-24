using System;

namespace _07._N_Choose_K_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetTriangle(n,k));
        }

        private static int GetTriangle(int n, int k)
        {
            if (n <= 1 || k == 0 || n == k)
            {
                return 1;
            }

            return GetTriangle(n-1, k) + GetTriangle(n-1, k-1);
        }
    }
}
