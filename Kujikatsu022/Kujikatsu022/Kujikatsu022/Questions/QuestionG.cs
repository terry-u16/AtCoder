using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu022.Algorithms;
using Kujikatsu022.Collections;
using Kujikatsu022.Extensions;
using Kujikatsu022.Numerics;
using Kujikatsu022.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu022.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc080/tasks/arc080_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var p = inputStream.ReadIntArray();
            var segTrees = new SegmentTree<MinIntWithIndex>[2];
            for (int i = 0; i < segTrees.Length; i++)
            {
                segTrees[i] = GetSegmentTree(p, i);
            }

            var results = new Queue<int>(p.Length);
            var spans = new PriorityQueue<SequenceSpan>(false);

            {
                var (first, second) = GetNumberPair(0, p.Length, segTrees);
                spans.Enqueue(new SequenceSpan(0, p.Length, first, second));
            }

            while (spans.Count > 0)
            {
                var current = spans.Dequeue();
                results.Enqueue(current.First.Value);
                results.Enqueue(current.Second.Value);

                if (current.First.Index - current.Begin > 0)
                {
                    var begin = current.Begin;
                    var end = current.First.Index;
                    spans.Enqueue(GetSequenceSpan(segTrees, begin, end));
                }

                if (current.Second.Index - current.First.Index > 1)
                {
                    var begin = current.First.Index + 1;
                    var end = current.Second.Index;
                    spans.Enqueue(GetSequenceSpan(segTrees, begin, end));
                }

                if (current.End - current.Second.Index > 1)
                {
                    var begin = current.Second.Index + 1;
                    var end = current.End;
                    spans.Enqueue(GetSequenceSpan(segTrees, begin, end));
                }
            }

            yield return string.Join(" ", results);
        }

        private SequenceSpan GetSequenceSpan(SegmentTree<MinIntWithIndex>[] segTrees, int begin, int end)
        {
            var (first, second) = GetNumberPair(begin, end, segTrees);
            return new SequenceSpan(begin, end, first, second);
        }

        SegmentTree<MinIntWithIndex> GetSegmentTree(int[] p, int parity)
        {
            var a = new MinIntWithIndex[p.Length];
            for (int i = parity % 2; i < p.Length; i += 2)
            {
                a[i / 2] = new MinIntWithIndex(p[i], i);
            }
            return new SegmentTree<MinIntWithIndex>(a);
        }

        (MinIntWithIndex first, MinIntWithIndex second) GetNumberPair(int beginIndex, int endIndex, SegmentTree<MinIntWithIndex>[] segmentTrees)
        {
            var first = segmentTrees[beginIndex % 2].Query((beginIndex / 2)..(endIndex / 2));
            var second = segmentTrees[(beginIndex + 1) % 2].Query(((first.Index + 1) / 2)..((endIndex + 1) / 2));
            return (first, second);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct MinIntWithIndex : IMonoid<MinIntWithIndex>
        {
            public int Value { get; }
            public int Index { get; }

            public MinIntWithIndex Identity => new MinIntWithIndex(int.MaxValue, -1);

            public MinIntWithIndex(int value, int index)
            {
                Value = value;
                Index = index;
            }

            public void Deconstruct(out int value, out int index) => (value, index) = (Value, Index);
            public override string ToString() => $"{nameof(Value)}: {Value}, {nameof(Index)}: {Index}";

            public MinIntWithIndex Multiply(MinIntWithIndex other)
            {
                if (Value - other.Value < 0)
                {
                    return this;
                }
                else
                {
                    return other;
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct SequenceSpan : IComparable<SequenceSpan>
        {
            public int Begin { get; }
            public int End { get; }
            public MinIntWithIndex First { get; }
            public MinIntWithIndex Second { get; }

            public SequenceSpan(int begin, int end, MinIntWithIndex first, MinIntWithIndex second)
            {
                Begin = begin;
                End = end;
                First = first;
                Second = second;
            }

            public override string ToString() => $"{nameof(Begin)}: {Begin}, {nameof(End)}: {End}, {nameof(First)}: {First}, {nameof(Second)}: {Second}";

            public int CompareTo([AllowNull] SequenceSpan other) => First.Value - other.First.Value;
        }
    }
}
