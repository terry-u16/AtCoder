using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu085.Algorithms;
using Kujikatsu085.Collections;
using Kujikatsu085.Extensions;
using Kujikatsu085.Numerics;
using Kujikatsu085.Questions;
using System.Diagnostics;

namespace Kujikatsu085.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc075/tasks/abc075_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();
            var edges = new Edge[edgeCount];
            for (int i = 0; i < edges.Length; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                edges[i] = new Edge(a, b);
            }

            yield return Enumerable.Range(0, edgeCount).Count(i => !IsConnected(nodeCount, edges, i));
        }

        bool IsConnected(int nodeCount, Edge[] edges, int removed)
        {
            var uf = new UnionFindTree(nodeCount);
            for (int i = 0; i < edges.Length; i++)
            {
                if (i != removed)
                {
                    uf.Unite(edges[i].From, edges[i].To);
                }
            }

            return uf.Groups == 1;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Edge
        {
            public int From { get; }
            public int To { get; }

            public Edge(int from, int to)
            {
                From = from;
                To = to;
            }

            public void Deconstruct(out int from, out int to) => (from, to) = (From, To);
            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}";
        }
    }
}
