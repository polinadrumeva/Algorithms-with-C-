using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _02._Chainalysis
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                var from = line[0];
                var to = line[1];
                var amount = line[2];

                if (!graph.ContainsKey(from))
                {
                    graph[from] = new List<string>();
                }

                if (!graph.ContainsKey(to))
                {
                    graph[to] = new List<string>();
                }

                graph[from].Add($"{to} {amount}");
            }

            var count = 0;

            foreach (var node in graph.Keys)
            {
                DFS(node);

                if (visited.Contains(node))
                {
                    count++;
                }
            }


            Console.WriteLine(count - n);

        }

        private static void DFS(string node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                var childArgs = child.Split();
                var childNode = childArgs[0];

                DFS(childNode);
            }

        }
    }
}