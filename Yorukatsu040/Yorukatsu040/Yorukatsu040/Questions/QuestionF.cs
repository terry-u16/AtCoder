using Yorukatsu040.Questions;
using Yorukatsu040.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu040.Questions
{
    /// <summary>
    /// ABC061 D
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var nodeCount = nm[0];
            var edgeCount = nm[1];
            var edges = new Edge[edgeCount];

            for (int i = 0; i < edges.Length; i++)
            {
                var abc = inputStream.ReadIntArray();
                edges[i] = new Edge(abc[0] - 1, abc[1] - 1, -abc[2]);
            }

            var costs = Enumerable.Repeat(1L << 60, nodeCount).ToArray();
            costs[0] = 0;

            for (int i = 0; i < nodeCount; i++)
            {
                foreach (var edge in edges)
                {
                    var newCost = costs[edge.From] + edge.Cost;
                    if (costs[edge.To] > newCost)
                    {
                        costs[edge.To] = newCost;
                        if (i == nodeCount - 1)
                        {
                            // N回目で更新されたらそこは無限ループ
                            costs[edge.To] = -1L << 40;
                        }
                    }
                }
            }

            // 負回路の影響検出
            for (int i = 0; i < nodeCount; i++)
            {
                foreach (var edge in edges)
                {
                    var newCost = costs[edge.From] + edge.Cost;
                    if (costs[edge.To] > newCost)
                    {
                        costs[edge.To] = newCost;
                        if (i == nodeCount - 1 && edge.To == nodeCount - 1)
                        {
                            // 今度こそ間違いなくinf
                            yield return "inf";
                            yield break;
                        }
                    }
                }
            }

            yield return -costs[nodeCount - 1];
        }

        struct Edge
        {
            public int From { get; }
            public int To { get; }
            public long Cost { get; }

            public Edge(int from, int to, long cost)
            {
                From = from;
                To = to;
                Cost = cost;
            }

            public override string ToString() => $"{From}--[{Cost}]-->{To}";
        }
    }
}
