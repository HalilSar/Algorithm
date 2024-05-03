using System;
using System.Collections.Generic;

namespace Algorithm.Graph.DepthFirstSearch
{
    class Graph
    {
        private int V; 
        private List<int>[] adj; 

        public Graph(int v)
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

        
        private void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write(v + " ");

            foreach (int i in adj[v])
            {
                if (!visited[i])
                {
                    DFSUtil(i, visited);
                }
            }
        }

        
        public void DFS(int v)
        {
            bool[] visited = new bool[V];
            DFSUtil(v, visited);
        }

         
        public static void Main(string[] args)
        {
            Graph graph = new Graph(4);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            Console.WriteLine("Depth First Traversal starting from vertex 2:");
            graph.DFS(2);
        }
    }
}
