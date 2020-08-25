using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200825.Algorithms;
using Training20200825.Collections;
using Training20200825.Extensions;
using Training20200825.Numerics;
using Training20200825.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Training20200825.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/joisc2010/tasks/joisc2010_finals
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (cityCount, roadCount, finalCount) = inputStream.ReadValue<int, int, int>();
            var edges = new Queue<Edge>(Enumerable.Repeat(0, roadCount).Select(_ =>
            {
                var (u, v, c) = inputStream.ReadValue<int, int, int>();
                u--;
                v--;
                return new Edge(u, v, c);
            }).OrderBy(e => e));

            var unionFind = new UnionFindTree(cityCount);

            var totalCost = 0;
            while (unionFind.Groups > finalCount)
            {
                var edge = edges.Dequeue();
                if (!unionFind.IsInSameGroup(edge.From, edge.To))
                {
                    unionFind.Unite(edge.From, edge.To);
                    totalCost += edge.Cost;
                }
            }

            yield return totalCost;
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Edge : IComparable<Edge>
        {
            public int From { get; }
            public int To { get; }
            public int Cost { get; }

            public Edge(int from, int to, int cost)
            {
                From = from;
                To = to;
                Cost = cost;
            }

            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}, {nameof(Cost)}: {Cost}";

            public int CompareTo([AllowNull] Edge other) => Cost - other.Cost;
        }
    }
}
