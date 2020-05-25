using Yorukatsu048.Questions;
using Yorukatsu048.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu048.Questions
{
    /// <summary>
    /// ABC137 E
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nmp = inputStream.ReadIntArray();
            var nodeCount = nmp[0];
            var edgeCount = nmp[1];
            var penalty = nmp[2];

            var edges = new Edge[edgeCount];

            for (int i = 0; i < edgeCount; i++)
            {
                var abc = inputStream.ReadIntArray();
                var a = abc[0] - 1;
                var b = abc[1] - 1;
                var c = abc[2];
                edges[i] = new Edge(a, b, c);
            }

            var minPenalty = Enumerable.Repeat(1L << 60, nodeCount).ToArray();
            minPenalty[0] = 0;
            const long minInf = -(1L << 50);

            for (int repeat = 0; repeat <= 2 * nodeCount; repeat++)
            {
                foreach (var edge in edges)
                {
                    var updated = minPenalty[edge.From] - edge.Coin + penalty;
                    if (minPenalty[edge.To] > updated)
                    {
                        minPenalty[edge.To] = updated;
                        if (repeat == nodeCount && minPenalty[edge.To] < 1L << 40)
                        {
                            minPenalty[edge.To] = minInf;
                        }
                    }
                }
            }

            if (minPenalty[nodeCount - 1] <= minInf / 100)
            {
                yield return -1;
            }
            else
            {
                var score = minPenalty[nodeCount - 1] > 0 ? 0 : -minPenalty[nodeCount - 1];
                yield return score;
            }
        }

        struct Edge
        {
            public int From { get; }
            public int To { get; }
            public int Coin { get; }

            public Edge(int from, int to, int coin)
            {
                From = from;
                To = to;
                Coin = coin;
            }
        }
    }
}
