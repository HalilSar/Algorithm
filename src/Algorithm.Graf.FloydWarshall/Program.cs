using System;

namespace Algorithm.Graph.FloydWarshall
{
    class Program
    {
        private static int INF = int.MaxValue;

        
        public static void ShortestPath(int[,] graph, int V)
        {
            int[,] dist = new int[V, V];

            
            for (int i = 0; i < V; ++i)
            {
                for (int j = 0; j < V; ++j)
                {
                    dist[i, j] = graph[i, j];
                }
            }

           
            for (int k = 0; k < V; ++k)
            {
                for (int i = 0; i < V; ++i)
                {
                    for (int j = 0; j < V; ++j)
                    {
                        if (dist[i, k] != INF && dist[k, j] != INF && dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            PrintSolution(dist, V);
        }


        private static void PrintSolution(int[,] dist, int V)
        {
            Console.WriteLine("Floyd-Warshall Shortest Paths:");
            for (int i = 0; i < V; ++i)
            {
                for (int j = 0; j < V; ++j)
                {
                    if (dist[i, j] == INF)
                    {
                        Console.Write("INF ");
                    }
                    else
                    {
                        Console.Write(dist[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }


        public static void Main(string[] args)
        {
            int V = 4; 
            int[,] graph = { {0, 5, INF, 10},
                         {INF, 0, 3, INF},
                         {INF, INF, 0, 1},
                         {INF, INF, INF, 0} };

            ShortestPath(graph, V);
        }
    }
}
