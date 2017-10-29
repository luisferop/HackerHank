﻿using System;

namespace BFSShortestPathUndirectedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new Graph<int>(vertices, edges);
            var algorithms = new Algorithms();

            Console.WriteLine("Graph: " + string.Join(", ", algorithms.BFS(graph, 1)));
            //# 1, 2, 3, 4, 5, 6, 7, 8, 9, 10


            var startVertex = 1;
            var shortestPath = algorithms.ShortestPathFunction(graph, startVertex);
            foreach (var vertex in vertices)
                Console.WriteLine("shortest path to {0,2}: {1}",
                        vertex, string.Join(", ", shortestPath(vertex)));

            //# shortest path to  1: 1
            //# shortest path to  2: 1, 2
            //# shortest path to  3: 1, 3
            //# shortest path to  4: 1, 2, 4
            //# shortest path to  5: 1, 3, 5
            //# shortest path to  6: 1, 3, 6
            //# shortest path to  7: 1, 2, 4, 7
            //# shortest path to  8: 1, 3, 5, 8
            //# shortest path to  9: 1, 3, 5, 8, 9
            //# shortest path to 10: 1, 3, 5, 8, 9, 10
            Console.ReadLine();
        }
    }
}
