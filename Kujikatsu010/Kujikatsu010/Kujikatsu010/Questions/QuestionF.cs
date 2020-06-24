using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu010.Algorithms;
using Kujikatsu010.Collections;
using Kujikatsu010.Extensions;
using Kujikatsu010.Numerics;
using Kujikatsu010.Questions;
using Kujikatsu010.Graphs;
using Kujikatsu010.Graphs.Algorithms;

namespace Kujikatsu010.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc137/tasks/abc137_e
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount, penalty) = inputStream.ReadValue<int, int, int>();
            var graph = new WeightedGraph(nodeCount);
            for (int i = 0; i < edgeCount; i++)
            {
                var (from, to, coin) = inputStream.ReadValue<int, int, int>();
                from--;
                to--;
                graph.AddEdge(new WeightedEdge(from, to, penalty - coin));
            }

            var bf = new BellmanFord<BasicNode, WeightedEdge>(graph);

            var (distances, negativeCycles) = bf.GetDistancesFrom(new BasicNode(0));

            if (negativeCycles[^1])
            {
                yield return -1;
            }
            else
            {
                yield return Math.Max(-distances[^1], 0);
            }
        }
    }
}
