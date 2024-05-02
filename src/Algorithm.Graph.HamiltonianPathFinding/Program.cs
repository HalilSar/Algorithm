using System;
using System.Collections.Generic;
namespace Algorithm.Graph.HamiltonianPathFinding
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
            adj[w].Add(v); 
        }

       
        private bool IsHamiltonianUtil(int v, bool[] visited, List<int> path)
        {
            visited[v] = true;
            path.Add(v);

  
            if (path.Count == V)
            {
                return true;
            }

  
            foreach (int u in adj[v])
            {
                if (!visited[u])
                {
                    if (IsHamiltonianUtil(u, visited, path))
                    {
                        return true;
                    }
                }
            }

     
            visited[v] = false;
            path.RemoveAt(path.Count - 1);

            return false;
        }

  
        public bool HasHamiltonianPath()
        {
            bool[] visited = new bool[V];
            List<int> path = new List<int>();

          
            for (int i = 0; i < V; ++i)
            {
                Array.Fill(visited, false);
                path.Clear();

                if (IsHamiltonianUtil(i, visited, path))
                {
                    return true;
                }
            }

            return false;
        }

        
        public static void Main(string[] args)
        {
            Program graph = new Program(5);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            if (graph.HasHamiltonianPath())
            {
                Console.WriteLine("The graph contains the  Hamilton path");
            }
            else
            {
                Console.WriteLine("The graph does not contain the  Hamilton path");
            }
        }
    }
}
