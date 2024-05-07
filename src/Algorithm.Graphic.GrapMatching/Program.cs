using System;
using System.Collections.Generic;
namespace Algorithm.Graphic.GrapMatching
{
    class Program
    {
        private int N1;
        private int N2; 
        private List<int>[] adj; 
        private int[] pair; 
        private bool[] visited;

        public Program(int n1, int n2)
        {
            N1 = n1;
            N2 = n2;
            adj = new List<int>[N1];
            for (int i = 0; i < N1; ++i)
            {
                adj[i] = new List<int>();
            }
            pair = new int[N2];
            visited = new bool[N1];
        }

     
        public void AddEdge(int u, int v)
        {
            adj[u].Add(v);
        }

  
        private bool FindAugmentingPath(int u)
        {
            for (int i = 0; i < adj[u].Count; ++i)
            {
                int v = adj[u][i];
                if (!visited[v])
                {
                    visited[v] = true;
                    if (pair[v] == -1 || FindAugmentingPath(pair[v]))
                    {
                        pair[v] = u;
                        return true;
                    }
                }
            }
            return false;
        }


        public void MaximumMatching()
        {
            Array.Fill(pair, -1);
            int result = 0;
            for (int u = 0; u < N1; ++u)
            {
                Array.Fill(visited, false);
                if (FindAugmentingPath(u))
                {
                    result++;
                }
            }
            Console.WriteLine("Maksimum Düğüm Eşleşmesi: " + result);
        }

  
        public static void Main(string[] args)
        {
            Program graphMatching = new Program(3, 3);

            graphMatching.AddEdge(0, 3);
            graphMatching.AddEdge(1, 3);
            graphMatching.AddEdge(2, 3);

            graphMatching.MaximumMatching();
        }
    }
}
