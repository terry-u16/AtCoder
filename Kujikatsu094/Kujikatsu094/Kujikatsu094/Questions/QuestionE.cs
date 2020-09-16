using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu094.Algorithms;
using Kujikatsu094.Collections;
using Kujikatsu094.Extensions;
using Kujikatsu094.Numerics;
using Kujikatsu094.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu094.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc174/tasks/abc174_f
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, queryCount) = inputStream.ReadValue<int, int>();
            var queries = new Query[queryCount];
            var c = inputStream.ReadIntArray();

            for (int i = 0; i < queries.Length; i++)
            {
                var (l, r) = inputStream.ReadValue<int, int>();
                l--;
                queries[i] = new Query(l, r, i);
            }

            Array.Sort(queries);
            var bit = new BinaryIndexedTree(n);
            var lastSeen = new Dictionary<int, int>();

            var results = new long[queryCount];
            var right = 0;
            foreach (var query in queries)
            {
                while (right < query.R)
                {
                    bit[right]++;
                    if (lastSeen.TryGetValue(c[right], out var last))
                    {
                        bit[last]--;
                    }
                    lastSeen[c[right]] = right;
                    right++;
                }

                results[query.Index] = bit.Sum(query.L..query.R);
            }

            foreach (var result in results)
            {
                yield return result;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Query : IComparable<Query>
        {
            public int L { get; }
            public int R { get; }
            public int Index { get; }

            public Query(int l, int r, int index)
            {
                L = l;
                R = r;
                Index = index;
            }

            public void Deconstruct(out int l, out int r) => (l, r) = (L, R);
            public override string ToString() => $"{nameof(L)}: {L}, {nameof(R)}: {R}";

            public int CompareTo([AllowNull] Query other) => R - other.R;
        }
    }
}
