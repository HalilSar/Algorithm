using System;
using System.Collections.Generic;
namespace Algorithm.Graf.Dijkstra
{
    class Program
    {
        private int V; 
        private List<Tuple<int, int>>[] adj;

        public Program(int v)
        {
            V = v;
            adj = new List<Tuple<int, int>>[V];
            for (int i = 0; i < V; ++i)
            {
                adj[i] = new List<Tuple<int, int>>();
            }
        }

        public void AddEdge(int u, int v, int weight)
        {
            adj[u].Add(new Tuple<int, int>(v, weight));
        }

   
        public void Dijkstra(int src)
        {
            int[] dist = new int[V];
            for (int i = 0; i < V; ++i)
            {
                dist[i] = int.MaxValue;
            }
            dist[src] = 0;

            SortedSet<Tuple<int, int>> pq = new SortedSet<Tuple<int, int>>();
            pq.Add(new Tuple<int, int>(0, src));

            while (pq.Count != 0)
            {
                Tuple<int, int> tuple = pq.Min;
                pq.Remove(tuple);

                int u = tuple.Item2;

                foreach (var item in adj[u])
                {
                    int v = item.Item1;
                    int weight = item.Item2;

                    if (dist[u] != int.MaxValue && dist[v] > dist[u] + weight)
                    {
                        pq.Remove(new Tuple<int, int>(dist[v], v));
                        dist[v] = dist[u] + weight;
                        pq.Add(new Tuple<int, int>(dist[v], v));
                    }
                }
            }

            Console.WriteLine("Dijkstra Shortest Path:");
            PrintSolution(dist);
        }

        private void PrintSolution(int[] dist)
        {
            for (int i = 0; i < V; ++i)
            {
                Console.WriteLine("Node " + i + ": Distance from source = " + dist[i]);
            }

        }

        static void Main(string[] args)
        {
            Program graph = new Program(5);
            graph.AddEdge(0, 1, 10);
            graph.AddEdge(0, 2, 5);
            graph.AddEdge(1, 2, 2);
            graph.AddEdge(1, 3, 1);
            graph.AddEdge(2, 1, 3);
            graph.AddEdge(2, 3, 9);
            graph.AddEdge(2, 4, 2);
            graph.AddEdge(3, 4, 4);
            graph.AddEdge(4, 0, 7);
            graph.AddEdge(4, 3, 6);

            graph.Dijkstra(0);
        }
    }
}
