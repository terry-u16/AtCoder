using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest177.Algorithms;
using AtCoderBeginnerContest177.Collections;
using AtCoderBeginnerContest177.Extensions;
using AtCoderBeginnerContest177.Numerics;
using AtCoderBeginnerContest177.Questions;

namespace AtCoderBeginnerContest177.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var segTree = new LazySegmentTree<IndexAndMinInt, Offset>(
                Enumerable.Range(0, width).Select(i => new IndexAndMinInt(i, 0)).ToArray());
            const int Inf = 1 << 28;

            for (int row = 0; row < height; row++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                if (a > 0)
                {
                    var left = segTree.Query(a - 1, a).Value;
                    segTree.Update(a, b, new Offset(a, left + 1));
                }
                else
                {
                    segTree.Update(a, b, new Offset(a, Inf << 2));
                }

                var min = segTree.Query(0, width).Value;
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

        [StructLayout(LayoutKind.Auto)]
        readonly struct IndexAndMinInt : IMonoid<IndexAndMinInt>
        {
            public int Index { get; }
            public long Value { get; }

            public IndexAndMinInt Identity => new IndexAndMinInt(0, (1L << 50));

            public IndexAndMinInt(int index, long value)
            {
                Index = index;
                Value = value;
            }

            public void Deconstruct(out int index, out long value) => (index, value) = (Index, Value);
            public override string ToString() => $"{nameof(Index)}: {Index}, {nameof(Value)}: {Value}";

            public IndexAndMinInt Multiply(IndexAndMinInt other)
            {
                var comp = Value - other.Value;
                if (comp != 0)
                {
                    return comp < 0 ? this : other;
                }
                else
                {
                    return Index < other.Index ? this : other;
                }
            }
        }

        readonly struct Offset : IMonoidWithAct<IndexAndMinInt, Offset>, IEquatable<Offset>
        {
            public Offset Identity => new Offset(0, int.MinValue);

            public long Value { get; }

            public Offset(int startIndex, long value)
            {
                Value = value - startIndex;
            }

            public IndexAndMinInt Act(IndexAndMinInt monoid) => new IndexAndMinInt(monoid.Index, Math.Max(monoid.Value, monoid.Index + Value));

            public Offset Multiply(Offset other) => Value < other.Value ? other : this;

            public override bool Equals(object obj)
            {
                return obj is Offset offset && Equals(offset);
            }

            public bool Equals(Offset other)
            {
                return Value == other.Value;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Value);
            }

            public static bool operator ==(Offset left, Offset right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Offset left, Offset right)
            {
                return !(left == right);
            }

            public override string ToString() => Value.ToString();
        }

        public class LazySegmentTree<TMonoid, TOperator>
            where TMonoid : IMonoid<TMonoid>, new()
            where TOperator : IMonoidWithAct<TMonoid, TOperator>, IEquatable<TOperator>, new()
        {
            private readonly TMonoid[] _data;
            private readonly TOperator[] _lazy;
            private readonly TMonoid _monoidIdenty;
            private readonly TOperator _operatorIdentity;

            private readonly int _leafOffset;  // n - 1
            private readonly int _leafLength;  // n (= 2^k)

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

            private void LazyEvaluate(int index)
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

        public interface IMonoidWithAct<TMonoid, TOperator> : IMonoid<TOperator>
            where TMonoid : IMonoid<TMonoid>, new()
            where TOperator : IMonoid<TOperator>, new()
        {
            public TMonoid Act(TMonoid monoid);
        }
    }
}