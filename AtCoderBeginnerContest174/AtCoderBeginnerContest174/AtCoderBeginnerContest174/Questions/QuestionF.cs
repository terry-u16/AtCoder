using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest174.Algorithms;
using AtCoderBeginnerContest174.Collections;
using AtCoderBeginnerContest174.Extensions;
using AtCoderBeginnerContest174.Numerics;
using AtCoderBeginnerContest174.Questions;
using System.Diagnostics.CodeAnalysis;

namespace AtCoderBeginnerContest174.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, queriesCount) = inputStream.ReadValue<int, int>();
            var colors = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
            var lastAppeared = Enumerable.Repeat(-1, n).ToArray();
            var queries = new Queue<Query>(Enumerable.Range(0, queriesCount).Select(i =>
            {
                var (l, r) = inputStream.ReadValue<int, int>();
                l--;
                r--;
                return new Query(l, r, i);
            }).OrderBy(q => q.Right));

            var bit = new BinaryIndexedTree(n);
            var results = new long[queriesCount];

            for (int right = 0; right < n; right++)
            {
                if (lastAppeared[colors[right]] != -1)
                {
                    bit[lastAppeared[colors[right]]]--;
                }

                lastAppeared[colors[right]] = right;
                bit[right]++;

                while (queries.Count > 0 && queries.Peek().Right == right)
                {
                    var query = queries.Dequeue();
                    results[query.Index] = bit.Sum((query.Left)..(query.Right + 1));
                }
            }

            for (int i = 0; i < results.Length; i++)
            {
                yield return results[i];
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Query
        {
            public int Left { get; }
            public int Right { get; }
            public int Index { get; }

            public Query(int left, int right, int index)
            {
                Left = left;
                Right = right;
                Index = index;
            }

            public override string ToString() => $"{nameof(Left)}: {Left}, {nameof(Right)}: {Right}";
        }
    }
}
