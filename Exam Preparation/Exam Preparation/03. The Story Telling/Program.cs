using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Story_Telling
{
	internal class Program
	{
		private static Dictionary<string, List<string>> graph;
		private static HashSet<string> visited;
		static void Main(string[] args)
		{
			ReadGraph();
			visited = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
				DFS(node);
            }

            Console.WriteLine(string.Join(" ", visited.Reverse()));

        }

		private static void ReadGraph()
		{
			graph = new Dictionary<string, List<string>>();

			string command;
			while ((command = Console.ReadLine()) != "End")
			{
				var line = command.Split("->", StringSplitOptions.RemoveEmptyEntries);
				var node = line[0].Trim();

				if (!graph.ContainsKey(node))
				{
					graph[node] = new List<string>();
				}

				if (line.Length < 2)
				{
					continue;
				}

				var children = line[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
				graph[node].AddRange(children);
			}
		}

		private static void DFS(string node)
		{
			if (visited.Contains(node))
			{
				return;
			}

			foreach (var child in graph[node])
			{
				DFS(child);
			}

			visited.Add(node);
		}
	}
}