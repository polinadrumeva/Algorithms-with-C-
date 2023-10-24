using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Connected_Components
{
    internal class Program
    {
        static bool[] visited;
        static List<int>[] graph;

        static void Main(string[] args)
        {
            graph = ReadGraph();
            FindGraphConnectedComponents();
            //visited = new bool[graph.Length];
            ////DFS(0);

            ////Console.WriteLine();
        }

        private static void DFS(int vertex)
        {
            if (!visited[vertex])
            {
                visited[vertex] = true;
                foreach (var child in graph[vertex])
                {
                    DFS(child);
                }

                Console.Write(" " + vertex);
            }
        }

        private static void FindGraphConnectedComponents()
        {
            visited = new bool[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                if (!visited[i])
                {
                    Console.Write("Connected component:");
                    DFS(i);
                    Console.WriteLine();
                }
            }
        }

        private static List<int>[] ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            }

            return graph;
        }
    }
}
