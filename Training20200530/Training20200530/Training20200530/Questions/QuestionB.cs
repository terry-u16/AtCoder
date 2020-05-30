using Training20200530.Questions;
using Training20200530.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Training20200530.Algorithms;

namespace Training20200530.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc137/tasks/abc137_e
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nmp = inputStream.ReadIntArray();
            var nodesCount = nmp[0];
            var edgesCount = nmp[1];
            var penalty = nmp[2];

            var graph = new WeightedGraph(nodesCount, Enumerable.Repeat(0, edgesCount).Select(_ =>
            {
                var abc = inputStream.ReadIntArray();
                var a = abc[0] - 1;
                var b = abc[1] - 1;
                var c = abc[2];
                return new WeightedEdge(a, b, penalty - c);
            }));

            var bellmanFord = new BellmanFord<BasicNode, WeightedEdge>(graph);

            var result = bellmanFord.GetDistancesFrom(new BasicNode(0));
            var distances = result.Item1;
            var negativeCycleNodes = result.Item2;
            if (negativeCycleNodes[nodesCount - 1])
            {
                yield return -1;
            }
            else
            {
                yield return Math.Max(-distances[nodesCount - 1], 0);
            }
        }
    }
}
