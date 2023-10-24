using System;
using System.Collections.Generic;

namespace _06._Word_Cruncher
{
    public class Program
    {
        private static Dictionary<int, List<string>> wordsIndex;
        private static Dictionary<string, int> wordsCount;
        private static LinkedList<string> used;
        private static string target;
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();

            wordsIndex = new Dictionary<int, List<string>>();
            wordsCount = new Dictionary<string, int>();
            used = new LinkedList<string>();

            foreach (var word in words) 
            {
                var index = target.IndexOf(word);

                if (index == -1) 
                {
                    continue;
                }

                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                    continue;
                }

                wordsCount[word] = 1;

                while (index != -1)
                {
                    if (wordsIndex.ContainsKey(index))
                    {
                        wordsIndex[index] = new List<string>();
                    }

                    wordsIndex[index].Add(word);

                    index = target.IndexOf(word, index + 1);
                }
            }

            GenSolutions(0);
        }

        private static void GenSolutions(int idx)
        {
            if (idx == target.Length)
            {
                Console.WriteLine(string.Join(" ", used));
                return;
            }
            if (!wordsIndex.ContainsKey(idx))
            {
                return;
            }

            foreach (var word in wordsIndex[idx])
            {
                if (wordsCount[word] == 0)
                {
                    continue;
                }

                wordsCount[word]--;
                used.AddLast(word);

                GenSolutions(idx + word.Length);

                wordsCount[word]++;
                used.RemoveLast();

            }
        }
    }
}