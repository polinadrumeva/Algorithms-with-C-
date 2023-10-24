using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Break_Cycles
{
    internal class Program
    {
        public class Edge
        {
			public string First { get; set; }
			public string Second { get; set; }

            public override string ToString()
            {
				return $"{First} - {Second}";
			}
		}

        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split(" -> ");
                var node = elements[0];
                var children = elements[1].Split().ToList();

                graph[node] = children;

                foreach (var child in children)
                {
                    edges.Add(new Edge
                    {
						First = node,
						Second = child
					});
                }
            }

            edges = edges.OrderBy(e => e.First).ThenBy(e => e.Second).ToList();
            var removedEdges = new List<Edge>();

            foreach (var edge in edges)
            {
                var removed = graph[edge.First].Remove(edge.Second) && graph[edge.Second].Remove(edge.First);

                if (!removed)
                {
                    continue;
                }

				if (HasPath(edge.First, edge.Second))
                {
					removedEdges.Add(edge);

				}
                else
                {
					graph[edge.First].Add(edge.Second);
					graph[edge.Second].Add(edge.First);
				}
			}

			Console.WriteLine($"Edges to remove: {removedEdges.Count}");

			foreach (var edge in removedEdges)
            {
				Console.WriteLine(edge);
            }
			

        }

		private static bool HasPath(string first, string second)
		{
			var queue = new Queue<string>();
            queue.Enqueue(first);
            var visited = new HashSet<string> { first };

            while (queue.Count > 0)
            {
				var node = queue.Dequeue();

				if (node == second)
                {
					return true;
				}

				foreach (var child in graph[node])
                {
					if (!visited.Contains(child))
                    {
						queue.Enqueue(child);
						visited.Add(child);
					}
				}
			}

            return false;
		}
	}
}