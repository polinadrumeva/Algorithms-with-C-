using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace _03._Guards
{
	public class Program
	{
		private static List<int>[] graph;
		private static bool[] visited;

		public static void Main()
		{
			var nodes = int.Parse(Console.ReadLine());
			var edges = int.Parse(Console.ReadLine());

			graph = new List<int>[nodes + 1];
			visited = new bool[nodes + 1];

			for (int i = 0; i < graph.Length; i++)
			{
				graph[i] = new List<int>();
			}

			for (int i = 0; i < edges; i++)
			{
				var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
				var from = edge[0];
				var to = edge[1];

				graph[from].Add(to);
			}

			var start = int.Parse(Console.ReadLine());

			DFS(start);

			var sb = new StringBuilder();
			for (int i = 1; i < visited.Length; i++)
			{
				if (!visited[i])
				{
					sb.Append($"{i} ");
				}
			}

			Console.WriteLine(sb.ToString().Trim());
		}

		private static void DFS(int start)
		{
			if (visited[start])
			{
				return;
			}

			visited[start] = true;
			foreach (var child in graph[start])
			{
				DFS(child);
			}
		}
	}
}