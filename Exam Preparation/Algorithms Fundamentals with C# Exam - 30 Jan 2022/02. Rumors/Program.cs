using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _02._Rumors
{
	public class Program
	{
		private static Dictionary<int,List<int>> graph;
		private static Dictionary<int, int> people;
		private static HashSet<int> visited;
		public static void Main()
		{
			var n = int.Parse(Console.ReadLine());
			var e = int.Parse(Console.ReadLine());
			graph = new Dictionary<int, List<int>>();
			people = new Dictionary<int, int>();

			for (int i = 0; i < e; i++)
			{
				var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
				var from = line[0];
				var to = line[1];

				if (!graph.ContainsKey(from))
				{
					graph[from] = new List<int>();
				}

				graph[from].Add(to);
			}

			var person = int.Parse(Console.ReadLine());
			visited = new HashSet<int>();


			foreach (var node in graph.Keys)
			{
				DFS(node, people);
			}

			foreach (var node in people)
			{
                Console.WriteLine($"{person} -> {node.Key} ({node.Value})");
            }
        }

		private static void DFS(int node, Dictionary<int, int> people)
		{
			var count = 0;

			if (visited.Contains(node))
			{
				people[node] = count;
				return;
			}

			visited.Add(node);
			count++;

			foreach (var child in graph[node])
			{
				DFS(child, people);
			}
		}
	}
}
