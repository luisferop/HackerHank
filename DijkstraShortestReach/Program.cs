using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShortestReach
{

     
    class Solution
    {
        private long rank = 0;
        private long[,] L;
        private long[] C;
        public long[] D;
        private long _startNode = 0;
        public Solution(long paramRank, long[,] paramArray, long startNode)
        {
            _startNode = startNode;
            L = new long[paramRank, paramRank];

            C = new long[paramRank];
            for (int _l = 0; _l < paramRank; _l++)
            {
                C[_l] = -1;
            }
            D = new long[paramRank];
            for (int _l = 0; _l < paramRank; _l++)
            {
                D[_l] = -1;
            }
            rank = paramRank;
            for (long i = 0; i < rank; i++)
            {
                for (long j = 0; j < rank; j++)
                {
                    L[i, j] = paramArray[i, j];
                }
            }

            for (long i = _startNode; i < rank; i++)
            {
                C[i] = i;
            }
            C[_startNode] = -1;
            for (long i = 1; i < rank; i++)
                D[i] = L[_startNode, i];
        }
        public void DijkstraSolving()
        {
            long minValue = Int32.MaxValue;
            long minNode = 0;
            for (long i = _startNode; i < rank; i++)
            {
                if (C[i] == -1)
                    continue;
                if (D[i] > 0 && D[i] < minValue)
                {
                    minValue = D[i];
                    minNode = i;
                }
            }
            C[minNode] = -1;
            for (long i = _startNode; i < rank; i++)
            {
                if (L[minNode, i] < 0)
                    continue;
                if (D[i] < 0)
                {
                    D[i] = minValue + L[minNode, i];
                    continue;
                }
                if ((D[minNode] + L[minNode, i]) < D[i])
                    D[i] = minValue + L[minNode, i];
            }
        }
        public void Run()
        {
            DijkstraSolving();
        }
        static void Main(string[] args)
        {
            long t = Convert.ToInt64(Console.ReadLine());
            for (long a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                long n = Convert.ToInt64(tokens_n[0]);
                long[,] graph = new long[n, n];

                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        graph[r, c] = -1;
                    }
                }

                long m = Convert.ToInt64(tokens_n[1]);
                for (long a1 = 0; a1 < m; a1++)
                {
                    string[] tokens_x = Console.ReadLine().Split(' ');
                    long x = Convert.ToInt64(tokens_x[0]);
                    long y = Convert.ToInt64(tokens_x[1]);
                    long r = Convert.ToInt64(tokens_x[2]);
                    if (x - 1 > y - 1)
                    {
                        graph[y - 1, x - 1] = r;
                        
                    }
                    else
                    {
                        graph[x - 1, y - 1] = r;
                    }
                    
                }
                long s = Convert.ToInt64(Console.ReadLine());

                Solution clss = new Solution((long)Math.Sqrt(graph.Length), graph, s-1);
                clss.Run();
                foreach (long i in clss.D)
                {
                    if (i > 0)
                    {
                        Console.Write(i + " ");
                    }

                }

                Console.Read();

            }


        }
    }

}
