using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200907.Extensions;
using Training20200907.Questions;
using System.Diagnostics;
using AtCoder.Math;
using ModInteger = AtCoder.Math.ModInt<AtCoder.Math.Mod998244353>;
using AtCoder.Internal;
using System.Numerics;
using AtCoder;

namespace Training20200907.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, queries) = inputStream.ReadValue<int, int>();
            var lazySegTree = new LazySegtree<ModSum, AffineActor, Op>(inputStream.ReadIntArray().Select(ai => new ModSum(ai, 1)).ToArray());

            for (int q = 0; q < queries; q++)
            {
                var query = inputStream.ReadIntArray();
                var l = query[1];
                var r = query[2];

                if (query[0] == 0)
                {
                    var b = query[3];
                    var c = query[4];
                    lazySegTree.Apply(l, r, new AffineActor(b, c));
                }
                else
                {
                    yield return lazySegTree.Prod(l, r).Value;
                }
            }
        }

        readonly struct Op : IMonoidFuncOperator<ModSum, AffineActor>
        {
            public ModSum Identity => new ModSum(0, 0);

            public AffineActor FIdentity => new AffineActor(1, 0);

            public AffineActor Composition(AffineActor f, AffineActor g) => new AffineActor(f.B * g.B, f.B * g.C + f.C);
            public ModSum Mapping(AffineActor f, ModSum x) => new ModSum(f.B * x.Value + f.C * x.Length, x.Length);
            public ModSum Operate(ModSum x, ModSum y) => new ModSum(x.Value + y.Value, x.Length + y.Length);
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct ModSum
        {
            public ModInteger Value { get; }
            public int Length { get; }

            public ModSum(ModInteger value, int length)
            {
                Value = value;
                Length = length;
            }

            public void Deconstruct(out ModInteger value, out ModInteger length) => (value, length) = (Value, Length);
            public override string ToString() => $"{nameof(Value)}: {Value}, {nameof(Length)}: {Length}";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct AffineActor
        {
            public ModInteger B { get; }
            public ModInteger C { get; }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public AffineActor(ModInteger b, ModInteger c)
            {
                B = b;
                C = c;
            }

            public void Deconstruct(out ModInteger b, out ModInteger c) => (b, c) = (B, C);
            public override string ToString() => $"{nameof(B)}: {B}, {nameof(C)}: {C}";
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
    }
}

namespace AtCoder.Math
{
    public interface IMod
    {
        uint Mod { get; }
        bool IsPrime { get; }
    }

    public readonly struct Mod1000000007 : IMod
    {
        public uint Mod => 1000000007;
        public bool IsPrime => true;
    }

    public readonly struct Mod998244353 : IMod
    {
        public uint Mod => 998244353;
        public bool IsPrime => true;
    }

    public readonly struct ModDynamic : IMod
    {
        private static uint _mod = 1000000007;
        private static bool _isPrime = true;

        public static void SetMod(uint mod, bool isPrime)
        {
            _mod = mod;
            _isPrime = isPrime;
        }

        public uint Mod => _mod;
        public bool IsPrime => _isPrime;
    }

    public readonly struct ModInt<T> where T : IMod
    {
        public uint Value { get; }

        public static int Mod => (int)default(T).Mod;
        public static ModInt<T> Raw(int v) => new ModInt<T>((uint)v);

        public ModInt(long v)
        {
            var x = v % default(T).Mod;
            if (x < 0)
            {
                x += default(T).Mod;
            }
            Value = (uint)x;
        }

        private ModInt(uint v) => Value = v;

        public static ModInt<T> operator ++(ModInt<T> value)
        {
            var v = value.Value + 1;
            if (v == default(T).Mod)
            {
                v = 0;
            }
            return new ModInt<T>(v);
        }

        public static ModInt<T> operator --(ModInt<T> value)
        {
            var v = value.Value;
            if (v == default(T).Mod)
            {
                v = default(T).Mod;
            }
            return new ModInt<T>(v - 1);
        }

        public static ModInt<T> operator +(ModInt<T> lhs, ModInt<T> rhs)
        {
            var v = lhs.Value + rhs.Value;
            if (v >= default(T).Mod)
            {
                v -= default(T).Mod;
            }
            return new ModInt<T>(v);
        }

        public static ModInt<T> operator -(ModInt<T> lhs, ModInt<T> rhs)
        {
            unchecked
            {
                var v = lhs.Value - rhs.Value;
                if (v >= default(T).Mod)
                {
                    v += default(T).Mod;
                }
                return new ModInt<T>(v);
            }
        }

        public static ModInt<T> operator *(ModInt<T> lhs, ModInt<T> rhs)
        {
            ulong z = lhs.Value;
            z *= rhs.Value;
            return new ModInt<T>((uint)(z % default(T).Mod));
        }

        public static ModInt<T> operator /(ModInt<T> lhs, ModInt<T> rhs) => lhs * rhs.Inv();

        public static ModInt<T> operator +(ModInt<T> value) => value;
        public static ModInt<T> operator -(ModInt<T> value) => new ModInt<T>() - value;
        public static bool operator ==(ModInt<T> lhs, ModInt<T> rhs) => lhs.Value == rhs.Value;
        public static bool operator !=(ModInt<T> lhs, ModInt<T> rhs) => lhs.Value != rhs.Value;
        public static implicit operator ModInt<T>(long value) => new ModInt<T>(value);

        public ModInt<T> Pow(long n)
        {
            Debug.Assert(0 <= n);
            var x = this;
            var r = new ModInt<T>(1U);

            while (n > 0)
            {
                if ((n & 1) > 0)
                {
                    r *= x;
                }
                x *= x;
                n >>= 1;
            }

            return r;
        }

        public ModInt<T> Inv()
        {
            // Mod が素数でなくても InvGCD の方が高速？要検証
            if (default(T).IsPrime)
            {
                Debug.Assert(Value > 0);
                return Pow(default(T).Mod - 2);
            }
            else
            {
                var (g, x) = Internal.InternalMath.InvGCD(Value, default(T).Mod);
                Debug.Assert(g == 1);
                return new ModInt<T>(x);
            }
        }

        public override string ToString() => Value.ToString();
        public override bool Equals(object obj) => obj is ModInt<T> && this == (ModInt<T>)obj;
        public override int GetHashCode() => Value.GetHashCode();
    }
}

namespace AtCoder.Internal
{
    public static partial class InternalMath
    {
        public static long SafeMod(long x, long m)
        {
            x %= m;
            if (x < 0) x += m;
            return x;
        }
    }
}

namespace AtCoder.Internal
{
    public static partial class InternalMath
    {
        /// <summary>
        /// g=gcd(a,b),xa=g(mod b) となるような 0≤x&lt;b/g の(g, x)
        /// </summary>
        /// <remarks>
        /// <para>制約: 1≤<paramref name="b"/></para>
        /// </remarks>
        public static (long, long) InvGCD(long a, long b)
        {
            a = SafeMod(a, b);
            if (a == 0) return (b, 0);

            long s = b, t = a;
            long m0 = 0, m1 = 1;

            long u;
            while (true)
            {
                if (t == 0)
                {
                    if (m0 < 0) m0 += b / s;
                    return (s, m0);
                }
                u = s / t;
                s -= t * u;
                m0 -= m1 * u;

                if (s == 0)
                {
                    if (m1 < 0) m1 += b / t;
                    return (t, m1);
                }
                u = t / s;
                t -= s * u;
                m1 -= m0 * u;
            }
        }
    }
}

namespace AtCoder
{
    /// <summary>
    /// モノイドを定義するインターフェイスです。
    /// </summary>
    /// <typeparam name="T">操作を行う型。</typeparam>
    /// <typeparam name="F">写像の型。</typeparam>
    public interface IMonoidFuncOperator<T, F>
    {
        /// <summary>
        /// Operate(x, <paramref name="Identity"/>) = x を満たす単位元。
        /// </summary>
        T Identity { get; }
        /// <summary>
        /// Mapping(<paramref name="FIdentity"/>, x) = x を満たす恒等写像。
        /// </summary>
        F FIdentity { get; }
        /// <summary>
        /// 結合律 Operate(Operate(a, b), c) = Operate(a, Operate(b, c)) を満たす写像。
        /// </summary>
        T Operate(T x, T y);
        /// <summary>
        /// 写像　<paramref name="f"/> を <paramref name="x"/> に作用させる関数。
        /// </summary>
        T Mapping(F f, T x);
        /// <summary>
        /// 写像　<paramref name="f"/>, <paramref name="g"/> を 合成した写像 <paramref name="f"/>∘<paramref name="g"/>。
        /// </summary>
        F Composition(F f, F g);
    }

    /// <summary>
    /// 長さ N の配列に対し、
    /// <list type="bullet">
    /// <item>
    /// <description>区間の要素に一括で <typeparamref name="TOp"/> の要素 f を作用 ( x=f(x) )</description>
    /// </item>
    /// <item>
    /// <description>区間の要素の総積の取得</description>
    /// </item>
    /// </list>
    /// <para>を O(log N) で求めることが出来るデータ構造です。</para>
    /// </summary>
    [DebuggerTypeProxy(typeof(LazySegtree<,,>.DebugView))]
    public class LazySegtree<TValue, F, TOp> where TOp : struct, IMonoidFuncOperator<TValue, F>
    {
        private static readonly TOp op = default;

        /// <summary>
        /// 数列 a の長さ n を返します。
        /// </summary>
        public int Length { get; }

        private readonly int log;
        private readonly int size;
        private readonly TValue[] d;
        private readonly F[] lz;


        /// <summary>
        /// 長さ <paramref name="n"/> の数列 a　を持つ <see cref="LazySegtree{TValue, TOp}"/> クラスの新しいインスタンスを作ります。初期値は <see cref="TOp.Identity"/> です。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/>≤10^8</para>
        /// <para>計算量: O(<paramref name="n"/>)</para>
        /// </remarks>
        /// <param name="n">配列の長さ</param>
        public LazySegtree(int n)
        {
            AssertMonoid(op.Identity);
            AssertFIdentity(op.Identity);
            AssertF(op.FIdentity, op.Identity, op.Identity);
            Length = n;
            log = InternalMath.CeilPow2(n);
            size = 1 << log;
            d = new TValue[2 * size];
            lz = new F[size];
            Array.Fill(d, op.Identity);
            Array.Fill(lz, op.FIdentity);
        }

        /// <summary>
        /// 長さ n=<paramref name="v"/>.Length の数列 a　を持つ <see cref="LazySegtree{TValue, TOp}"/> クラスの新しいインスタンスを作ります。初期値は <paramref name="v"/> です。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/>≤10^8</para>
        /// <para>計算量: O(<paramref name="n"/>)</para>
        /// </remarks>
        /// <param name="n">配列の長さ</param>
        public LazySegtree(TValue[] v) : this(v.Length)
        {
            for (int i = 0; i < v.Length; i++) d[size + i] = v[i];
            for (int i = size - 1; i >= 1; i--)
            {
                Update(i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Update(int k) => d[k] = op.Operate(d[2 * k], d[2 * k + 1]);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AllApply(int k, F f)
        {
            AssertF(f, op.Identity, op.Identity);
            AssertMonoid(d[k]);
            AssertFIdentity(d[k]);
            AssertF(f, d[k], d[k]);
            d[k] = op.Mapping(f, d[k]);
            if (k < size) lz[k] = op.Composition(f, lz[k]);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Push(int k)
        {
            AllApply(2 * k, lz[k]);
            AllApply(2 * k + 1, lz[k]);
            lz[k] = op.FIdentity;
        }

        /// <summary>
        /// a[<paramref name="p"/>] を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="p"/>&lt;n</para>
        /// <para>計算量: O(log n)</para>
        /// </remarks>
        /// <returns></returns>
        public TValue this[int p]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                Debug.Assert((uint)p < Length);
                p += size;
                for (int i = log; i >= 1; i--) Push(p >> i);
                d[p] = value;
                for (int i = 1; i <= log; i++) Update(p >> i);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Debug.Assert((uint)p < Length);
                p += size;
                for (int i = log; i >= 1; i--) Push(p >> i);
                return d[p];
            }
        }

        /// <summary>
        /// <see cref="TOp.Operate"/>(a[<paramref name="l"/>], ..., a[<paramref name="r"/> - 1]) を返します。<paramref name="l"/> = <paramref name="r"/> のときは　<see cref="TOp.Identity"/> を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="l"/>≤<paramref name="r"/>≤n</para>
        /// <para>計算量: O(log n)</para>
        /// </remarks>
        /// <returns><see cref="TOp.Operate"/>(a[<paramref name="l"/>], ..., a[<paramref name="r"/> - 1])</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TValue Prod(int l, int r)
        {
            Debug.Assert(0 <= l && l <= r && r <= Length);
            if (l == r) return op.Identity;

            l += size;
            r += size;

            for (int i = log; i >= 1; i--)
            {
                if (((l >> i) << i) != l) Push(l >> i);
                if (((r >> i) << i) != r) Push(r >> i);
            }

            TValue sml = op.Identity, smr = op.Identity;
            while (l < r)
            {
                if ((l & 1) != 0) sml = op.Operate(sml, d[l++]);
                if ((r & 1) != 0) smr = op.Operate(d[--r], smr);
                l >>= 1;
                r >>= 1;
            }

            return op.Operate(sml, smr);
        }

        /// <summary>
        /// <see cref="TOp.Operate"/>(a[0], ..., a[n - 1]) を返します。n = 0 のときは　<see cref="TOp.Identity"/> を返します。
        /// </summary>
        /// <remarks>
        /// <para>計算量: O(1)</para>
        /// </remarks>
        /// <returns><see cref="TOp.Operate"/>(a[0], ..., a[n - 1])</returns>
        public TValue AllProd => d[1];

        /// <summary>
        /// a[<paramref name="p"/>] = <see cref="TOp.Mapping"/>(<paramref name="f"/>, a[<paramref name="p"/>])
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="p"/>≤n</para>
        /// <para>計算量: O(log n)</para>
        /// </remarks>
        public void Apply(int p, F f)
        {
            Debug.Assert((uint)p < Length);
            p += size;
            for (int i = log; i >= 1; i--) Push(p >> i);
            d[p] = op.Mapping(f, d[p]);
            for (int i = 1; i <= log; i++) Update(p >> i);
        }

        /// <summary>
        /// i = <paramref name="l"/>..<paramref name="r"/> について a[i] = <see cref="TOp.Mapping"/>(<paramref name="f"/>, a[<paramref name="p"/>])
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="l"/>≤<paramref name="r"/>≤n</para>
        /// <para>計算量: O(log n)</para>
        /// </remarks>
        public void Apply(int l, int r, F f)
        {
            Debug.Assert(0 <= l && l <= r && r <= Length);
            if (l == r) return;

            l += size;
            r += size;

            for (int i = log; i >= 1; i--)
            {
                if (((l >> i) << i) != l) Push(l >> i);
                if (((r >> i) << i) != r) Push((r - 1) >> i);
            }

            {
                int l2 = l, r2 = r;
                while (l < r)
                {
                    if ((l & 1) != 0) AllApply(l++, f);
                    if ((r & 1) != 0) AllApply(--r, f);
                    l >>= 1;
                    r >>= 1;
                }
                l = l2;
                r = r2;
            }

            for (int i = 1; i <= log; i++)
            {
                if (((l >> i) << i) != l) Update(l >> i);
                if (((r >> i) << i) != r) Update((r - 1) >> i);
            }
        }



        /// <summary>
        /// 以下の条件を両方満たす r を(いずれか一つ)返します。
        /// <list type="bullet">
        /// <item>
        /// <description>r = <paramref name="l"/> もしくは <paramref name="g"/>(op(a[<paramref name="l"/>], a[<paramref name="l"/> + 1], ..., a[r - 1])) = true</description>
        /// </item>
        /// <item>
        /// <description>r = n もしくは <paramref name="g"/>(op(a[<paramref name="l"/>], a[<paramref name="l"/> + 1], ..., a[r])) = false</description>
        /// </item>
        /// </list>
        /// <para><paramref name="g"/> が単調だとすれば、<paramref name="g"/>(op(a[<paramref name="l"/>], a[<paramref name="l"/> + 1], ..., a[r - 1])) = true となる最大の r、と解釈することが可能です。</para>
        /// </summary>
        /// <remarks>
        /// 制約
        /// <list type="bullet">
        /// <item>
        /// <description><paramref name="g"/> を同じ引数で呼んだ時、返り値は等しい(=副作用はない)。</description>
        /// </item>
        /// <item>
        /// <description><paramref name="g"/>(<see cref="TOp.Identity"/>) = true</description>
        /// </item>
        /// <item>
        /// <description>0≤<paramref name="l"/>≤n</description>
        /// </item>
        /// </list>
        /// <para>計算量: O(log n)</para>
        /// </remarks>
        public int MaxRight(int l, Predicate<TValue> g)
        {
            Debug.Assert((uint)l <= Length);
            Debug.Assert(g(op.Identity));
            if (l == Length) return Length;
            l += size;
            for (int i = log; i >= 1; i--) Push(l >> i);
            TValue sm = op.Identity;
            do
            {
                while (l % 2 == 0) l >>= 1;
                if (!g(op.Operate(sm, d[l])))
                {
                    while (l < size)
                    {
                        Push(l);
                        l = (2 * l);
                        if (g(op.Operate(sm, d[l])))
                        {
                            sm = op.Operate(sm, d[l]);
                            l++;
                        }
                    }
                    return l - size;
                }
                sm = op.Operate(sm, d[l]);
                l++;
            } while ((l & -l) != l);

            return Length;
        }

        /// <summary>
        /// 以下の条件を両方満たす r を(いずれか一つ)返します。
        /// <list type="bullet">
        /// <item>
        /// <description>l = <paramref name="r"/> もしくは <paramref name="g"/>(op(a[l], a[l + 1], ..., a[<paramref name="r"/> - 1])) = true</description>
        /// </item>
        /// <item>
        /// <description>l = 0 もしくは <paramref name="g"/>(op(a[l - 1], a[l], ..., a[<paramref name="r"/> - 1])) = false</description>
        /// </item>
        /// </list>
        /// <para><paramref name="g"/> が単調だとすれば、<paramref name="g"/>(op(a[l], a[l + 1], ..., a[<paramref name="r"/> - 1])) = true となる最小の l、と解釈することが可能です。</para>
        /// </summary>
        /// <remarks>
        /// 制約
        /// <list type="bullet">
        /// <item>
        /// <description><paramref name="g"/> を同じ引数で呼んだ時、返り値は等しい(=副作用はない)。</description>
        /// </item>
        /// <item>
        /// <description><paramref name="g"/>(<see cref="TOp.Identity"/>) = true</description>
        /// </item>
        /// <item>
        /// <description>0≤<paramref name="r"/>≤n</description>
        /// </item>
        /// </list>
        /// <para>計算量: O(log n)</para>
        /// </remarks>
        public int MinLeft(int r, Predicate<TValue> g)
        {
            Debug.Assert((uint)r <= Length);
            Debug.Assert(g(op.Identity));
            if (r == 0) return 0;
            r += size;
            for (int i = log; i >= 1; i--) Push((r - 1) >> i);
            TValue sm = op.Identity;
            do
            {
                r--;
                while (r > 1 && (r % 2) != 0) r >>= 1;
                if (!g(op.Operate(d[r], sm)))
                {
                    while (r < size)
                    {
                        Push(r);
                        r = (2 * r + 1);
                        if (g(op.Operate(d[r], sm)))
                        {
                            sm = op.Operate(d[r], sm);
                            r--;
                        }
                    }
                    return r + 1 - size;
                }
                sm = op.Operate(d[r], sm);
            } while ((r & -r) != r);
            return 0;
        }


        [DebuggerDisplay("Value = {" + nameof(value) + "}, Lazy = {" + nameof(lazy) + "}", Name = "{" + nameof(key) + ",nq}")]
        private struct DebugItem
        {
            public DebugItem(int l, int r, TValue value, F lazy)
            {
                if (r - l == 1)
                    key = $"[{l}]";
                else
                    key = $"[{l}-{r})";
                this.value = value;
                this.lazy = lazy;
            }
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly string key;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly TValue value;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly F lazy;
        }
        private class DebugView
        {
            private readonly LazySegtree<TValue, F, TOp> segtree;
            public DebugView(LazySegtree<TValue, F, TOp> segtree)
            {
                this.segtree = segtree;
            }
            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public DebugItem[] Items
            {
                get
                {
                    var items = new List<DebugItem>(segtree.Length);
                    for (int len = segtree.size; len > 0; len >>= 1)
                    {
                        int unit = segtree.size / len;
                        for (int i = 0; i < len; i++)
                        {
                            int l = i * unit;
                            int r = System.Math.Min(l + unit, segtree.Length);
                            if (l < segtree.Length)
                            {
                                int dataIndex = i + len;
                                if ((uint)dataIndex < segtree.lz.Length)
                                    items.Add(new DebugItem(l, r, segtree.d[dataIndex], segtree.lz[dataIndex]));
                                else
                                    items.Add(new DebugItem(l, r, segtree.d[dataIndex], op.FIdentity));
                            }
                        }
                    }
                    return items.ToArray();
                }
            }
        }


        /// <summary>
        /// Debug ビルドにおいて、Monoid が正しいかチェックする。
        /// </summary>
        /// <param name="value"></param>
        [Conditional("DEBUG")]
        public static void AssertMonoid(TValue value)
        {
            Debug.Assert(op.Operate(value, op.Identity).Equals(value),
                $"{nameof(op.Operate)}({value}, {op.Identity}) != {value}");
            Debug.Assert(op.Operate(op.Identity, value).Equals(value),
                $"{nameof(op.Operate)}({op.Identity}, {value}) != {value}");
        }

        /// <summary>
        /// Debug ビルドにおいて、FIdentity が恒等写像かチェックする。
        /// </summary>
        /// <param name="value"></param>
        [Conditional("DEBUG")]
        public static void AssertFIdentity(TValue value)
        {
            Debug.Assert(op.Mapping(op.FIdentity, value).Equals(value),
                $"{nameof(op.Mapping)}({op.Identity}, {value}) != {value}");
        }

        /// <summary>
        /// Debug ビルドにおいて、F が分配法則を満たすかチェックする。
        /// </summary>
        /// <param name="value"></param>
        [Conditional("DEBUG")]
        public static void AssertF(F f, TValue v1, TValue v2)
        {
            Debug.Assert(op.Mapping(op.FIdentity, op.Operate(v1, v2)).Equals(op.Operate(op.Mapping(op.FIdentity, v1), op.Mapping(op.FIdentity, v2))),
                $"{nameof(op.Mapping)}({nameof(op.Operate)}({v1}, {v2})) != {nameof(op.Operate)}({nameof(op.Mapping)}({op.Identity}, {v1}), {nameof(op.Mapping)}({op.Identity}, {v2}))");
        }
    }
}


namespace AtCoder.Internal
{
    public static partial class InternalMath
    {
        /// <summary>
        /// <paramref name="n"/> ≤ 2**x を満たす最小のx
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/></para>
        /// </remarks>
        public static int CeilPow2(int n)
        {
            var un = (uint)n;
            if (un <= 1) return 0;
            return BitOperations.Log2(un - 1) + 1;
        }
    }
}
