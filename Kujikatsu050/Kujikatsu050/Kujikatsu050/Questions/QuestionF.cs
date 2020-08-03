using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu050.Algorithms;
using Kujikatsu050.Collections;
using Kujikatsu050.Extensions;
using Kujikatsu050.Numerics;
using Kujikatsu050.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu050.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/nikkei2019-2-qual/tasks/nikkei2019_2_qual_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();
            var edges = new Edge[edgeCount];

            for (int i = 0; i < edges.Length; i++)
            {
                var (l, r, c) = inputStream.ReadValue<int, int, int>();
                l--;
                r--;
                edges[i] = new Edge(l, r, c);
            }

            Array.Sort(edges);
            var distances = new SegmentTree<MinLong>(Enumerable.Repeat(new MinLong().Identity, nodeCount).ToArray());
            distances[0] = new MinLong(0);

            foreach (var edge in edges)
            {
                var from = distances.Query(edge.Left, edge.Right);
                if (from.Value != long.MaxValue)
                {
                    distances[edge.Right] = distances[edge.Right].Multiply(new MinLong(from.Value + edge.Cost));
                }
            }

            if (distances[nodeCount - 1].Value != long.MaxValue)
            {
                yield return distances[nodeCount - 1].Value;
            }
            else
            {
                yield return -1;
            }
        }

        readonly struct MinLong : IMonoid<MinLong>
        {
            public long Value { get; }

            public MinLong(long value)
            {
                Value = value;
            }

            public MinLong Identity => new MinLong(long.MaxValue);

            public MinLong Multiply(MinLong other) => Value <= other.Value ? this : other;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Edge : IComparable<Edge>
        {
            public int Left { get; }
            public int Right { get; }
            public int Cost { get; }

            public Edge(int left, int right, int cost)
            {
                Left = left;
                Right = right;
                Cost = cost;
            }

            public override string ToString() => $"{nameof(Left)}: {Left}, {nameof(Right)}: {Right}";

            public int CompareTo([AllowNull] Edge other) => Right - other.Right;
        }

    }
}
