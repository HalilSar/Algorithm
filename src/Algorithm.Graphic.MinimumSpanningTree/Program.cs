using System;
using System.Collections.Generic;
namespace Algorithm.Graphic.MinimumSpanningTree
{
    class Program
    {
        class Edge : IComparable<Edge>
        {
            public int Src, Dest, Weight;

            public Edge(int src, int dest, int weight)
            {
                Src = src;
                Dest = dest;
                Weight = weight;
            }

            public int CompareTo(Edge other)
            {
                return this.Weight - other.Weight;
            }
        }

        private int V;
        private List<Edge> edges;

        public Program(int v)
        {
            V = v;
            edges = new List<Edge>();
        }

 
        public void AddEdge(int src, int dest, int weight)
        {
            Edge edge = new Edge(src, dest, weight);
            edges.Add(edge);
        }


        private int Find(int[] parent, int i)
        {
            if (parent[i] == -1)
            {
                return i;
            }
            return Find(parent, parent[i]);
        }

        private void Union(int[] parent, int x, int y)
        {
            int xSet = Find(parent, x);
            int ySet = Find(parent, y);
            parent[xSet] = ySet;
        }


        public void KruskalMST()
        {
            List<Edge> result = new List<Edge>();
            int e = 0;
            int i = 0;

            edges.Sort();

            int[] parent = new int[V];
            for (int j = 0; j < V; ++j)
            {
                parent[j] = -1;
            }

            while (e < V - 1)
            {
                Edge nextEdge = edges[i++];
                int x = Find(parent, nextEdge.Src);
                int y = Find(parent, nextEdge.Dest);

                if (x != y)
                {
                    result.Add(nextEdge);
                    Union(parent, x, y);
                    e++;
                }
            }

            Console.WriteLine("Minimum Spanning Tree:");
            foreach (Edge edge in result)
            {
                Console.WriteLine(edge.Src + " - " + edge.Dest + ": " + edge.Weight);
            }
        }

        
        public static void Main(string[] args)
        {
            Program graph = new Program(4);

            graph.AddEdge(0, 1, 10);
            graph.AddEdge(0, 2, 6);
            graph.AddEdge(0, 3, 5);
            graph.AddEdge(1, 3, 15);
            graph.AddEdge(2, 3, 4);

            graph.KruskalMST();
        }
    }
}
