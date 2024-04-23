using System;
using System.Collections.Generic;

namespace Algorithm.Graf.BreadthFirstSearch
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

        
        public void BFS(int s)
        {
            bool[] visited = new bool[V];
            Queue<int> queue = new Queue<int>();

            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                s = queue.Dequeue();
                Console.Write(s + " ");

                foreach (int i in adj[s])
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }
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

            Console.WriteLine("Breadth First Traversal starting from vertex 2:");
            graph.BFS(2);
        }
    }
}
