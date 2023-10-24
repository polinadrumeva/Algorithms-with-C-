using System.Linq;
using System.Collections.Generic;
using System;
using System.ComponentModel.Design;

namespace _04._Salaries
{
    internal class Program
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> visited;
        static void Main(string[] args)
        {
           var n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new Dictionary<int, int>();

            for (int  node = 0;  node <n;  node++)
            {
                graph[node] = new List<int>();

                var elements = Console.ReadLine();

                for (int child = 0; child < elements.Length; child++)
                {
					if (elements[child] == 'Y')
                    {
                        graph[node].Add(child);
					}
				}
            }

            var salaries = 0;

            for (int i = 0; i < graph.Length; i++)
            {
                salaries += DFS(i);
            }

            Console.WriteLine(salaries);
        }

		private static int DFS(int node)
		{
            if (visited.ContainsKey(node))
            {
                return visited[node];
            }
			var salaries = 0;

            if (graph[node].Count == 0)
            {
                salaries = 1;
            }
            else
            {
				foreach (var child in graph[node])
				{
					salaries += DFS(child);
				}
			}

            visited[node] = salaries;

            return salaries;
		}
	}
}