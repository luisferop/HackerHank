using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFSShortestReach
{
    class Program
    {
        static void Main(string[] args)
        {
            const long edgeLength = 6;
            long totalQueries = Convert.ToInt64(Console.ReadLine());
            string[] results = new string[totalQueries];
            for (long i = 0; i < totalQueries; i++)
            {
                string[] par1 = Console.ReadLine().Split(' ');
                long lngVertices = Convert.ToInt64(par1[0]);
                long[] vertices = new long[lngVertices];
                bool[] isReachable = new bool[lngVertices];
                for (long j = 0; j < vertices.Length; j++)
                {
                    vertices[j] = j+1;
                }
                List<Tuple<long, long>> listEdges = new List<Tuple<long, long>>();
                for (long k = 0; k < Convert.ToInt64(par1[1]); k++)
                {
                    string[] strTuple = Console.ReadLine().Split(' ');
                    listEdges.Add(new Tuple<long, long>(Convert.ToInt64(strTuple[0]), Convert.ToInt64(strTuple[1])));
                }
                var graph = new Graph<long>(vertices, listEdges.ToArray());

                var algorithms = new Algorithms();

                var startVertex = Convert.ToInt64(Console.ReadLine());
                var shortestPath = algorithms.ShortestPathFunction(graph, startVertex);
                StringBuilder sb = new StringBuilder();
                for (long v = 0; v < lngVertices; v++)
                {
                    if (vertices[v] != startVertex)
                    {
                        try
                        {
                            var obj = shortestPath(vertices[v]).ToList();
                            obj.Remove(startVertex);

                            if (obj.Count > 0)
                            {
                                sb.Append(String.Format("{0} " ,edgeLength * obj.Count));
                            }
                        }
                        catch
                        {

                            sb.Append("-1 ");
                        }
                    }
                }
                results[i] = sb.ToString();
            }
            for (long i = 0; i < totalQueries; i++)
            {
                Console.WriteLine(results[i]);
            }
        }
    }
}
