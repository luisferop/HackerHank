using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToTheMoon
{
    class Program
    {
        static void Main(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            var firstLine = Console.ReadLine().Split(' ');
            var totalPairs = Convert.ToInt64(firstLine[1]);
            var totalAstronauts = Convert.ToInt64(firstLine[0]);

            if (totalAstronauts == 1) Console.Write(1);

            var visited = new bool[totalAstronauts];
            var sets = new List<long>();

            var graph = new Dictionary<long, List<long>>();

            for (var i = 0; i < totalAstronauts; i++)
            {
                graph.Add(i, new List<long>());
            }

            for (var i = 0; i < totalPairs; i++)
            {
                var pair = Console.ReadLine().Split(' ');
                var first = Convert.ToInt64(pair[0]);
                var second = Convert.ToInt64(pair[1]);

                if (first >= totalAstronauts || second >= totalAstronauts) return;

                graph[first].Add(second);
                graph[second].Add(first);
            }

            for (var i = 0; i < totalAstronauts; i++)
            {
                if (visited[i]) continue;
                sets.Add(DFS(i, graph, visited));
            }

            var answer = 0L;
            var sum = 0L;
            foreach (var i in sets)
            {
                answer += sum * i;
                sum += i;
            }

            Console.WriteLine(answer);
        }

        static long DFS(long item, Dictionary<long, List<long>> graph, bool[] visited)
        {
            if (visited[item]) return 0;
            var count = 1L;

            visited[item] = true;
            foreach (var i in graph[item])
            {
                count += DFS(i, graph, visited);
            }

            return count;
        }
    }
}
