using System;
using System.Collections.Generic;
namespace Algorithm.Graph.TopologicalSorting
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

        
        public void TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();
            bool[] visited = new bool[V];

            for (int i = 0; i < V; ++i)
            {
                if (!visited[i])
                {
                    TopologicalSortUtil(i, visited, stack);
                }
            }

            Console.WriteLine("Topological sorting of the graph:");
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }

        
        private void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack)
        {
            visited[v] = true;

            foreach (int i in adj[v])
            {
                if (!visited[i])
                {
                    TopologicalSortUtil(i, visited, stack);
                }
            }

            stack.Push(v);
        }

        
        public static void Main(string[] args)
        {
            Program graph = new Program(6);

            graph.AddEdge(5, 2);
            graph.AddEdge(5, 0);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);

            graph.TopologicalSort();
        }
    }
}
