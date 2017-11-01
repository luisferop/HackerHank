using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestReach
{
    #region Java/Converter
    //public class Solution
    //{

    //    //fast reader
    //    static class FastReader
    //    {
    //        BufferedReader br;
    //        StringTokenizer st;

    //        public FastReader()
    //        {
    //            br = new BufferedReader(new
    //                     InputStreamReader(System.in));
    //        }

    //        String next()
    //        {
    //            while (st == null || !st.hasMoreElements())
    //            {
    //                try
    //                {
    //                    st = new StringTokenizer(br.readLine());
    //                }
    //                catch (IOException e)
    //                {
    //                    e.printStackTrace();
    //                }
    //            }
    //            return st.nextToken();
    //        }

    //        int nextInt()
    //        {
    //            return Integer.parseInt(next());
    //        }

    //        long nextLong()
    //        {
    //            return Long.parseLong(next());
    //        }

    //        double nextDouble()
    //        {
    //            return Double.parseDouble(next());
    //        }

    //        String nextLine()
    //        {
    //            String str = "";
    //            try
    //            {
    //                str = br.readLine();
    //            }
    //            catch (IOException e)
    //            {
    //                e.printStackTrace();
    //            }
    //            return str;
    //        }
    //    }


    //    public static class Graph
    //    {
    //        int V;
    //        int[][] dist;
    //        public Graph(int v)
    //        {
    //            this.V = v;
    //            dist = new int[v][v];
    //            for (int[] arr : dist) Arrays.fill(arr, Integer.MAX_VALUE);
    //        }
    //        public int V()
    //        {
    //            return this.V;
    //        }
    //        public void addEdge(int i, int j, int w)
    //        {
    //            if (dist[i][j] > w)
    //            {
    //                dist[i][j] = w;
    //                dist[j][i] = w;
    //            }

    //        }
    //        public int[] neighbors(int i)
    //        {
    //            return dist[i];
    //        }
    //    }

    //    public static int findMinimumAdjEdge(boolean[] settled, int[] dist)
    //    {
    //        int minVal = Integer.MAX_VALUE;
    //        int minIndex = -1;
    //        for (int i = 0; i < dist.length; i++)
    //        {
    //            if (!settled[i] && dist[i] < minVal)
    //            {
    //                minIndex = i;
    //                minVal = dist[i];
    //            }
    //        }
    //        return minIndex;
    //    }
    //    public static int[] getMinimumWeight(Graph G, int start)
    //    {
    //        int[] dist = new int[G.V()];
    //        boolean[] settled = new boolean[G.V()];
    //        Arrays.fill(dist, Integer.MAX_VALUE);
    //        dist[start] = 0;
    //        for (int i = 0; i < G.V(); i++)
    //        {
    //            int u = findMinimumAdjEdge(settled, dist);
    //            if (u == -1) continue;
    //            settled[u] = true;
    //            int[] neighbors = G.neighbors(u);
    //            for (int k = 0; k < G.V(); k++)
    //            {
    //                if (!settled[k] && neighbors[k] != Integer.MAX_VALUE && dist[u] != Integer.MAX_VALUE && dist[k] > neighbors[k] + dist[u])
    //                    dist[k] = neighbors[k] + dist[u];
    //            }
    //        }

    //        for (int i = 0; i < dist.length; i++) if (dist[i] == Integer.MAX_VALUE) dist[i] = -1;
    //        return dist;



    //    }
    //    public static void main(String[] args)
    //    {
    //        FastReader in = new FastReader();
    //        int t = in.nextInt();
    //        for (int a0 = 0; a0 < t; a0++)
    //        {
    //            int n = in.nextInt();
    //            int m = in.nextInt();
    //            Graph G = new Graph(n);
    //            for (int a1 = 0; a1 < m; a1++)
    //            {
    //                int x = in.nextInt();
    //                int y = in.nextInt();
    //                int r = in.nextInt();
    //                G.addEdge(x - 1, y - 1, r);
    //            }
    //            int s = in.nextInt();
    //            int[] ret = getMinimumWeight(G, s - 1);
    //            for (int i = 0; i < ret.length; i++)
    //            {
    //                if (i == s - 1) continue;
    //                System.out.print(ret[i]);
    //                if (i < ret.length - 1)
    //                {
    //                    System.out.print(" ");
    //                }
    //            }

    //            System.out.println();
    //        }
    //    }
    //}
    #endregion

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        long t = Convert.ToInt64(Console.ReadLine());
    //        for (long a0 = 0; a0 < t; a0++)
    //        {
    //            string[] tokens_n = Console.ReadLine().Split(' ');
    //            long n = Convert.ToInt64(tokens_n[0]);
    //            DirectedWeightedGraph graph = new DirectedWeightedGraph(n);
    //            for (long vert = 1; vert <= n; vert++)
    //            {
    //                graph.InserVertex(vert.ToString());
    //            }
    //            long m = Convert.ToInt64(tokens_n[1]);
    //            for (long a1 = 0; a1 < m; a1++)
    //            {
    //                string[] tokens_x = Console.ReadLine().Split(' ');
    //                long x = Convert.ToInt64(tokens_x[0]);
    //                long y = Convert.ToInt64(tokens_x[1]);
    //                long r = Convert.ToInt64(tokens_x[2]);
    //                graph.InsertEdge(x.ToString(), y.ToString(), r);
    //            }
    //            string s = Console.ReadLine();
    //            graph.FindPaths(s);
    //        }
    //    }
    //}
    //public class DirectedWeightedGraph
    //{
    //    long MAX_VERTICES;
    //    long n, e;
    //    long[,] adj;
    //    Vertex[] vertexList;

    //    private readonly long TEMPORARY = 1;
    //    private readonly long PERMANENT = 2;
    //    private readonly long NIL = -1;
    //    private readonly long INFINITY = 99999;

    //    public DirectedWeightedGraph(long _maxVertices)
    //    {
    //        MAX_VERTICES = _maxVertices;
    //        adj = new long[MAX_VERTICES, MAX_VERTICES];
    //        vertexList = new Vertex[MAX_VERTICES];
    //    }

    //    private void Dijkstra(long s)
    //    {
    //        long v, c;
    //        for (v = 0; v < n; v++)
    //        {
    //            vertexList[v].Status = TEMPORARY;
    //            vertexList[v].PathLength = INFINITY;
    //            vertexList[v].Predecessor = NIL;
    //        }
    //        vertexList[s].PathLength = 0;
    //        while (true)
    //        {
    //            c = TempVertexMinPL();

    //            if (c == NIL)
    //                return;

    //            vertexList[c].Status = PERMANENT;

    //            for (v = 0; v < n; v++)
    //            {
    //                if (isAdjacent(c, v) && vertexList[v].Status == TEMPORARY)
    //                {
    //                    if (vertexList[c].PathLength + adj[c, v] < vertexList[v].PathLength)
    //                    {
    //                        vertexList[v].Predecessor = c;
    //                        vertexList[v].PathLength = vertexList[c].PathLength + adj[c, v];
    //                    }
    //                }
    //            }

    //        }
    //    }

    //    private long TempVertexMinPL()
    //    {
    //        long min = INFINITY;
    //        long x = NIL;
    //        for (long v = 0; v < n; v++)
    //        {
    //            if (vertexList[v].Status == TEMPORARY && vertexList[v].PathLength < min)
    //            {
    //                min = vertexList[v].PathLength;
    //                x = v;
    //            }
    //        }
    //        return x;
    //    }
    //    public void FindPaths(string source)
    //    {
    //        long s = GetIndex(source);
    //        Dijkstra(s);

    //        Console.WriteLine("Source Vertex : " + source + "\n");

    //        for (long v = 0; v < n; v++)
    //        {
    //            Console.WriteLine("Destination Vertex : " + vertexList[v].Name);
    //            if (vertexList[v].PathLength == INFINITY)
    //            {
    //                Console.WriteLine("There is no path from " + source + " to vertex" + vertexList[v].Name);
    //            }
    //            else
    //            {
    //                FindPath(s, v);
    //            }
    //        }
    //    }

    //    private void FindPath(long s, long v)
    //    {
    //        long i, u;
    //        long[] path = new long[n];
    //        long sd = 0;
    //        long count = 0;
    //        while (v != s)
    //        {
    //            count++;
    //            path[count] = v;
    //            u = vertexList[v].Predecessor;
    //            sd += adj[u, v];
    //            v = u;
    //        }
    //        count++;
    //        path[count] = s;
    //        Console.Write("Shortest path is : ");
    //        for (i = count; i >= 1; i--)
    //        {
    //            Console.Write(path[i] + " -> ");
    //        }
    //        Console.WriteLine("Shortest distance is : " + sd + "\n");
    //    }

    //    public void InserVertex(string name)
    //    {
    //        vertexList[n++] = new Vertex(name);
    //    }
    //    private long GetIndex(string s)
    //    {
    //        for (long i = 0; i < n; i++)
    //        {
    //            if (s.Equals(vertexList[i].Name))
    //            {
    //                return i;
    //            }
    //        }
    //        throw new InvalidOperationException("Invalid Vertex");
    //    }

    //    private bool isAdjacent(long u, long v)
    //    {
    //        return adj[u, v] != 0;
    //    }
    //    public bool EdgeExists(string s1, string s2)
    //    {
    //        return isAdjacent(GetIndex(s1), GetIndex(s2));
    //    }
    //    public void InsertEdge(string s1, string s2, long value)
    //    {
    //        long u = GetIndex(s1);
    //        long v = GetIndex(s2);

    //        if (u == v)
    //        {
    //            throw new InvalidOperationException("not a valid edge");
    //        }


    //        adj[u, v] = value;
    //        e++;
    //    }
    //}
    //public class Vertex
    //{
    //    public string Name;
    //    public long Status;
    //    public long Predecessor;
    //    public long PathLength;
    //    public Vertex(string name)
    //    {
    //        this.Name = name;
    //    }
    //}

}
