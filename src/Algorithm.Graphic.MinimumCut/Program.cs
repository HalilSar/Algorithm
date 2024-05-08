using System;
using System.Collections.Generic;
namespace Algorithm.Graphic.MinimumCut
{
    class Program
    {
        private int V; 
        private List<List<int>> adj;

        public Program(int v)
        {
            V = v;
            adj = new List<List<int>>();
            for (int i = 0; i < V; ++i)
            {
                adj.Add(new List<int>());
            }
        }

    
        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v); 
        }

    
        public int FindMinimumCut()
        {
            
            List<int>[] subsets = new List<int>[V];
            for (int i = 0; i < V; ++i)
            {
                subsets[i] = new List<int>();
                subsets[i].Add(i);
            }

           
            while (V > 2)
            {
              
                Random rand = new Random();
                int u = rand.Next(0, V);
                int v = adj[u][rand.Next(0, adj[u].Count)];

            
                int subset1 = FindSubset(subsets, u);
                int subset2 = FindSubset(subsets, v);

            
                foreach (int vertex in subsets[subset2])
                {
                    subsets[subset1].Add(vertex);
                }
                subsets[subset2] = new List<int>();

               
                for (int i = 0; i < V; ++i)
                {
                    for (int j = 0; j < adj[i].Count; ++j)
                    {
                        if (adj[i][j] == v)
                        {
                            adj[i].RemoveAt(j);
                        }
                    }
                }

               
                V--;
            }

            return adj[0].Count;
        }

      
        private int FindSubset(List<int>[] subsets, int vertex)
        {
            for (int i = 0; i < subsets.Length; ++i)
            {
                if (subsets[i].Contains(vertex))
                {
                    return i;
                }
            }
            return -1;
        }

      
        public static void Main(string[] args)
        {
            Program graph = new Program(4);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);

            Console.WriteLine("Minimum cut size: " + graph.FindMinimumCut());
        }
    }
}
