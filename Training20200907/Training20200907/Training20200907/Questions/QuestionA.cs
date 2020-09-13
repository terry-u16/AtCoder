using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200907.Extensions;
using Training20200907.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Training20200907.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = 998244353;
            var (_, queries) = inputStream.ReadValue<int, int>();
            var lazySegTree = new LazySegmentTree<ModSum, AffineActor>(inputStream.ReadIntArray().Select(i => new ModSum(i, 1)).ToArray());

            for (int q = 0; q < queries; q++)
            {
                var query = inputStream.ReadIntArray();
                var l = query[1];
                var r = query[2];

                if (query[0] == 0)
                {
                    var b = query[3];
                    var c = query[4];
                    lazySegTree.Update(l, r, new AffineActor(b, c));
                }
                else
                {
                    yield return lazySegTree.Query(l, r).Value;
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct ModSum : IMonoid<ModSum>
        {
            public Modular Value { get; }
            public int Length { get; }

            public ModSum Identity => new ModSum(0, 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ModSum(Modular value, int length)
            {
                Value = value;
                Length = length;
            }

            public void Deconstruct(out Modular value, out Modular length) => (value, length) = (Value, Length);
            public override string ToString() => $"{nameof(Value)}: {Value}, {nameof(Length)}: {Length}";

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ModSum Multiply(ModSum other) => new ModSum(Value + other.Value, Length + other.Length);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct AffineActor : IMonoidWithAct<ModSum, AffineActor>, IEquatable<AffineActor>
        {
            public Modular B { get; }
            public Modular C { get; }

            public AffineActor Identity => new AffineActor(1, 0);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public AffineActor(Modular b, Modular c)
            {
                B = b;
                C = c;
            }

            public void Deconstruct(out Modular b, out Modular c) => (b, c) = (B, C);
            public override string ToString() => $"{nameof(B)}: {B}, {nameof(C)}: {C}";

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public ModSum Act(ModSum monoid) => new ModSum(B * monoid.Value + C * monoid.Length, monoid.Length);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public AffineActor Multiply(AffineActor other) => new AffineActor(B * other.B, B * other.C + C);

            public override bool Equals(object obj) => obj is AffineActor actor && Equals(actor);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(AffineActor other) => B == other.B && C == other.C;

            public override int GetHashCode() => HashCode.Combine(B, C);
        }

        public interface ISemigroup<TSet> where TSet : ISemigroup<TSet>
        {
            public TSet Multiply(TSet other);
            public static TSet operator *(ISemigroup<TSet> a, TSet b) => a.Multiply(b);
        }

        public interface IMonoid<TSet> : ISemigroup<TSet> where TSet : IMonoid<TSet>, new()
        {
            public TSet Identity { get; }
        }

        public interface IMonoidWithAct<TMonoid, TOperator> : IMonoid<TOperator>
            where TMonoid : IMonoid<TMonoid>, new()
            where TOperator : IMonoid<TOperator>, new()
        {
            public TMonoid Act(TMonoid monoid);
        }

        public interface IGroup<TSet> : IMonoid<TSet> where TSet : IGroup<TSet>, new()
        {
            public TSet Invert();
            public static TSet operator ~(IGroup<TSet> a) => a.Invert();
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

        public readonly struct Modular : IEquatable<Modular>, IComparable<Modular>
        {
            private const int DefaultMod = 1000000007;
            public int Value { get; }
            public static int Mod { get; set; } = DefaultMod;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Modular(long value)
            {
                if (unchecked((ulong)value) < unchecked((ulong)Mod))
                {
                    Value = (int)value;
                }
                else
                {
                    Value = (int)(value % Mod);
                    if (Value < 0)
                    {
                        Value += Mod;
                    }
                }
            }

            private Modular(int value) => Value = value;
            public static Modular Zero => new Modular(0);
            public static Modular One => new Modular(1);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator +(Modular a, Modular b)
            {
                var result = a.Value + b.Value;
                if (result >= Mod)
                {
                    result -= Mod;    // 剰余演算を避ける
                }
                return new Modular(result);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator -(Modular a, Modular b)
            {
                var result = a.Value - b.Value;
                if (result < 0)
                {
                    result += Mod;    // 剰余演算を避ける
                }
                return new Modular(result);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator *(Modular a, Modular b) => new Modular((long)a.Value * b.Value);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Modular operator /(Modular a, Modular b) => a * Pow(b.Value, Mod - 2);

            // 需要は不明だけど一応
            public static bool operator ==(Modular left, Modular right) => left.Equals(right);
            public static bool operator !=(Modular left, Modular right) => !(left == right);
            public static bool operator <(Modular left, Modular right) => left.CompareTo(right) < 0;
            public static bool operator <=(Modular left, Modular right) => left.CompareTo(right) <= 0;
            public static bool operator >(Modular left, Modular right) => left.CompareTo(right) > 0;
            public static bool operator >=(Modular left, Modular right) => left.CompareTo(right) >= 0;

            public static implicit operator Modular(long a) => new Modular(a);
            public static explicit operator int(Modular a) => a.Value;
            public static explicit operator long(Modular a) => a.Value;

            public static Modular Pow(int a, int n)
            {
                if (n == 0)
                {
                    return Modular.One;
                }
                else if (n == 1)
                {
                    return a;
                }
                else if (n > 0)
                {
                    var p = Pow(a, n >> 1);             // m / 2
                    return p * p * Pow(a, n & 0x01);    // m % 2
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(n), $"べき指数{nameof(n)}は0以上の整数でなければなりません。");
                }
            }

            private static List<int> _factorialCache;
            private static List<int> FactorialCache => _factorialCache ??= new List<int>() { 1 };
            private static int[] FactorialInverseCache { get; set; }
            const int defaultMaxFactorial = 1000000;

            public static Modular Factorial(int n)
            {
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は0以上の整数でなければなりません。");
                }

                for (int i = FactorialCache.Count; i <= n; i++)  // Countが1（0!までキャッシュ済み）のとき1!～n!まで計算
                {
                    FactorialCache.Add((int)((long)FactorialCache[i - 1] * i % Mod));
                }
                return new Modular(FactorialCache[n]);
            }

            public static Modular Permutation(int n, int r)
            {
                CheckNR(n, r);
                return Factorial(n) / Factorial(n - r);
            }

            public static Modular Combination(int n, int r)
            {
                CheckNR(n, r);
                r = Math.Min(r, n - r);
                try
                {
                    return new Modular(FactorialCache[n]) * new Modular(FactorialInverseCache[r]) * new Modular(FactorialInverseCache[n - r]);
                }
                catch (Exception ex) when (ex is NullReferenceException || ex is ArgumentOutOfRangeException)
                {
                    throw new InvalidOperationException($"{nameof(Combination)}を呼び出す前に{nameof(InitializeCombinationTable)}により前計算を行う必要があります。", ex);
                }
            }

            public static void InitializeCombinationTable(int max = defaultMaxFactorial)
            {
                Factorial(max);
                FactorialInverseCache = new int[max + 1];

                var fInv = (Modular.One / Factorial(max)).Value;
                FactorialInverseCache[max] = fInv;
                for (int i = max - 1; i >= 0; i--)
                {
                    fInv = (int)((long)fInv * (i + 1) % Mod);
                    FactorialInverseCache[i] = fInv;
                }
            }

            public static Modular CombinationWithRepetition(int n, int r) => Combination(n + r - 1, r);

            private static void CheckNR(int n, int r)
            {
                if (n < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は0以上の整数でなければなりません。");
                }
                if (r < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(r), $"{nameof(r)}は0以上の整数でなければなりません。");
                }
                if (n < r)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(n)},{nameof(r)}", $"{nameof(r)}は{nameof(n)}以下でなければなりません。");
                }
            }

            public override string ToString() => Value.ToString();
            public override bool Equals(object obj) => obj is Modular m ? Equals(m) : false;
            public bool Equals([System.Diagnostics.CodeAnalysis.AllowNull] Modular other) => Value == other.Value;
            public int CompareTo([System.Diagnostics.CodeAnalysis.AllowNull] Modular other) => Value.CompareTo(other.Value);
            public override int GetHashCode() => Value.GetHashCode();
        }
    }
}
