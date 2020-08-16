using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu063.Algorithms;
using Kujikatsu063.Collections;
using Kujikatsu063.Extensions;
using Kujikatsu063.Numerics;
using Kujikatsu063.Questions;
using Kujikatsu063.Graphs;

namespace Kujikatsu063.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc013/tasks/agc013_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();
            var graph = new BasicGraph(nodeCount);

            for (int i = 0; i < edgeCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                graph.AddEdge(new BasicEdge(a, b));
                graph.AddEdge(new BasicEdge(b, a));
            }

            var path = InitializePath(graph);
            var seen = new bool[nodeCount];
            seen[path.PeekFirst()] = true;
            seen[path.PeekLast()] = true;

            while (true)
            {
                var found = false;
                var current = path.PeekFirst();
                foreach (var edge in graph[current])
                {
                    var to = edge.To.Index;
                    if (!seen[to])
                    {
                        path.EnqueueFirst(to);
                        seen[to] = true;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    break;
                }
            }

            while (true)
            {
                var found = false;
                var current = path.PeekLast();
                foreach (var edge in graph[current])
                {
                    var to = edge.To.Index;
                    if (!seen[to])
                    {
                        path.EnqueueLast(to);
                        seen[to] = true;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    break;
                }
            }

            yield return path.Count;
            yield return path.Select(i => i + 1).Join(' ');
        }

        Deque<int> InitializePath(BasicGraph graph)
        {
            var edge = graph[0].First();
            var first = edge.From.Index;
            var second = edge.To.Index;

            var deque = new Deque<int>();
            deque.EnqueueFirst(first);
            deque.EnqueueLast(second);

            return deque;
        }
    }
}
