using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200926.Algorithms;
using Training20200926.Collections;
using Training20200926.Numerics;
using Training20200926.Questions;
using AtCoderTemplateForNetCore.Graphs;
using AtCoderTemplateForNetCore.Graphs.Algorithms;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using AtCoder;

namespace Training20200926.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc160/tasks/abc160_f
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            Modular.InitializeCombinationTable();
            var n = io.ReadInt();
            var tree = new BasicGraph(n);

            for (int i = 0; i < n - 1; i++)
            {
                var a = io.ReadInt() - 1;
                var b = io.ReadInt() - 1;
                tree.AddEdge(a, b);
                tree.AddEdge(b, a);
            }

            var rerooting = new Rerooting<BasicEdge, CountAndWay>(tree);

            var results = rerooting.Solve();

            foreach (var r in results)
            {
                io.WriteLine(r.Way);
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct CountAndWay : ITreeDpState<CountAndWay>
        {
            public int Count { get; }
            public StaticModInt<Mod1000000007> Way { get; }

            static Combinations<Mod1000000007> combinator = new Combinations<Mod1000000007>(200000);

            public CountAndWay Identity => new CountAndWay(0, 1);

            public CountAndWay(int count, StaticModInt<Mod1000000007> way)
            {
                Count = count;
                Way = way;
            }

            public void Deconstruct(out int count, out StaticModInt<Mod1000000007> way) => (count, way) = (Count, Way);
            public override string ToString() => $"{nameof(Count)}: {Count}, {nameof(Way)}: {Way}";

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public CountAndWay AddRoot() => new CountAndWay(Count + 1, Way);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public CountAndWay Merge(CountAndWay other)
            {
                var sum = Count + other.Count;
                var way = combinator.Combination(sum, Count) * Way * other.Way;
                return new CountAndWay(sum, way);
            }
        }
    }

    public class Combinations<T> where T : struct, IStaticMod
    {
        StaticModInt<T>[] _factorials;
        StaticModInt<T>[] _invFactorials;

        public Combinations(int max)
        {
            if (!default(T).IsPrime)
            {
                throw new InvalidOperationException("modは素数である必要があります。");
            }

            var length = max + 1;
            _factorials = new StaticModInt<T>[length];
            _invFactorials = new StaticModInt<T>[length];

            _factorials[0] = 1;
            _factorials[1] = 1;

            for (int i = 2; i < _factorials.Length; i++)
            {
                _factorials[i] = _factorials[i - 1] * i;
            }

            _invFactorials[^1] = _factorials[^1].Inv();

            for (int i = _factorials.Length - 1; i >= 1; i--)
            {
                _invFactorials[i - 1] = _invFactorials[i] * i;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticModInt<T> Combination(int n, int k)
        {
            if (n < 0 || unchecked(n < (uint)k))
            {
                ThrowArgumentException("0 <= n, 0 <= k <= n でなければなりません。");
            }

            return _factorials[n] * _invFactorials[k] * _invFactorials[n - k];
        }

        private void ThrowArgumentException(string s) => throw new ArgumentException(s);
    }
}

namespace AtCoder
{
    /// <summary>
    /// コンパイル時に決定する mod を表します。
    /// </summary>
    /// <example>
    /// <code>
    /// public readonly struct Mod1000000009 : IStaticMod
    /// {
    ///     public uint Mod => 1000000009;
    ///     public bool IsPrime => true;
    /// }
    /// </code>
    /// </example>
    public interface IStaticMod
    {
        /// <summary>
        /// mod を取得します。
        /// </summary>
        uint Mod { get; }

        /// <summary>
        /// mod が素数であるか識別します。
        /// </summary>
        bool IsPrime { get; }
    }

    public readonly struct Mod1000000007 : IStaticMod
    {
        public uint Mod
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 1000000007;
        }

        public bool IsPrime => true;
    }

    public readonly struct Mod998244353 : IStaticMod
    {
        public uint Mod => 998244353;
        public bool IsPrime => true;
    }

    /// <summary>
    /// 実行時に決定する mod の ID を表します。
    /// </summary>
    /// <example>
    /// <code>
    /// public readonly struct ModID123 : IDynamicModID { }
    /// </code>
    /// </example>
    public interface IDynamicModID { }

    public readonly struct ModID0 : IDynamicModID { }
    public readonly struct ModID1 : IDynamicModID { }
    public readonly struct ModID2 : IDynamicModID { }

    /// <summary>
    /// 四則演算時に自動で mod を取る整数型。mod の値はコンパイル時に決定している必要があります。
    /// </summary>
    /// <typeparam name="T">定数 mod を表す構造体</typeparam>
    /// <example>
    /// <code>
    /// using ModInt = AtCoder.StaticModInt&lt;AtCoder.Mod1000000007&gt;;
    ///
    /// void SomeMethod()
    /// {
    ///     var m = new ModInt(1);
    ///     m -= 2;
    ///     Console.WriteLine(m);   // 1000000006
    /// }
    /// </code>
    /// </example>
    public readonly struct StaticModInt<T> : IEquatable<StaticModInt<T>> where T : struct, IStaticMod
    {
        private readonly uint _v;

        /// <summary>
        /// 格納されている値を返します。
        /// </summary>
        public int Value => (int)_v;

        /// <summary>
        /// mod を返します。
        /// </summary>
        public static int Mod => (int)default(T).Mod;

        /// <summary>
        /// <paramref name="v"/> に対して mod を取らずに StaticModInt&lt;<typeparamref name="T"/>&gt; 型のインスタンスを生成します。
        /// </summary>
        /// <remarks>
        /// <para>定数倍高速化のための関数です。 <paramref name="v"/> に 0 未満または mod 以上の値を入れた場合の挙動は未定義です。</para>
        /// <para>制約: 0≤|<paramref name="v"/>|&lt;mod</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StaticModInt<T> Raw(int v)
        {
            var u = unchecked((uint)v);
            Debug.Assert(u < Mod);
            return new StaticModInt<T>(u);
        }

        /// <summary>
        /// StaticModInt&lt;<typeparamref name="T"/>&gt; 型のインスタンスを生成します。
        /// </summary>
        /// <remarks>
        /// <paramref name="v"/>が 0 未満、もしくは mod 以上の場合、自動で mod を取ります。
        /// </remarks>
        public StaticModInt(long v) : this(Round(v)) { }

        private StaticModInt(uint v) => _v = v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint Round(long v)
        {
            var x = v % default(T).Mod;
            if (x < 0)
            {
                x += default(T).Mod;
            }
            return (uint)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StaticModInt<T> operator ++(StaticModInt<T> value)
        {
            var v = value._v + 1;
            if (v == default(T).Mod)
            {
                v = 0;
            }
            return new StaticModInt<T>(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StaticModInt<T> operator --(StaticModInt<T> value)
        {
            var v = value._v;
            if (v == 0)
            {
                v = default(T).Mod;
            }
            return new StaticModInt<T>(v - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StaticModInt<T> operator +(StaticModInt<T> lhs, StaticModInt<T> rhs)
        {
            var v = lhs._v + rhs._v;
            if (v >= default(T).Mod)
            {
                v -= default(T).Mod;
            }
            return new StaticModInt<T>(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StaticModInt<T> operator -(StaticModInt<T> lhs, StaticModInt<T> rhs)
        {
            unchecked
            {
                var v = lhs._v - rhs._v;
                if (v >= default(T).Mod)
                {
                    v += default(T).Mod;
                }
                return new StaticModInt<T>(v);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static StaticModInt<T> operator *(StaticModInt<T> lhs, StaticModInt<T> rhs)
        {
            return new StaticModInt<T>((uint)((ulong)lhs._v * rhs._v % default(T).Mod));
        }

        /// <summary>
        /// 除算を行います。
        /// </summary>
        /// <remarks>
        /// <para>- 制約: <paramref name="rhs"/> に乗法の逆元が存在する。（gcd(<paramref name="rhs"/>, mod) = 1）</para>
        /// <para>- 計算量: O(log(mod))</para>
        /// </remarks>
        public static StaticModInt<T> operator /(StaticModInt<T> lhs, StaticModInt<T> rhs) => lhs * rhs.Inv();

        public static StaticModInt<T> operator +(StaticModInt<T> value) => value;
        public static StaticModInt<T> operator -(StaticModInt<T> value) => new StaticModInt<T>() - value;
        public static bool operator ==(StaticModInt<T> lhs, StaticModInt<T> rhs) => lhs._v == rhs._v;
        public static bool operator !=(StaticModInt<T> lhs, StaticModInt<T> rhs) => lhs._v != rhs._v;
        public static implicit operator StaticModInt<T>(int value) => new StaticModInt<T>(value);
        public static implicit operator StaticModInt<T>(long value) => new StaticModInt<T>(value);

        /// <summary>
        /// 自身を x として、x^<paramref name="n"/> を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤|<paramref name="n"/>|</para>
        /// <para>計算量: O(log(<paramref name="n"/>))</para>
        /// </remarks>
        public StaticModInt<T> Pow(long n)
        {
            Debug.Assert(0 <= n);
            var x = this;
            var r = Raw(1);

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

        /// <summary>
        /// 自身を x として、 xy≡1 なる y を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: gcd(x, mod) = 1</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public StaticModInt<T> Inv()
        {
            if (default(T).IsPrime)
            {
                Debug.Assert(_v > 0);
                return Pow(default(T).Mod - 2);
            }
            else
            {
                var (g, x) = InvGCD(_v, default(T).Mod);
                Debug.Assert(g == 1);
                return new StaticModInt<T>(x);
            }
        }

        public override string ToString() => _v.ToString();
        public override bool Equals(object obj) => obj is StaticModInt<T> && Equals((StaticModInt<T>)obj);
        public bool Equals(StaticModInt<T> other) => Value == other.Value;
        public override int GetHashCode() => _v.GetHashCode();

        /// <summary>
        /// g=gcd(a,b),xa=g(mod b) となるような 0≤x&lt;b/g の(g, x)
        /// </summary>
        /// <remarks>
        /// <para>制約: 1≤<paramref name="b"/></para>
        /// </remarks>
        private static (long, long) InvGCD(long a, long b)
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


        private static long SafeMod(long x, long m)
        {
            x %= m;
            if (x < 0) x += m;
            return x;
        }
    }

    /// <summary>
    /// 四則演算時に自動で mod を取る整数型。実行時に mod が決まる場合でも使用可能です。
    /// </summary>
    /// <remarks>
    /// 使用前に DynamicModInt&lt;<typeparamref name="T"/>&gt;.Mod に mod の値を設定する必要があります。
    /// </remarks>
    /// <typeparam name="T">mod の ID を表す構造体</typeparam>
    /// <example>
    /// <code>
    /// using AtCoder.ModInt = AtCoder.DynamicModInt&lt;AtCoder.ModID0&gt;;
    ///
    /// void SomeMethod()
    /// {
    ///     ModInt.Mod = 1000000009;
    ///     var m = new ModInt(1);
    ///     m -= 2;
    ///     Console.WriteLine(m);   // 1000000008
    /// }
    /// </code>
    /// </example>
    public readonly struct DynamicModInt<T> : IEquatable<DynamicModInt<T>> where T : struct, IDynamicModID
    {
        private readonly uint _v;
        private static Barrett bt;

        /// <summary>
        /// 格納されている値を返します。
        /// </summary>
        public int Value => (int)_v;

        /// <summary>
        /// mod を返します。
        /// </summary>
        public static int Mod
        {
            get => (int)bt.Mod;
            set
            {
                Debug.Assert(1 <= value);
                bt = new Barrett((uint)value);
            }
        }

        /// <summary>
        /// <paramref name="v"/> に対して mod を取らずに DynamicModInt&lt;<typeparamref name="T"/>&gt; 型のインスタンスを生成します。
        /// </summary>
        /// <remarks>
        /// <para>定数倍高速化のための関数です。 <paramref name="v"/> に 0 未満または mod 以上の値を入れた場合の挙動は未定義です。</para>
        /// <para>制約: 0≤|<paramref name="v"/>|&lt;mod</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DynamicModInt<T> Raw(int v)
        {
            var u = unchecked((uint)v);
            Debug.Assert(bt != null, $"使用前に {nameof(DynamicModInt<T>)}<{nameof(T)}>.{nameof(Mod)} プロパティに mod の値を設定してください。");
            Debug.Assert(u < Mod);
            return new DynamicModInt<T>(u);
        }

        /// <summary>
        /// DynamicModInt&lt;<typeparamref name="T"/>&gt; 型のインスタンスを生成します。
        /// </summary>
        /// <remarks>
        /// <para>- 使用前に DynamicModInt&lt;<typeparamref name="T"/>&gt;.Mod に mod の値を設定する必要があります。</para>
        /// <para>- <paramref name="v"/> が 0 未満、もしくは mod 以上の場合、自動で mod を取ります。</para>
        /// </remarks>
        public DynamicModInt(long v) : this(Round(v)) { }

        private DynamicModInt(uint v) => _v = v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint Round(long v)
        {
            Debug.Assert(bt != null, $"使用前に {nameof(DynamicModInt<T>)}<{nameof(T)}>.{nameof(Mod)} プロパティに mod の値を設定してください。");
            var x = v % bt.Mod;
            if (x < 0)
            {
                x += bt.Mod;
            }
            return (uint)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DynamicModInt<T> operator ++(DynamicModInt<T> value)
        {
            var v = value._v + 1;
            if (v == bt.Mod)
            {
                v = 0;
            }
            return new DynamicModInt<T>(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DynamicModInt<T> operator --(DynamicModInt<T> value)
        {
            var v = value._v;
            if (v == 0)
            {
                v = bt.Mod;
            }
            return new DynamicModInt<T>(v - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DynamicModInt<T> operator +(DynamicModInt<T> lhs, DynamicModInt<T> rhs)
        {
            var v = lhs._v + rhs._v;
            if (v >= bt.Mod)
            {
                v -= bt.Mod;
            }
            return new DynamicModInt<T>(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DynamicModInt<T> operator -(DynamicModInt<T> lhs, DynamicModInt<T> rhs)
        {
            unchecked
            {
                var v = lhs._v - rhs._v;
                if (v >= bt.Mod)
                {
                    v += bt.Mod;
                }
                return new DynamicModInt<T>(v);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DynamicModInt<T> operator *(DynamicModInt<T> lhs, DynamicModInt<T> rhs)
        {
            uint z = bt.Mul(lhs._v, rhs._v);
            return new DynamicModInt<T>(z);
        }

        /// <summary>
        /// 除算を行います。
        /// </summary>
        /// <remarks>
        /// <para>- 制約: <paramref name="rhs"/> に乗法の逆元が存在する。（gcd(<paramref name="rhs"/>, mod) = 1）</para>
        /// <para>- 計算量: O(log(mod))</para>
        /// </remarks>
        public static DynamicModInt<T> operator /(DynamicModInt<T> lhs, DynamicModInt<T> rhs) => lhs * rhs.Inv();

        public static DynamicModInt<T> operator +(DynamicModInt<T> value) => value;
        public static DynamicModInt<T> operator -(DynamicModInt<T> value) => new DynamicModInt<T>() - value;
        public static bool operator ==(DynamicModInt<T> lhs, DynamicModInt<T> rhs) => lhs._v == rhs._v;
        public static bool operator !=(DynamicModInt<T> lhs, DynamicModInt<T> rhs) => lhs._v != rhs._v;
        public static implicit operator DynamicModInt<T>(int value) => new DynamicModInt<T>(value);
        public static implicit operator DynamicModInt<T>(long value) => new DynamicModInt<T>(value);

        /// <summary>
        /// 自身を x として、x^<paramref name="n"/> を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤|<paramref name="n"/>|</para>
        /// <para>計算量: O(log(<paramref name="n"/>))</para>
        /// </remarks>
        public DynamicModInt<T> Pow(long n)
        {
            Debug.Assert(0 <= n);
            var x = this;
            var r = Raw(1);

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

        /// <summary>
        /// 自身を x として、 xy≡1 なる y を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: gcd(x, mod) = 1</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DynamicModInt<T> Inv()
        {
            var (g, x) = InvGCD(_v, bt.Mod);
            Debug.Assert(g == 1);
            return new DynamicModInt<T>(x);
        }

        public override string ToString() => _v.ToString();
        public override bool Equals(object obj) => obj is DynamicModInt<T> && Equals((DynamicModInt<T>)obj);
        public bool Equals(DynamicModInt<T> other) => Value == other.Value;
        public override int GetHashCode() => _v.GetHashCode();

        /// <summary>
        /// g=gcd(a,b),xa=g(mod b) となるような 0≤x&lt;b/g の(g, x)
        /// </summary>
        /// <remarks>
        /// <para>制約: 1≤<paramref name="b"/></para>
        /// </remarks>
        static (long, long) InvGCD(long a, long b)
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

        static long SafeMod(long x, long m)
        {
            x %= m;
            if (x < 0) x += m;
            return x;
        }

        /// <summary>
        /// Fast moduler by barrett reduction
        /// <seealso href="https://en.wikipedia.org/wiki/Barrett_reduction"/>
        /// </summary>
        public class Barrett
        {
            public uint Mod { get; private set; }
            private ulong IM;
            public Barrett(uint m)
            {
                Mod = m;
                IM = unchecked((ulong)-1) / m + 1;
            }

            /// <summary>
            /// <paramref name="a"/> * <paramref name="b"/> mod m
            /// </summary>
            public uint Mul(uint a, uint b)
            {
                ulong z = a;
                z *= b;
                if (!Bmi2.X64.IsSupported) return (uint)(z % Mod);
                var x = Bmi2.X64.MultiplyNoFlags(z, IM);
                var v = unchecked((uint)(z - x * Mod));
                if (Mod <= v) v += Mod;
                return v;
            }
        }
    }
}
