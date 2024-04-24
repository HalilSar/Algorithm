using System;
using System.Collections.Generic;
namespace Algorithm.Graf.BellMan
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
        }
    }
}
