using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200810.Algorithms;
using Training20200810.Collections;
using Training20200810.Extensions;
using Training20200810.Numerics;
using Training20200810.Questions;

namespace Training20200810.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc045/tasks/arc045_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (roomCount, sectionCount) = inputStream.ReadValue<int, int>();
            var sections = new Section[sectionCount];
            var imos = new int[roomCount + 5];

            for (int i = 0; i < sections.Length; i++)
            {
                var (s, t) = inputStream.ReadValue<int, int>();
                imos[s]++;
                imos[t + 1]--;
                sections[i] = new Section(s, t);
            }

            for (int i = 0; i + 1 < imos.Length; i++)
            {
                imos[i + 1] += imos[i];
            }

            var segtree = new SegmentTree<MinInt>(imos.Select(i => new MinInt(i)).ToArray());

            var results = new Queue<int>();
            for (int i = 0; i < sections.Length; i++)
            {
                var min = segtree.Query(sections[i].Left..(sections[i].Right + 1));
                if (min.Value >= 2)
                {
                    results.Enqueue(i + 1);
                }
            }

            yield return results.Count;
            foreach (var room in results)
            {
                yield return room;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Section
        {
            public int Left { get; }
            public int Right { get; }

            public Section(int left, int right)
            {
                Left = left;
                Right = right;
            }

            public void Deconstruct(out int left, out int right) => (left, right) = (Left, Right);
            public override string ToString() => $"{nameof(Left)}: {Left}, {nameof(Right)}: {Right}";
        }

        readonly struct MinInt : IMonoid<MinInt>
        {
            public int Value { get; }
            public MinInt Identity => new MinInt(int.MaxValue);

            public MinInt(int value)
            {
                Value = value;
            }

            public MinInt Multiply(MinInt other) => Value <= other.Value ? this : other;
        }
    }
}
