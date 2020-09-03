using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu081.Algorithms;
using Kujikatsu081.Collections;
using Kujikatsu081.Extensions;
using Kujikatsu081.Numerics;
using Kujikatsu081.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu081.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc177/tasks/abc177_f
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var nearestStart = new LazySegmentTree<MinInt, Updater>(Enumerable.Range(0, width).Select(i => new MinInt(i)).ToArray());
            var minWalk = new LazySegmentTree<MinInt, Updater>(Enumerable.Range(0, width).Select(i => new MinInt(0)).ToArray());
            const int Inf = 1 << 28;
            const int NegInf = -(1 << 28);

            for (int row = 0; row < height; row++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;

                if (a > 0)
                {
                    nearestStart.Update(a, b, new Updater(nearestStart.Query(a - 1, a).Value));
                    minWalk.Update(a, b, new Updater(Inf));
                    minWalk.Update(a, a + 1, new Updater(a - nearestStart.Query(a, a + 1).Value));

                    if (b < width)
                    {
                        minWalk.Update(b, b + 1, new Updater(b - nearestStart.Query(b, b + 1).Value));
                    }
                }
                else
                {
                    nearestStart.Update(a, b, new Updater(NegInf));
                    minWalk.Update(a, b, new Updater(Inf));
                }


                var min = minWalk.Query(0, width).Value;

                if (min < Inf)
                {
                    yield return min + row + 1;
                }
                else
                {
                    yield return -1;
                }
            }
        }

        readonly struct MinInt : IMonoid<MinInt>
        {
            public MinInt Identity => new MinInt(1 << 28);

            public int Value { get; }

            public MinInt(int value)
            {
                Value = value;
            }

            public MinInt Multiply(MinInt other) => Value < other.Value ? this : other;
            public override string ToString() => Value.ToString();
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Updater : IMonoidWithAct<MinInt, Updater>, IEquatable<Updater>
        {
            public int Value { get; }
            public int Generation { get; }

            static int gen = 0;

            public Updater Identity => new Updater(int.MinValue);

            public Updater(int value)
            {
                Value = value;
                Generation = gen++;
            }

            public void Deconstruct(out int value, out int generation) => (value, generation) = (Value, Generation);
            public override string ToString() => $"{nameof(Value)}: {Value}, {nameof(Generation)}: {Generation}";

            public MinInt Act(MinInt monoid) => new MinInt(Value);

            public Updater Multiply(Updater other) => Generation > other.Generation ? this : other;

            public override bool Equals(object obj)
            {
                return obj is Updater updater && Equals(updater);
            }

            public bool Equals(Updater other)
            {
                return Value == other.Value;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Value, Generation);
            }
        }

        public interface IMonoidWithAct<TMonoid, TOperator> : IMonoid<TOperator>
            where TMonoid : IMonoid<TMonoid>, new()
            where TOperator : IMonoid<TOperator>, new()
        {
            public TMonoid Act(TMonoid monoid);
        }

        public class LazySegmentTree<TMonoid, TOperator>
            where TMonoid : IMonoid<TMonoid>, new()
            where TOperator : IMonoidWithAct<TMonoid, TOperator>, IEquatable<TOperator>, new()
        {
            protected readonly TMonoid[] _data;
            private readonly TOperator[] _lazy;
            private readonly TMonoid _monoidIdenty;
            private readonly TOperator _operatorIdentity;

            protected readonly int _leafOffset;  // n - 1
            protected readonly int _leafLength;  // n (= 2^k)

            public int Length { get; }

            public LazySegmentTree(ICollection<TMonoid> data)
            {
                Length = data.Count;
                _leafLength = GetMinimumPow2(data.Count);
                _leafOffset = _leafLength - 1;
                _data = new TMonoid[_leafOffset + _leafLength];
                _monoidIdenty = new TMonoid().Identity;
                _operatorIdentity = new TOperator().Identity;

                data.CopyTo(_data, _leafOffset);
                BuildTree();
                _lazy = Enumerable.Repeat(_operatorIdentity, _data.Length).ToArray();
            }

            protected void LazyEvaluate(int index)
            {
                if (_lazy[index].Equals(_operatorIdentity))
                {
                    return;
                }
                else if (index < _leafOffset) // 葉でない場合は子に伝播
                {
                    var left = (index << 1) + 1;
                    var right = left + 1;
                    _lazy[left] = _lazy[index].Multiply(_lazy[left]);
                    _lazy[right] = _lazy[index].Multiply(_lazy[right]);
                }

                // 自身を更新
                _data[index] = _lazy[index].Act(_data[index]);
                _lazy[index] = _operatorIdentity;
            }

            public void Update(int begin, int end, TOperator op)
            {
                if (begin < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(begin));
                }
                if (end > Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(end));
                }
                if (begin >= end)
                {
                    throw new ArgumentException($"{nameof(end)} must be grater than {nameof(begin)}");
                }
                Update(begin, end, op, 0, 0, _leafLength);
            }

            private void Update(int begin, int end, TOperator op, int index, int left, int right)
            {
                LazyEvaluate(index);
                if (begin <= left && right <= end) // 全部含まれる
                {
                    _lazy[index] = _lazy[index].Multiply(op);
                    LazyEvaluate(index);
                }
                else if (begin < right && left < end) // 一部だけ含まれる
                {
                    var l = (index << 1) + 1;
                    var r = l + 1;
                    Update(begin, end, op, l, left, (left + right) / 2);
                    Update(begin, end, op, r, (left + right) / 2, right);
                    _data[index] = _data[l].Multiply(_data[r]);
                }
            }

            public TMonoid Query(int begin, int end)
            {
                if (begin < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(begin));
                }
                if (end > Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(end));
                }
                if (begin >= end)
                {
                    throw new ArgumentException($"{nameof(end)} must be grater than {nameof(begin)}");
                }
                return Query(begin, end, 0, 0, _leafLength);
            }

            private TMonoid Query(int begin, int end, int index, int left, int right)
            {
                LazyEvaluate(index);
                if (right <= begin || end <= left)      // 範囲外
                {
                    return _monoidIdenty;
                }
                else if (begin <= left && right <= end) // 全部含まれる
                {
                    return _data[index];
                }
                else    // 一部だけ含まれる
                {
                    var l = (index << 1) + 1;
                    var r = l + 1;
                    var leftValue = Query(begin, end, l, left, (left + right) / 2);     // 左の子
                    var rightValue = Query(begin, end, r, (left + right) / 2, right);   // 右の子
                    return leftValue.Multiply(rightValue);
                }
            }

            private void BuildTree()
            {
                foreach (ref var unusedLeaf in _data.AsSpan()[(_leafOffset + Length)..])
                {
                    unusedLeaf = _monoidIdenty;  // 単位元埋め
                }

                for (int i = _leafLength - 2; i >= 0; i--)  // 葉の親から順番に一つずつ上がっていく
                {
                    var left = (i << 1) + 1;
                    var right = left + 1;
                    _data[i] = _data[left].Multiply(_data[right]); // f(left, right)
                }
            }

            private int GetMinimumPow2(int n)
            {
                var p = 1;
                while (p < n)
                {
                    p <<= 1;
                }
                return p;
            }
        }

    }
}
