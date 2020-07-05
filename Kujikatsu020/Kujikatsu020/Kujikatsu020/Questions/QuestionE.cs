using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu020.Algorithms;
using Kujikatsu020.Collections;
using Kujikatsu020.Extensions;
using Kujikatsu020.Numerics;
using Kujikatsu020.Questions;

namespace Kujikatsu020.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc054/tasks/abc054_c
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<int, int>();
            var edges = new HashSet<Edge>();
            for (int i = 0; i < m; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                edges.Add(new Edge(a, b));
                edges.Add(new Edge(b, a));
            }

            var orders = Enumerable.Range(1, n - 1);
            var count = 0;
            foreach (var order in PermutationAlgorithms.GetPermutations(orders))
            {
                if (Check(order.Span, edges))
                {
                    count++;
                }
            }

            yield return count;
        }

        bool Check(ReadOnlySpan<int> order, HashSet<Edge> edges)
        {
            var ok = true;
            ok &= edges.Contains(new Edge(0, order[0]));

            for (int i = 0; i + 1 < order.Length; i++)
            {
                ok &= edges.Contains(new Edge(order[i], order[i + 1]));
            }

            return ok;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Edge : IEquatable<Edge>
        {
            public int From { get; }
            public int To { get; }

            public Edge(int from, int to)
            {
                From = from;
                To = to;
            }

            public void Deconstruct(out int from, out int tos) => (from, tos) = (From, To);
            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}";

            public override bool Equals(object obj)
            {
                return obj is Edge edge && Equals(edge);
            }

            public bool Equals(Edge other)
            {
                return From == other.From &&
                       To == other.To;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(From, To);
            }

            public static bool operator ==(Edge left, Edge right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Edge left, Edge right)
            {
                return !(left == right);
            }
        }
    }
}
