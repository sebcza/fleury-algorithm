using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Graph
    {
        private int V;

        private List<List<int>> adj;

        public Graph(int v)
        {
            V = v;
            adj = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
            {
                adj.Add(new List<int>());
            }
        }

        public void AddEgde(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
        }

        public void RemoveEdge(int u, int v)
        {
            adj[u].Remove(v);
            adj[v].Remove(u);
        }

        int DFSCount(int v, bool[] visited)
        {
            int count = 1;
            visited[v] = true;
            adj[v].ForEach(x =>
            {
                if (visited[x] == false)
                {
                    count = count + DFSCount(x, visited);
                }
            });
            return count;
        }

        void DFSUtil(int v, bool []visited)
        {
            visited[v] = true;
            adj[v].ForEach(x =>
            {
                if (!visited[x])
                {
                    DFSUtil(x, visited);
                }
            });
        }

        bool IsConnected()
        {
            bool[] visted = new bool[V];
            int i;
            for (i = 0; i < V; i++)
            {
                visted[i] = false;
            }

            for (i = 0; i < V; i++)
            {
                if (adj[i].Count != 0)
                {
                    break;
                }
            }
            if (i == V)
            {
                return true;
            }
            DFSUtil(i, visted);

            for (i = 0; i < V; i++)
            {
                if (visted[i] == false && adj[i].Count > 0)
                {
                    return false;
                }
            }


            return true;
        }

        public bool IsValidNextEdge(int u, int v)
        {
            if (adj[u].Count == 1)
            {
                return true;
            }
            else
            {
                bool []visted = new bool[V];
                for (int i = 0; i < visted.Length; i++)
                {
                    visted[i] = false;
                }

                var count1 = DFSCount(u, visted);

                RemoveEdge(u,v);
                bool[] visted2 = new bool[V];
                for (int i = 0; i < visted2.Length; i++)
                {
                    visted2[i] = false;
                }
                var count2 = DFSCount(u, visted2);

                AddEgde(u, v);

                if (count1 > count2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void PrintEulerUtil(int u)
        {
            try
            {
                foreach (var x in adj[u])
                {
                    if (IsValidNextEdge(u, x))
                    {
                        Console.WriteLine(u + " - " + x);
                        RemoveEdge(u, x);
                        PrintEulerUtil(x);
                    }
                }
            }
            catch (Exception e)
            {
                
            }

        }

        public void PrintEulerTour()
        {
            int u = 0;
            for (int i = 0; i < V; i++)
            {
                if (adj[i].Count %2 != 0)
                {
                    u = i;
                    break;
                }
            }
            Console.WriteLine("");
            this.PrintEulerUtil(u);
        }

        int isEulerian()
        {
            if (IsConnected() == false)
            {
                return 0;
            }

            int odd = 0;
            for (int i = 0; i < V; i++)
            {
                if (adj[i].Count%2 != 0)
                {
                    odd++;
                }
            }

            if (odd > 2)
            {
                return 0;
            }
            return (odd == 2) ? 1 : 2;
        }

        public void test()
        {
            int res = isEulerian();
            if (res == 0)
            {
                Console.WriteLine("Nie jest Eulerowski");
            }
            else if (res == 1)
            {
                Console.WriteLine("Ma ścieżkę");
            }
            else
            {
                Console.WriteLine("Ma cykl");
            }
        }
    }
}
