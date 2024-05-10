using System;
using System.Collections.Generic;
namespace Algorithm.Graphic.MaximumFlow
{
    class Program
    {
        private int V; 

        public Program(int v)
        {
            V = v;
        }

        
        private bool BFS(int[,] rGraph, int s, int t, int[] parent)
        {
            bool[] visited = new bool[V];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;
            parent[s] = -1;

            while (queue.Count != 0)
            {
                int u = queue.Dequeue();

                for (int v = 0; v < V; v++)
                {
                    if (visited[v] == false && rGraph[u, v] > 0)
                    {
                        if (v == t)
                        {
                            parent[v] = u;
                            return true;
                        }
                        queue.Enqueue(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }

            return false;
        }

        public int FordFulkerson(int[,] graph, int s, int t)
        {
            int u, v;

            int[,] rGraph = new int[V, V];
            for (u = 0; u < V; u++)
            {
                for (v = 0; v < V; v++)
                {
                    rGraph[u, v] = graph[u, v];
                }
            }

            int[] parent = new int[V];
            int maxFlow = 0;

            while (BFS(rGraph, s, t, parent))
            {
                int pathFlow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    pathFlow = Math.Min(pathFlow, rGraph[u, v]);
                }

                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    rGraph[u, v] -= pathFlow;
                    rGraph[v, u] += pathFlow;
                }

                maxFlow += pathFlow;
            }

            return maxFlow;
        }

        public static void Main(string[] args)
        {
            int[,] graph = new int[,] { {0, 16, 13, 0, 0, 0},
                                    {0, 0, 10, 12, 0, 0},
                                    {0, 4, 0, 0, 14, 0},
                                    {0, 0, 9, 0, 0, 20},
                                    {0, 0, 0, 7, 0, 4},
                                    {0, 0, 0, 0, 0, 0} };

            Program m = new Program(6);

            Console.WriteLine("The maximum possible flow is " + m.FordFulkerson(graph, 0, 5));
        }
    }
}
