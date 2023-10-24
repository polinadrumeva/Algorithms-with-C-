namespace _04._Cinema
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        // With algorithm for permutation

        private static List<string> people;
        private static string[] personsWithSeats;
        private static bool[] lockedSeats;
        static void Main(string[] args)
        {
            people = Console.ReadLine().Split(", ").ToList();
            personsWithSeats = new string[people.Count];
            lockedSeats = new bool[people.Count];

            while (true)
            { 
                var line = Console.ReadLine();

                if (line == "generate")
                {
                    break;
                }

                var parts = line.Split(" - ");
                var name = parts[0];
                var position = int.Parse(parts[1]) - 1;

                personsWithSeats[position] = name;
                lockedSeats[position] = true;

                people.Remove(name);
            }

            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= people.Count)
            {
                PrintVariation();
                return;
            }
            
            Permute(index + 1);

            for (int i = index + 1; i < people.Count; i++)
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
            }
        }

        private static void PrintVariation()
        {
            var personIndex = 0;
            for (int i = 0; i < personsWithSeats.Length; i++)
            {
                if (i == personsWithSeats.Length - 1)
                {
                    if (lockedSeats[i])
                    {
                        Console.Write($"{personsWithSeats[i]}");
                    }
                    else
                    {
                        Console.Write($"{people[personIndex++]}");
                    }
                }
                else
                {
                    if (lockedSeats[i])
                    {
                        Console.Write($"{personsWithSeats[i]} ");
                    }
                    else
                    {
                        Console.Write($"{people[personIndex++]} ");
                    }
                }
                
            }

            Console.WriteLine();
        }

        private static void Swap(int first, int second)
        {
            var temp = people[first];
            people[first] = people[second];
            people[second] = temp;
        }
    }
}