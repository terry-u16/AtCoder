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
    /// https://atcoder.jp/contests/abc061/tasks/abc061_d
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var nodesCount = nm[0];
            var edgesCount = nm[1];

            var bellmanFord = new BellmanFord<BasicNode, WeightedEdge>(Enumerable.Repeat(0, edgesCount)
                                                                           .Select(_ => LoadEdge(inputStream.ReadIntArray())), nodesCount);
            var result = bellmanFord.GetDistancesFrom(new BasicNode(0));
            var distances = result.Item1;
            var negativeCycleNodes = result.Item2;
            if (negativeCycleNodes[nodesCount - 1])
            {
                yield return "inf";
            }
            else
            {
                yield return -distances[nodesCount - 1];
            }
        }

        WeightedEdge LoadEdge(int[] input)
        {
            var a = input[0] - 1;
            var b = input[1] - 1;
            var c = -input[2];
            return new WeightedEdge(a, b, c);
        }
    }


}
