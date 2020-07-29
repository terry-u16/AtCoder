using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200727.Algorithms;
using Training20200727.Collections;
using Training20200727.Extensions;
using Training20200727.Numerics;
using Training20200727.Questions;
using Training20200727.Graphs;

namespace Training20200727.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dp/tasks/dp_q
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var heights = inputStream.ReadIntArray().ToArray();
            var beautifulness = inputStream.ReadLongArray();

            var segtree = new SegmentTree<MaxLong>(Enumerable.Repeat(new MaxLong(0), n + 1).ToArray());
            for (int i = 0; i < heights.Length; i++)
            {
                var current = segtree.Query(..heights[i]);
                segtree[heights[i]] = new MaxLong(current.Value + beautifulness[i]);
            }

            yield return segtree.Query(..).Value;
        }

        readonly struct MaxLong : IMonoid<MaxLong>
        {
            public long Value { get; }

            public MaxLong(long value)
            {
                Value = value;
            }

            public MaxLong Identity => new MaxLong(long.MinValue);

            public MaxLong Multiply(MaxLong other) => Value >= other.Value ? this : other;
            public override string ToString() => Value.ToString();
        }
    }
}
