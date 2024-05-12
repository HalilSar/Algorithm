using System;
using System.Collections.Generic;

namespace Algorithm.Graph.PrimMST
{
    class Program
    {
        private int V;
        private List<List<int>> graph;

        public Program(int v)
        {
            V = v;
            graph = new List<List<int>>(V);
            for (int i = 0; i < V; ++i)
            {
                graph.Add(new List<int>());
            }
        }

        
        public void AddEdge(int u, int v, int weight)
        {
            graph[u].Add(weight);
            graph[v].Add(weight);
        }

       
        public void Prim()
        {
            bool[] visited = new bool[V];
            int[] parent = new int[V];
            int[] key = new int[V];

            for (int i = 0; i < V; ++i)
            {
                key[i] = int.MaxValue;
                visited[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V - 1; ++count)
            {
                int u = MinKey(key, visited);
                visited[u] = true;

                for (int v = 0; v < V; ++v)
                {
                    if (graph[u][v] != 0 && !visited[v] && graph[u][v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u][v];
                    }
                }
            }

            PrintMST(parent);
        }

       
        private int MinKey(int[] key, bool[] visited)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < V; ++v)
            {
                if (!visited[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        
        private void PrintMST(int[] parent)
        {
            Console.WriteLine("Prim's Minimum Spanning Tree:");
            for (int i = 1; i < V; ++i)
            {
                Console.WriteLine("Edge: " + parent[i] + " - " + i);
            }
        }

        
        public static void Main(string[] args)
        {
            int V = 5; 

            Program graph = new Program(V);

            
            graph.AddEdge(0, 1, 2);
            graph.AddEdge(0, 3, 6);
            graph.AddEdge(1, 2, 3);
            graph.AddEdge(1, 3, 8);
            graph.AddEdge(1, 4, 5);
            graph.AddEdge(2, 4, 7);
            graph.AddEdge(3, 4, 9);

            graph.Prim();
        }
    }
}
