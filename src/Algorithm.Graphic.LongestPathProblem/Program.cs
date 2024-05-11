using System;
using System.Collections.Generic;
namespace Algorithm.Graphic.LongestPathProblem
{
    class Program
    {
        private int V;
        private List<int>[] adj; 

        public Program(int v)
        {
            V = v;
            adj = new List<int>[V];
            for (int i = 0; i < V; ++i)
            {
                adj[i] = new List<int>();
            }
        }

 
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
        }


        private int DFS(int v, bool[] visited, int[] dist)
        {
            visited[v] = true;
            int maxDist = 0;

            foreach (int u in adj[v])
            {
                if (!visited[u])
                {
                    maxDist = Math.Max(maxDist, DFS(u, visited, dist));
                }
            }

            dist[v] = maxDist + 1;
            return dist[v];
        }

        
        public int FindLongestPathLength()
        {
            bool[] visited = new bool[V];
            int[] dist = new int[V];
            int maxLength = int.MinValue;

            for (int i = 0; i < V; ++i)
            {
                if (!visited[i])
                {
                    maxLength = Math.Max(maxLength, DFS(i, visited, dist));
                }
            }

            return maxLength;
        }

       
        public static void Main(string[] args)
        {
            Program graph = new Program(6);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 5);

            Console.WriteLine("The length of the longest path is " + graph.FindLongestPathLength());
        }

    }
}
