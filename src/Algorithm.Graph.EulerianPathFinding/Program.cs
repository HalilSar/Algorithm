using System;
using System.Collections.Generic;
namespace Algorithm.Graph.EulerianPathFinding
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

      
        private int Degree(int v)
        {
            return adj[v].Count;
        }

       
        private bool CheckDegree()
        {
            for (int i = 0; i < V; ++i)
            {
                if (Degree(i) % 2 != 0)
                {
                    return false; 
                }
            }
            return true;
        }

        
        private void DFS(int v, bool[] visited)
        {
            visited[v] = true;

            foreach (int u in adj[v])
            {
                if (!visited[u])
                {
                    DFS(u, visited);
                }
            }
        }

       
        public bool HasEulerianPath()
        {
            if (!CheckDegree())
            {
                return false; 
            }

            bool[] visited = new bool[V];
            int oddDegreeCount = 0;

            for (int i = 0; i < V; ++i)
            {
                if (Degree(i) % 2 != 0)
                {
                    oddDegreeCount++;
                }
            }

         
            return oddDegreeCount == 0 || oddDegreeCount == 2;
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

            if (graph.HasEulerianPath())
            {
                Console.WriteLine("The graph contains the Euler path");
            }
            else
            {
                Console.WriteLine("The graph doesn't contain the Euler path");
            }
        }
    }
}
