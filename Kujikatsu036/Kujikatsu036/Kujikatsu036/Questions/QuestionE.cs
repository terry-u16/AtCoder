using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu036.Algorithms;
using Kujikatsu036.Collections;
using Kujikatsu036.Extensions;
using Kujikatsu036.Numerics;
using Kujikatsu036.Questions;
using Kujikatsu036.Graphs;
using Kujikatsu036.Graphs.Algorithms;

namespace Kujikatsu036.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc132/tasks/abc132_e
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        const int KenKenPa = 3;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();
            var graph = new WeightedGraph(nodeCount * KenKenPa);
            for (int i = 0; i < edgeCount; i++)
            {
                var (from, to) = inputStream.ReadValue<int, int>();
                from--;
                to--;
                graph.AddEdge(new WeightedEdge(from, to + nodeCount, 1));
                graph.AddEdge(new WeightedEdge(from + nodeCount, to + nodeCount * 2, 1));
                graph.AddEdge(new WeightedEdge(from + nodeCount * 2, to, 1));
            }

            var (start, terminal) = inputStream.ReadValue<int, int>();
            start--;
            terminal--;

            var dijkstra = new Dijkstra<BasicNode, WeightedEdge>(graph);
            var distances = dijkstra.GetDistancesFrom(new BasicNode(start));

            var result = distances[terminal];
            if (result < int.MaxValue)
            {
                yield return result / 3;
            }
            else
            {
                yield return -1;
            }
        }
    }
}
