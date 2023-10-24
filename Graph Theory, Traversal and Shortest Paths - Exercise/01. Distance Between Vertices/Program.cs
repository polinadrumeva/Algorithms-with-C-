using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Distance_Between_Vertices
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
           var nodes =int.Parse(Console.ReadLine());
           var pairs = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodes; i++)
            {
                var array = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);
                var node = int.Parse(array[0]);

                if (array.Length == 1)
                {
                    graph[node] = new List<int>();
                }
                else
                {
					var children = array[1].Split().Select(int.Parse).ToList();

					graph[node] = children;
				}
              
            }

            for (int i = 0; i < pairs; i++)
            {
                var pair = Console.ReadLine().Split("-").Select(int.Parse).ToArray();
                var start = pair[0];
                var end = pair[1];

                var steps = BFS(start, end);
                Console.WriteLine($"{{{start}, {end}}} -> {steps}");
            }
        }

		private static int BFS(int start, int end)
		{
			var queue = new Queue<int>();
            queue.Enqueue(start);

            var visited = new HashSet<int> { start };
            var parent = new Dictionary<int, int> { { start, -1 } };

            while (queue.Count > 0)
            {
				var node = queue.Dequeue();

				if (node == end)
                {
					return GetSteps(parent, end);
				}

				foreach (var child in graph[node])
                {
					if (!visited.Contains(child))
                    {
						queue.Enqueue(child);
						visited.Add(child);
                        parent[child] = node;
					}
				}
			}

            return -1;
		}

		private static int GetSteps(Dictionary<int, int> parent, int end)
		{
            var steps = 0;
            var node = end;

            while (node != -1)
            {
                node = parent[node];
                steps++;
            }

            return steps - 1;
		}
	}
}