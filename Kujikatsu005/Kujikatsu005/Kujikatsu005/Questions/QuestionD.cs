using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Kujikatsu005.Algorithms;
using Kujikatsu005.Collections;
using Kujikatsu005.Extensions;
using Kujikatsu005.Graphs;
using Kujikatsu005.Graphs.Algorithms;
using Kujikatsu005.Numerics;
using Kujikatsu005.Questions;

namespace Kujikatsu005.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc070/tasks/abc070_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var tree = new WeightedGraph(n);
            for (int i = 0; i < n - 1; i++)
            {
                var (a, b, weight) = inputStream.ReadValue<int, int, int>();
                a--;
                b--;
                tree.AddEdge(new WeightedEdge(a, b, weight));
                tree.AddEdge(new WeightedEdge(b, a, weight));
            }

            var (queries, via) = inputStream.ReadValue<int, int>();
            via--;
            var dijkstra = new Dijkstra<BasicNode, WeightedEdge>(tree);
            var distances = dijkstra.GetDistancesFrom(new BasicNode(via));
            for (int q = 0; q < queries; q++)
            {
                var (from, to) = inputStream.ReadValue<int, int>();
                from--;
                to--;
                yield return distances[from] + distances[to];
            }
        }
    }
}
