using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu045.Algorithms;
using Kujikatsu045.Collections;
using Kujikatsu045.Extensions;
using Kujikatsu045.Numerics;
using Kujikatsu045.Questions;
using Kujikatsu045.Graphs;

namespace Kujikatsu045.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2017-qualb/tasks/code_festival_2017_qualb_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        BasicGraph graph;
        bool[] seen;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();
            graph = new BasicGraph(nodeCount * 2);
            var edges = new BasicEdge[edgeCount * 4];
            seen = new bool[nodeCount * 2];

            for (int i = 0; i < edgeCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;

                if (a > b)
                {
                    (a, b) = (b, a);
                }

                edges[i * 4] = new BasicEdge(a, b + nodeCount);
                edges[i * 4 + 1] = new BasicEdge(b + nodeCount, a);
                edges[i * 4 + 2] = new BasicEdge(a + nodeCount, b);
                edges[i * 4 + 3] = new BasicEdge(b, a + nodeCount);
                for (int j = 0; j < 4; j++)
                {
                    graph.AddEdge(edges[i * 4 + j]);
                }
            }

            Bfs();

            if (seen.All(b => b))
            {
                yield return (long)nodeCount * (nodeCount - 1) / 2 - edgeCount;
                yield break;
            }

            long result = 0;
            var odds = new int[nodeCount + 1];
            var evens = new int[nodeCount + 1];

            for (int i = 0; i < nodeCount; i++)
            {
                evens[i + 1] = evens[i] + (seen[i] ? 1 : 0);
                odds[i + 1] = odds[i] + (seen[nodeCount + i] ? 1 : 0);
            }

            for (int i = nodeCount - 1; i >= 0; i--)
            {
                // 偶数
                if (seen[i])
                {
                    result += odds[i];
                }

                // 奇数
                if (seen[i + nodeCount])
                {
                    result += evens[i];
                }
            }

            for (int i = 0; i < edgeCount; i++)
            {
                var odd = edges[i * 4].From.Index;
                var even = edges[i * 4].To.Index;

                if (seen[odd] && seen[even])
                {
                    result--;
                }

                odd = edges[i * 4 + 2].To.Index;
                even = edges[i * 4 + 2].From.Index;

                if (seen[odd] && seen[even])
                {
                    result--;
                }
            }

            yield return result;
        }

        void Bfs()
        {
            var todo = new Queue<int>();
            todo.Enqueue(0);
            seen[0] = true;

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                foreach (var edge in graph[current])
                {
                    var next = edge.To.Index;
                    if (!seen[next])
                    {
                        todo.Enqueue(next);
                        seen[next] = true;
                    }
                }
            }
        }
    }
}
