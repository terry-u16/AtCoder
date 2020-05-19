using PAST002.Algorithms;
using PAST002.Collections;
using PAST002.Questions;
using PAST002.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PAST002.Questions
{
    public class QuestionL : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (length, needed, desiredDistance) = inputStream.ReadValue<int, int, int>();
            var a = inputStream.ReadIntArray();

            if (1 + desiredDistance * (needed - 1) > length)
            {
                yield return -1;
                yield break;
            }

            var setmentTree = new SegmentTree<MinInt>(a.Select((ai, index) => new MinInt(ai, index)).ToArray());
            var sequence = new Queue<int>();
            Construct(setmentTree, 0, sequence, needed, desiredDistance);
            yield return string.Join(" ", sequence);
        }

        readonly struct MinInt : IMonoid<MinInt>
        {
            public int Value { get; }
            public int Index { get; }

            public MinInt(int value, int index)
            {
                Value = value;
                Index = index;
            }

            public MinInt Identity => new MinInt(int.MaxValue, -1);

            public MinInt Multiply(MinInt other)
            {
                if (Value <= other.Value)
                {
                    return this;
                }
                else
                {
                    return other;
                }
            }

            public void Deconstruct(out int value, out int index)
            {
                value = Value;
                index = Index;
            }
        }

        void Construct(SegmentTree<MinInt> minInts, int beginIndex, Queue<int> current, int needed, int desiredDistance)
        {
            if (needed == 1)
            {
                var (smallest, _) = minInts.Query(beginIndex..);
                current.Enqueue(smallest);
            }
            else
            {
                var toLeft = desiredDistance * (needed - 1);
                var (smallest, index) = minInts.Query(beginIndex..^toLeft);
                current.Enqueue(smallest);
                Construct(minInts, index + desiredDistance, current, needed - 1, desiredDistance);
            }
        }
    }
}
