using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu044.Algorithms;
using Kujikatsu044.Collections;
using Kujikatsu044.Extensions;
using Kujikatsu044.Numerics;
using Kujikatsu044.Questions;
using Kujikatsu044.Graphs;

namespace Kujikatsu044.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc027/tasks/agc027_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int A = 0;
            const int B = 1;

            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();
            var s = inputStream.ReadLine().Select(c => c == 'A' ? A : B).ToArray();

            var graph = new BasicGraph(nodeCount);
            var adjacents = new int[nodeCount, B + 1];

            for (int i = 0; i < edgeCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                adjacents[a, s[b]]++;
                adjacents[b, s[a]]++;
                graph.AddEdge(new BasicEdge(a, b));
                graph.AddEdge(new BasicEdge(b, a));
            }

            var queue = new Queue<int>();
            var erased = new bool[nodeCount];

            for (int i = 0; i < nodeCount; i++)
            {
                if (adjacents[i, A] == 0 || adjacents[i, B] == 0)
                {
                    queue.Enqueue(i);
                    erased[i] = true;
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                foreach (var edge in graph[current])
                {
                    var next = edge.To.Index;
                    if (!erased[next])
                    {
                        adjacents[next, s[current]]--;
                        if (adjacents[next, A] == 0 || adjacents[next, B] == 0)
                        {
                            erased[next] = true;
                            queue.Enqueue(next);
                        }
                    }
                }
            }

            yield return erased.Any(b => !b) ? "Yes" : "No";
        }
    }
}
