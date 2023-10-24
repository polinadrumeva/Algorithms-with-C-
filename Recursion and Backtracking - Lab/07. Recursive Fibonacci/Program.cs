using System;

namespace _07._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine(Fibonacci(number));

        }

        private static int Fibonacci(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }
    }
}
