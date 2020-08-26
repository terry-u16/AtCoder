using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu073.Algorithms;
using Kujikatsu073.Collections;
using Kujikatsu073.Extensions;
using Kujikatsu073.Numerics;
using Kujikatsu073.Questions;
using Kujikatsu073.Graphs;

namespace Kujikatsu073.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc148/tasks/abc148_f
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, takahashiStart, aokiStart) = inputStream.ReadValue<int, int, int>();
            takahashiStart--;
            aokiStart--;
            var tree = new BasicGraph(nodeCount);
            for (int i = 0; i < nodeCount - 1; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                tree.AddEdge(new BasicEdge(a, b));
                tree.AddEdge(new BasicEdge(b, a));
            }

            var takahashiDistances = GetDistances(takahashiStart);
            var aokiDistances = GetDistances(aokiStart);

            var result = 0;
            for (int i = 0; i < nodeCount; i++)
            {
                if (takahashiDistances[i] < aokiDistances[i])
                {
                    result = Math.Max(result, aokiDistances[i]);
                }
            }

            yield return result - 1;

            int[] GetDistances(int startNode)
            {
                const int Inf = 1 << 28;
                var todo = new Queue<int>();
                var distances = Enumerable.Repeat(Inf, nodeCount).ToArray();
                todo.Enqueue(startNode);
                distances[startNode] = 0;

                while (todo.Count > 0)
                {
                    var current = todo.Dequeue();
                    foreach (var edge in tree[current])
                    {
                        var next = edge.To.Index;
                        if (distances[next] == Inf)
                        {
                            distances[next] = distances[current] + 1;
                            todo.Enqueue(next);
                        }
                    }
                }

                return distances;
            }
        }
    }
}
