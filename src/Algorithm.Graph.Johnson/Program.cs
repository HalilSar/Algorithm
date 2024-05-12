using System;

namespace Algorithm.Graph.Johnson
{
    class Program
    {
        private static int INF = int.MaxValue / 2;

       
        private static bool BellmanFord(int[,] graph, int V, int src, int[] dist)
        {
            for (int i = 0; i < V; ++i)
            {
                dist[i] = INF;
            }
            dist[src] = 0;

            for (int i = 0; i < V - 1; ++i)
            {
                for (int u = 0; u < V; ++u)
                {
                    for (int v = 0; v < V; ++v)
                    {
                        if (dist[u] != INF && graph[u, v] != INF && dist[u] + graph[u, v] < dist[v])
                        {
                            dist[v] = dist[u] + graph[u, v];
                        }
                    }
                }
            }

            for (int u = 0; u < V; ++u)
            {
                for (int v = 0; v < V; ++v)
                {
                    if (dist[u] != INF && graph[u, v] != INF && dist[u] + graph[u, v] < dist[v])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

       
        private static void Dijkstra(int[,] graph, int src, int[] dist)
        {
            int V = graph.GetLength(0);
            bool[] visited = new bool[V];
            Array.Fill(dist, INF);

            dist[src] = 0;

            for (int count = 0; count < V - 1; ++count)
            {
                int u = -1;
                for (int v = 0; v < V; ++v)
                {
                    if (!visited[v] && (u == -1 || dist[v] < dist[u]))
                    {
                        u = v;
                    }
                }

                visited[u] = true;

                for (int v = 0; v < V; ++v)
                {
                    if (!visited[v] && graph[u, v] != INF && dist[u] + graph[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }
                }
            }
        }


        public static void ShortestPaths(int[,] graph)
        {
            int V = graph.GetLength(0);
            int[] h = new int[V];
            int[] dist = new int[V];

            if (!BellmanFord(graph, V, V, h))
            {
                Console.WriteLine("Graph contains negative weight cycle");
                return;
            }

            for (int u = 0; u < V; ++u)
            {
                for (int v = 0; v < V; ++v)
                {
                    if (graph[u, v] != INF)
                    {
                        graph[u, v] += h[u] - h[v];
                    }
                }
            }

            for (int u = 0; u < V; ++u)
            {
                Dijkstra(graph, u, dist);
                for (int v = 0; v < V; ++v)
                {
                    if (dist[v] != INF)
                    {
                        dist[v] -= h[u] - h[v];
                    }
                }
                Console.Write("Shortest distances from vertex " + u + ": ");
                for (int i = 0; i < V; ++i)
                {
                    Console.Write(dist[i] + " ");
                }
                Console.WriteLine();
            }
        }


        public static void Main(string[] args)
        {
            int[,] graph = { {0, 5, INF, 10},
                         {INF, 0, 3, INF},
                         {INF, INF, 0, 1},
                         {INF, INF, INF, 0} };

            ShortestPaths(graph);
        }
    }
}
