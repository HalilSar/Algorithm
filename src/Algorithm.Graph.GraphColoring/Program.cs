using System;
using System.Collections.Generic;
namespace Algorithm.Graph.GraphColoring
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

       
        public void ColorGraph()
        {
            int[] result = new int[V];
            bool[] available = new bool[V]; 

            for (int i = 0; i < V; ++i)
            {
                result[i] = -1; 
                available[i] = false;
            }

           
            result[0] = 0;

           
            for (int u = 1; u < V; ++u)
            {
                
                foreach (int v in adj[u])
                {
                    if (result[v] != -1)
                    {
                        available[result[v]] = true;
                    }
                }

             
                int cr;
                for (cr = 0; cr < V; ++cr)
                {
                    if (available[cr] == false)
                    {
                        break;
                    }
                }

                result[u] = cr; 

                
                foreach (int v in adj[u])
                {
                    if (result[v] != -1)
                    {
                        available[result[v]] = false;
                    }
                }
            }

           
            Console.WriteLine("Graph coloring result:");
            for (int u = 0; u < V; u++)
            {
                Console.WriteLine("Vertex " + u + " ---> Color " + result[u]);
            }
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

            graph.ColorGraph();
        }
    }
}
