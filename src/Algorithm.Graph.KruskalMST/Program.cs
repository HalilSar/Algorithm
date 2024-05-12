using System;
using System.Collections.Generic;
namespace Algorithm.Graph.KruskalMST
{
    class Program
    {
        private int V, E; 
        private List<Edge> edges;

        private class Edge : IComparable<Edge>
        {
            public int src, dest, weight;

            public Edge(int src, int dest, int weight)
            {
                this.src = src;
                this.dest = dest;
                this.weight = weight;
            }

           
            public int CompareTo(Edge compareEdge)
            {
                return this.weight - compareEdge.weight;
            }
        }

        public Program(int v, int e)
        {
            V = v;
            E = e;
            edges = new List<Edge>();
        }

        
        public void AddEdge(int src, int dest, int weight)
        {
            edges.Add(new Edge(src, dest, weight));
        }

       
        class Subset
        {
            public int parent, rank;
        }
 
        private int Find(Subset[] subsets, int i)
        {
            if (subsets[i].parent != i)
            {
                subsets[i].parent = Find(subsets, subsets[i].parent);
            }
            return subsets[i].parent;
        }
         
        private void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            if (subsets[xroot].rank < subsets[yroot].rank)
            {
                subsets[xroot].parent = yroot;
            }
            else if (subsets[xroot].rank > subsets[yroot].rank)
            {
                subsets[yroot].parent = xroot;
            }
            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
        }

       
        public void Kruskal()
        {
            Edge[] result = new Edge[V];
            int e = 0;
            int i = 0;

            edges.Sort();

            Subset[] subsets = new Subset[V];
            for (int v = 0; v < V; ++v)
            {
                subsets[v] = new Subset();
                subsets[v].parent = v;
                subsets[v].rank = 0;
            }

            while (e < V - 1 && i < E)
            {
                Edge next_edge = edges[i++];
                int x = Find(subsets, next_edge.src);
                int y = Find(subsets, next_edge.dest);

                if (x != y)
                {
                    result[e++] = next_edge;
                    Union(subsets, x, y);
                }
            }

            Console.WriteLine("Kruskal's Minimum Spanning Tree:");
            for (i = 0; i < e; ++i)
            {
                Console.WriteLine("Edge: " + result[i].src + " - " + result[i].dest + ", Weight: " + result[i].weight);
            }
        }

        
        public static void Main(string[] args)
        {
            int V = 4; 
            int E = 5; 

            Program graph = new Program(V, E);

 
            graph.AddEdge(0, 1, 10);
            graph.AddEdge(0, 2, 6);
            graph.AddEdge(0, 3, 5);
            graph.AddEdge(1, 3, 15);
            graph.AddEdge(2, 3, 4);

            graph.Kruskal();
        }
    }
}

