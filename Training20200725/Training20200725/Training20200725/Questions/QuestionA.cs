using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200725.Algorithms;
using Training20200725.Collections;
using Training20200725.Extensions;
using Training20200725.Numerics;
using Training20200725.Questions;
using Training20200725.Graphs;
using Training20200725.Graphs.Algorithms;

namespace Training20200725.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc022/tasks/arc022_3
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        WeightedGraph graph;


        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            graph = new WeightedGraph(n);
            for (int i = 0; i < n - 1; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                graph.AddEdge(new WeightedEdge(a, b));
                graph.AddEdge(new WeightedEdge(b, a));
            }

            var dijkstra = new Dijkstra<BasicNode, WeightedEdge>(graph);
            var distances = dijkstra.GetDistancesFrom(new BasicNode(0));

            long max = 0;
            var index = -1;
            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] > max)
                {
                    max = distances[i];
                    index = i;
                }
            }

            var from = index;

            distances = dijkstra.GetDistancesFrom(new BasicNode(from));
            max = 0;
            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] > max)
                {
                    max = distances[i];
                    index = i;
                }
            }
            var to = index;

            yield return $"{from + 1} {to + 1}";
        }
    }
}
