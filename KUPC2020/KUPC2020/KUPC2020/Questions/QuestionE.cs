using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using KUPC2020.Algorithms;
using KUPC2020.Collections;
using KUPC2020.Numerics;
using KUPC2020.Questions;
using System.Numerics;

namespace KUPC2020.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        const long Inf = 1L << 55;

        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);
            var b = io.ReadIntArray(n);
            var c = io.ReadIntArray(n);

            var segtree = new LazySegmentTree<MaxLong, Adder>(n + 1);
            segtree[0] = new MaxLong(b[0]);

            for (int i = 0; i < a.Length; i++)
            {
                segtree.Apply(0, i + 1, new Adder(a[i]));
                var max = segtree.Query(0, i + 1);

            }
        }

        readonly struct MaxLong : IMonoid<MaxLong>
        {
            public readonly long Value;

            public MaxLong(long value)
            {
                Value = value;
            }

            public MaxLong Identity => new MaxLong(-Inf);

            public MaxLong Merge(MaxLong other) => Value < other.Value ? this : other;

            public override string ToString() => Value.ToString();
        }

        readonly struct Adder : IMonoidWithAct<MaxLong, Adder>
        {
            public readonly long Value;

            public Adder(long value)
            {
                Value = value;
            }

            public Adder Identity => new Adder();

            public MaxLong Act(MaxLong monoid) => new MaxLong(monoid.Value + Value);

            public Adder Merge(Adder other) => new Adder(Value + other.Value);
        }

        public class SegmentTree<T> where T : struct, IMonoid<T>
        {
            // 1-indexed
            protected readonly T[] _data;

            public int Length { get; }
            protected Span<T> Leaves => _data.AsSpan(HalfLength);
            protected int HalfLength => _data.Length >> 1;

            /// <summary>
            /// 単位元で初期化します。
            /// </summary>
            public SegmentTree(int n) : this(n, default(T).Identity) { }

            /// <summary>
            /// 指定した値で初期化します。
            /// </summary>
            public SegmentTree(int n, T initialValue)
            {
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                Length = n;
                _data = new T[1 << (CeilPow2(n) + 1)];
                _data.AsSpan(HalfLength, Length).Fill(initialValue);
                Build();
            }

            /// <summary>
            /// 指定したデータ列で初期化します。
            /// </summary>
            public SegmentTree(ReadOnlySpan<T> values)
            {
                Length = values.Length;
                _data = new T[1 << (CeilPow2(values.Length) + 1)];
                values.CopyTo(Leaves);
                Build();
            }

            public virtual T this[int index]
            {
                get => Leaves[index];
                set
                {
                    Leaves[index] = value;
                    index += HalfLength;
                    while ((index >>= 1) > 0)
                    {
                        _data[index] = _data[(index << 1) + 0].Merge(_data[(index << 1) + 1]);
                    }
                }
            }

            public T Query(Range range) => Query(range.Start, range.End);

            public T Query(Index left, Index right) => Query(left.GetOffset(Length), right.GetOffset(Length));

            public virtual T Query(int left, int right)
            {
                if (unchecked((uint)left > (uint)Length || (uint)right > (uint)Length || left > right))
                {
                    throw new ArgumentOutOfRangeException();
                }

                var sumL = default(T).Identity;
                var sumR = default(T).Identity;
                left += HalfLength;
                right += HalfLength;

                while (left < right)
                {
                    if ((left & 1) > 0)
                    {
                        sumL = sumL.Merge(_data[left++]);
                    }
                    if ((right & 1) > 0)
                    {
                        sumR = _data[--right].Merge(sumR);
                    }
                    left >>= 1;
                    right >>= 1;
                }

                return sumL.Merge(sumR);
            }

            public T QueryAll() => _data[1];

            private void Build()
            {
                var parents = HalfLength;
                _data.AsSpan(parents + Length).Fill(default(T).Identity);
                for (int i = parents - 1; i >= 0; i--)
                {
                    _data[i] = _data[(i << 1) + 0].Merge(_data[(i << 1) + 1]);
                }
            }

            /// <summary>
            /// [l, r)が条件を満たす最大のrを求めます。
            /// </summary>
            public int FindMaxRight(Index left, Predicate<T> predicate) => FindMaxRight(left.GetOffset(Length), predicate);

            /// <summary>
            /// [l, r)が条件を満たす最大のrを求めます。
            /// </summary>
            public virtual int FindMaxRight(int left, Predicate<T> predicate)
            {
                // 単位元は条件式を満たす必要がある
                Debug.Assert(predicate(default(T).Identity));

                if (unchecked((uint)left > Length))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (left == Length)
                {
                    return Length;
                }

                var right = left + HalfLength;
                var sum = default(T).Identity;

                do
                {
                    right >>= BitOperations.TrailingZeroCount(right);
                    var merged = sum.Merge(_data[right]);
                    if (!predicate(merged))
                    {
                        return DownSearch(right, sum, predicate);
                    }

                    sum = merged;
                    right++;
                } while ((right & -right) != right);

                return Length;

                int DownSearch(int right, T sum, Predicate<T> predicate)
                {
                    while (right < HalfLength)
                    {
                        right <<= 1;
                        var merged = sum.Merge(_data[right]);
                        if (predicate(merged))
                        {
                            sum = merged;
                            right++;
                        }
                    }
                    return right - HalfLength;
                }
            }

            /// <summary>
            /// [l, r)が条件を満たす最小のlを求めます。
            /// </summary>
            public int FindMinLeft(Index right, Predicate<T> predicate) => FindMinLeft(right.GetOffset(Length), predicate);

            /// <summary>
            /// [l, r)が条件を満たす最小のlを求めます。
            /// </summary>
            public virtual int FindMinLeft(int right, Predicate<T> predicate)
            {
                // 単位元は条件式を満たす必要がある
                Debug.Assert(predicate(default(T).Identity));

                if (unchecked((uint)right > Length))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (right == 0)
                {
                    return 0;
                }

                var left = right + HalfLength;
                var sum = default(T).Identity;

                do
                {
                    left--;
                    left >>= BitOperations.TrailingZeroCount((1 << BitOperations.Log2((uint)left)) | ~left);

                    var merged = _data[left].Merge(sum);
                    if (!predicate(merged))
                    {
                        return DownSearch(left, sum, predicate);
                    }

                    sum = merged;
                } while ((left & -left) != left);

                return 0;

                int DownSearch(int left, T sum, Predicate<T> predicate)
                {
                    while (left < HalfLength)
                    {
                        left = (left << 1) + 1;
                        var merged = _data[left].Merge(sum);
                        if (predicate(merged))
                        {
                            sum = merged;
                            left--;
                        }
                    }
                    return left + 1 - HalfLength;
                }
            }

            protected static int CeilPow2(int n)
            {
                var m = (uint)n;
                if (m <= 1)
                {
                    return 0;
                }
                else
                {
                    return BitOperations.Log2(m - 1) + 1;
                }
            }
        }

        public class LazySegmentTree<TValue, TLazy> : SegmentTree<TValue>
            where TValue : struct, IMonoid<TValue>
            where TLazy : struct, IMonoidWithAct<TValue, TLazy>
        {
            // 1-indexed
            protected readonly TLazy[] _lazies;
            private readonly int _log;

            /// <summary>
            /// 単位元で初期化します。
            /// </summary>
            public LazySegmentTree(int n) : this(n, default(TValue).Identity) { }

            /// <summary>
            /// 指定した値で初期化します。
            /// </summary>
            public LazySegmentTree(int n, TValue initialValue) : base(n, initialValue)
            {
                _lazies = new TLazy[_data.Length];
                _lazies.AsSpan().Fill(default(TLazy).Identity);
                _log = CeilPow2(n);
            }

            /// <summary>
            /// 指定したデータ列で初期化します。
            /// </summary>
            public LazySegmentTree(ReadOnlySpan<TValue> values) : base(values)
            {
                _lazies = new TLazy[_data.Length];
                _lazies.AsSpan().Fill(default(TLazy).Identity);
                _log = CeilPow2(values.Length);
            }

            public override TValue this[int index]
            {
                get
                {
                    var i = index + HalfLength;
                    for (int l = _log; l >= 1; l--)
                    {
                        LazyEvaluate(i >> l);
                    }

                    return Leaves[index];
                }
                set
                {
                    var i = index + HalfLength;
                    for (int l = _log; l >= 1; l--)
                    {
                        LazyEvaluate(i >> l);
                    }

                    Leaves[index] = value;

                    for (int l = 1; l <= _log; l++)
                    {
                        UpdateMonoid(i >> l);
                    }
                }
            }

            public override TValue Query(int left, int right)
            {
                if (unchecked((uint)left > (uint)Length || (uint)right > (uint)Length || left > right))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (left == right)
                {
                    return default(TValue).Identity;
                }

                var l = left + HalfLength;
                var r = right + HalfLength;

                for (int i = _log; i >= 1; i--)
                {
                    // 末尾が..000となっているものは更新不要
                    if (((l >> i) << i) != l)
                    {
                        LazyEvaluate(l >> i);
                    }
                    if (((r >> i) << i) != r)
                    {
                        LazyEvaluate(r >> i);
                    }
                }

                return base.Query(left, right);
            }

            public void Apply(Index index, TLazy actor) => Apply(index.GetOffset(Length), actor);

            public void Apply(int index, TLazy actor)
            {
                if (unchecked((uint)index >= (uint)Length))
                {
                    throw new ArgumentOutOfRangeException();
                }

                index += HalfLength;

                for (int i = _log; i >= 1; i--)
                {
                    LazyEvaluate(index >> i);
                }

                _data[index] = actor.Act(_data[index]);

                for (int i = 1; i <= _log; i++)
                {
                    UpdateMonoid(index >> i);
                }
            }

            public void Apply(Range range, TLazy actor) => Apply(range.Start, range.End, actor);

            public void Apply(Index left, Index right, TLazy actor) => Apply(left.GetOffset(Length), right.GetOffset(Length), actor);

            public void Apply(int left, int right, TLazy actor)
            {
                if (unchecked((uint)left > (uint)Length || (uint)right > (uint)Length || left > right))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (left == right)
                {
                    return;
                }

                var l = left + HalfLength;
                var r = right + HalfLength;

                for (int i = _log; i >= 1; i--)
                {
                    // 末尾が..000となっているものは更新不要
                    if (((l >> i) << i) != l)
                    {
                        LazyEvaluate(l >> i);
                    }
                    if (((r >> i) << i) != r)
                    {
                        LazyEvaluate((r - 1) >> i);
                    }
                }

                while (l < r)
                {
                    if ((l & 1) > 0)
                    {
                        ApplyLazy(l++, actor);
                    }
                    if ((r & 1) > 0)
                    {
                        ApplyLazy(--r, actor);
                    }
                    l >>= 1;
                    r >>= 1;
                }

                l = left + HalfLength;
                r = right + HalfLength;

                for (int i = 1; i <= _log; i++)
                {
                    if (((l >> i) << i) != l)
                    {
                        UpdateMonoid(l >> i);
                    }
                    if (((r >> i) << i) != r)
                    {
                        UpdateMonoid((r - 1) >> i);
                    }
                }
            }

            /// <summary>
            /// [l, r)が条件を満たす最大のrを求めます。
            /// </summary>
            public override int FindMaxRight(int left, Predicate<TValue> predicate)
            {
                // 単位元は条件式を満たす必要がある
                Debug.Assert(predicate(default(TValue).Identity));

                if (unchecked((uint)left > Length))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (left == Length)
                {
                    return Length;
                }

                var right = left + HalfLength;
                var sum = default(TValue).Identity;

                for (int i = _log; i >= 1; i--)
                {
                    LazyEvaluate(right >> i);
                }

                do
                {
                    right >>= BitOperations.TrailingZeroCount(right);
                    var merged = sum.Merge(_data[right]);

                    if (!predicate(merged))
                    {
                        return DownSearch(right, sum, predicate);
                    }

                    sum = merged;
                    right++;
                } while ((right & -right) != right);

                return Length;

                int DownSearch(int right, TValue sum, Predicate<TValue> predicate)
                {
                    while (right < HalfLength)
                    {
                        LazyEvaluate(right);
                        right <<= 1;
                        var merged = sum.Merge(_data[right]);
                        if (predicate(merged))
                        {
                            sum = merged;
                            right++;
                        }
                    }
                    return right - HalfLength;
                }
            }

            /// <summary>
            /// [l, r)が条件を満たす最小のlを求めます。
            /// </summary>
            public override int FindMinLeft(int right, Predicate<TValue> predicate)
            {
                // 単位元は条件式を満たす必要がある
                Debug.Assert(predicate(default(TValue).Identity));

                if (unchecked((uint)right > Length))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (right == 0)
                {
                    return 0;
                }

                var left = right + HalfLength;
                var sum = default(TValue).Identity;

                for (int i = _log; i >= 1; i--)
                {
                    LazyEvaluate((left - 1) >> i);
                }

                do
                {
                    left--;
                    left >>= BitOperations.TrailingZeroCount((1 << BitOperations.Log2((uint)left)) | ~left);

                    var merged = _data[left].Merge(sum);
                    if (!predicate(merged))
                    {
                        return DownSearch(left, sum, predicate);
                    }

                    sum = merged;
                } while ((left & -left) != left);

                return 0;

                int DownSearch(int left, TValue sum, Predicate<TValue> predicate)
                {
                    while (left < HalfLength)
                    {
                        LazyEvaluate(left);
                        left = (left << 1) + 1;
                        var merged = _data[left].Merge(sum);
                        if (predicate(merged))
                        {
                            sum = merged;
                            left--;
                        }
                    }
                    return left + 1 - HalfLength;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void UpdateMonoid(int index) => _data[index] = _data[(index << 1) + 0].Merge(_data[(index << 1) + 1]);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void ApplyLazy(int index, TLazy actor)
            {
                _data[index] = actor.Act(_data[index]);
                // 自身が葉でない場合
                if (index < HalfLength)
                {
                    _lazies[index] = actor.Merge(_lazies[index]);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void LazyEvaluate(int index)
            {
                ref var lazy = ref _lazies[index];
                ApplyLazy((index << 1) + 0, lazy);
                ApplyLazy((index << 1) + 1, lazy);
                lazy = default(TLazy).Identity;
            }
        }


    }
}
