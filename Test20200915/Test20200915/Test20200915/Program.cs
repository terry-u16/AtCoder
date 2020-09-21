using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Test20200915.Extensions;
using Test20200915.Questions;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Numerics;
using AtCoder.Internal;

namespace AtCoder.Internal
{
    public static class Butterfly<T> where T : struct, IStaticMod
    {
        /// <summary>
        /// sumE[i] = ies[0] * ... * ies[i - 1] * es[i]
        /// </summary>
        private static StaticModInt<T>[] sumE = CalcurateSumE();

        /// <summary>
        /// sumIE[i] = es[0] * ... * es[i - 1] * ies[i]
        /// </summary>
        private static StaticModInt<T>[] sumIE = CalcurateSumIE();

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static void Calculate(Span<StaticModInt<T>> a)
        {
            var n = a.Length;
            var h = InternalMath.CeilPow2(n);

            for (int ph = 1; ph <= h; ph++)
            {
                // ブロックサイズの半分
                int w = 1 << (ph - 1);

                // ブロック数
                int p = 1 << (h - ph);
                System.Diagnostics.Debugger.Break();
                var now = StaticModInt<T>.Raw(1);

                // 各ブロックの s 段目
                for (int s = 0; s < w; s++)
                {
                    int offset = s << (h - ph + 1);

                    var ls = a.Slice(offset, p);
                    var rs = a.Slice(offset + p, p);

                    for (int i = 0; i < p; i++)
                    {
                        var l = ls[i];
                        var r = rs[i] * now;
                        ls[i] = l + r;
                        rs[i] = l - r;
                    }
                    now *= sumE[InternalBit.BSF(~(uint)s)];
                }
            }
        }

        public static void CalculateInv(Span<StaticModInt<T>> a)
        {
            var n = a.Length;
            var h = InternalMath.CeilPow2(n);

            for (int ph = h; ph >= 1; ph--)
            {
                // ブロックサイズの半分
                int w = 1 << (ph - 1);

                // ブロック数
                int p = 1 << (h - ph);

                var iNow = StaticModInt<T>.Raw(1);

                // 各ブロックの s 段目
                for (int s = 0; s < w; s++)
                {
                    int offset = s << (h - ph + 1);

                    for (int i = 0; i < p; i++)
                    {
                        var l = a[i + offset];
                        var r = a[i + offset + p];
                        a[i + offset] = l + r;
                        a[i + offset + p] = StaticModInt<T>.Raw(
                            unchecked((int)((ulong)(default(T).Mod + l.Value - r.Value) * (ulong)iNow.Value % default(T).Mod)));
                    }
                    iNow *= sumIE[InternalBit.BSF(~(uint)s)];
                }
            }
        }

        private static StaticModInt<T>[] CalcurateSumE()
        {
            int g = InternalMath.PrimitiveRoot((int)default(T).Mod);
            int cnt2 = InternalBit.BSF(default(T).Mod - 1);
            var e = new StaticModInt<T>(g).Pow((default(T).Mod - 1) >> cnt2);
            var ie = e.Inv();

            var sumE = new StaticModInt<T>[cnt2 - 2];

            // es[i]^(2^(2+i)) == 1
            Span<StaticModInt<T>> es = stackalloc StaticModInt<T>[cnt2 - 1];
            Span<StaticModInt<T>> ies = stackalloc StaticModInt<T>[cnt2 - 1];

            for (int i = es.Length - 1; i >= 0; i--)
            {
                // e^(2^(2+i)) == 1
                es[i] = e;
                ies[i] = ie;
                e *= e;
                ie *= ie;
            }

            var now = StaticModInt<T>.Raw(1);
            for (int i = 0; i < sumE.Length; i++)
            {
                sumE[i] = es[i] * now;
                now *= ies[i];
            }

            return sumE;
        }

        private static StaticModInt<T>[] CalcurateSumIE()
        {
            int g = InternalMath.PrimitiveRoot((int)default(T).Mod);
            int cnt2 = InternalBit.BSF(default(T).Mod - 1);
            var e = new StaticModInt<T>(g).Pow((default(T).Mod - 1) >> cnt2);
            var ie = e.Inv();

            var sumIE = new StaticModInt<T>[cnt2 - 2];

            // es[i]^(2^(2+i)) == 1
            Span<StaticModInt<T>> es = stackalloc StaticModInt<T>[cnt2 - 1];
            Span<StaticModInt<T>> ies = stackalloc StaticModInt<T>[cnt2 - 1];

            for (int i = es.Length - 1; i >= 0; i--)
            {
                // e^(2^(2+i)) == 1
                es[i] = e;
                ies[i] = ie;
                e *= e;
                ie *= ie;
            }

            var now = StaticModInt<T>.Raw(1);
            for (int i = 0; i < sumIE.Length; i++)
            {
                sumIE[i] = ies[i] * now;
                now *= es[i];
            }

            return sumIE;
        }
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
        public uint Mod => 1000000007;
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
    public readonly struct StaticModInt<T> where T : struct, IStaticMod
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

        private static uint Round(long v)
        {
            var x = v % default(T).Mod;
            if (x < 0)
            {
                x += default(T).Mod;
            }
            return (uint)x;
        }

        public static StaticModInt<T> operator ++(StaticModInt<T> value)
        {
            var v = value._v + 1;
            if (v == default(T).Mod)
            {
                v = 0;
            }
            return new StaticModInt<T>(v);
        }

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
            var r = new StaticModInt<T>(1u);

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
        public StaticModInt<T> Inv()
        {
            if (default(T).IsPrime)
            {
                Debug.Assert(_v > 0);
                return Pow(default(T).Mod - 2);
            }
            else
            {
                var (g, x) = Internal.InternalMath.InvGCD(_v, default(T).Mod);
                Debug.Assert(g == 1);
                return new StaticModInt<T>(x);
            }
        }

        public override string ToString() => _v.ToString();
        public override bool Equals(object obj) => obj is StaticModInt<T> && this == (StaticModInt<T>)obj;
        public override int GetHashCode() => _v.GetHashCode();
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
    public readonly struct DynamicModInt<T> where T : struct, IDynamicModID
    {
        private readonly uint _v;
        private static Internal.Barrett bt;

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
                bt = new Internal.Barrett((uint)value);
            }
        }

        /// <summary>
        /// <paramref name="v"/> に対して mod を取らずに DynamicModInt&lt;<typeparamref name="T"/>&gt; 型のインスタンスを生成します。
        /// </summary>
        /// <remarks>
        /// <para>定数倍高速化のための関数です。 <paramref name="v"/> に 0 未満または mod 以上の値を入れた場合の挙動は未定義です。</para>
        /// <para>制約: 0≤|<paramref name="v"/>|&lt;mod</para>
        /// </remarks>
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

        public static DynamicModInt<T> operator ++(DynamicModInt<T> value)
        {
            var v = value._v + 1;
            if (v == bt.Mod)
            {
                v = 0;
            }
            return new DynamicModInt<T>(v);
        }

        public static DynamicModInt<T> operator --(DynamicModInt<T> value)
        {
            var v = value._v;
            if (v == 0)
            {
                v = bt.Mod;
            }
            return new DynamicModInt<T>(v - 1);
        }

        public static DynamicModInt<T> operator +(DynamicModInt<T> lhs, DynamicModInt<T> rhs)
        {
            var v = lhs._v + rhs._v;
            if (v >= bt.Mod)
            {
                v -= bt.Mod;
            }
            return new DynamicModInt<T>(v);
        }

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
            var r = new DynamicModInt<T>(1u);

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
        public DynamicModInt<T> Inv()
        {
            var (g, x) = Internal.InternalMath.InvGCD(_v, bt.Mod);
            Debug.Assert(g == 1);
            return new DynamicModInt<T>(x);
        }

        public override string ToString() => _v.ToString();
        public override bool Equals(object obj) => obj is DynamicModInt<T> && this == (DynamicModInt<T>)obj;
        public override int GetHashCode() => _v.GetHashCode();
    }
}
namespace AtCoder
{
    public static partial class Math
    {
        /// <summary>
        /// 畳み込みを mod <paramref name="m"/> = 998244353 で計算します。
        /// </summary>
        /// <remarks>
        /// <para><paramref name="a"/>, <paramref name="b"/> の少なくとも一方が空の場合は空配列を返します。</para>
        /// <para>制約:</para>
        /// <para>- 2≤<paramref name="m"/>≤2×10^9</para>
        /// <para>- <paramref name="m"/> は素数</para>
        /// <para>- 2^c | (<paramref name="m"/> - 1) かつ |<paramref name="a"/>| + |<paramref name="b"/>| - 1 ≤ 2^c なる c が存在する</para>
        /// <para>計算量: O((|<paramref name="a"/>|+|<paramref name="b"/>|)log(|<paramref name="a"/>|+|<paramref name="b"/>|) + log<paramref name="m"/>)</para>
        /// </remarks>
        public static int[] Convolution(int[] a, int[] b) => Convolution<Mod998244353>(a, b);

        /// <summary>
        /// 畳み込みを mod <paramref name="m"/> = 998244353 で計算します。
        /// </summary>
        /// <remarks>
        /// <para><paramref name="a"/>, <paramref name="b"/> の少なくとも一方が空の場合は空配列を返します。</para>
        /// <para>制約:</para>
        /// <para>- 2≤<paramref name="m"/>≤2×10^9</para>
        /// <para>- <paramref name="m"/> は素数</para>
        /// <para>- 2^c | (<paramref name="m"/> - 1) かつ |<paramref name="a"/>| + |<paramref name="b"/>| - 1 ≤ 2^c なる c が存在する</para>
        /// <para>計算量: O((|<paramref name="a"/>|+|<paramref name="b"/>|)log(|<paramref name="a"/>|+|<paramref name="b"/>|) + log<paramref name="m"/>)</para>
        /// </remarks>
        public static uint[] Convolution(uint[] a, uint[] b) => Convolution<Mod998244353>(a, b);

        /// <summary>
        /// 畳み込みを mod <paramref name="m"/> = 998244353 で計算します。
        /// </summary>
        /// <remarks>
        /// <para><paramref name="a"/>, <paramref name="b"/> の少なくとも一方が空の場合は空配列を返します。</para>
        /// <para>制約:</para>
        /// <para>- 2≤<paramref name="m"/>≤2×10^9</para>
        /// <para>- <paramref name="m"/> は素数</para>
        /// <para>- 2^c | (<paramref name="m"/> - 1) かつ |<paramref name="a"/>| + |<paramref name="b"/>| - 1 ≤ 2^c なる c が存在する</para>
        /// <para>計算量: O((|<paramref name="a"/>|+|<paramref name="b"/>|)log(|<paramref name="a"/>|+|<paramref name="b"/>|) + log<paramref name="m"/>)</para>
        /// </remarks>
        public static long[] Convolution(long[] a, long[] b) => Convolution<Mod998244353>(a, b);

        /// <summary>
        /// 畳み込みを mod <paramref name="m"/> = 998244353 で計算します。
        /// </summary>
        /// <remarks>
        /// <para><paramref name="a"/>, <paramref name="b"/> の少なくとも一方が空の場合は空配列を返します。</para>
        /// <para>制約:</para>
        /// <para>- 2≤<paramref name="m"/>≤2×10^9</para>
        /// <para>- <paramref name="m"/> は素数</para>
        /// <para>- 2^c | (<paramref name="m"/> - 1) かつ |<paramref name="a"/>| + |<paramref name="b"/>| - 1 ≤ 2^c なる c が存在する</para>
        /// <para>計算量: O((|<paramref name="a"/>|+|<paramref name="b"/>|)log(|<paramref name="a"/>|+|<paramref name="b"/>|) + log<paramref name="m"/>)</para>
        /// </remarks>
        public static ulong[] Convolution(ulong[] a, ulong[] b) => Convolution<Mod998244353>(a, b);

        /// <summary>
        /// 畳み込みを mod <typeparamref name="TMod"/> で計算します。
        /// </summary>
        /// <remarks>
        /// <para><paramref name="a"/>, <paramref name="b"/> の少なくとも一方が空の場合は空配列を返します。</para>
        /// <para>制約:</para>
        /// <para>- 2≤<typeparamref name="TMod"/>≤2×10^9</para>
        /// <para>- <typeparamref name="TMod"/> は素数</para>
        /// <para>- 2^c | (<typeparamref name="TMod"/> - 1) かつ |<paramref name="a"/>| + |<paramref name="b"/>| - 1 ≤ 2^c なる c が存在する</para>
        /// <para>計算量: O((|<paramref name="a"/>|+|<paramref name="b"/>|)log(|<paramref name="a"/>|+|<paramref name="b"/>|) + log<typeparamref name="TMod"/>)</para>
        /// </remarks>
        public static int[] Convolution<TMod>(int[] a, int[] b) where TMod : struct, IStaticMod
        {
            var n = a.Length;
            var m = b.Length;
            if (n == 0 || m == 0)
            {
                return Array.Empty<int>();
            }

            if (System.Math.Min(n, m) <= 60)
            {
                var c = ConvolutionNaive<TMod>(a.Select(ai => new StaticModInt<TMod>(ai)).ToArray(),
                                               b.Select(bi => new StaticModInt<TMod>(bi)).ToArray());
                return c.Select(ci => ci.Value).ToArray();
            }
            else
            {
                int z = 1 << Internal.InternalMath.CeilPow2(n + m - 1);

                var aTemp = new StaticModInt<TMod>[z];
                for (int i = 0; i < a.Length; i++)
                {
                    aTemp[i] = new StaticModInt<TMod>(a[i]);
                }

                var bTemp = new StaticModInt<TMod>[z];
                for (int i = 0; i < b.Length; i++)
                {
                    bTemp[i] = new StaticModInt<TMod>(b[i]);
                }

                var c = Convolution<TMod>(aTemp, bTemp, n, m, z)[0..(n + m - 1)];
                var result = new int[c.Length];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = c[i].Value;
                }
                return result;
            }
        }


        /// <summary>
        /// 畳み込みを mod <typeparamref name="TMod"/> で計算します。
        /// </summary>
        /// <remarks>
        /// <para><paramref name="a"/>, <paramref name="b"/> の少なくとも一方が空の場合は空配列を返します。</para>
        /// <para>制約:</para>
        /// <para>- 2≤<typeparamref name="TMod"/>≤2×10^9</para>
        /// <para>- <typeparamref name="TMod"/> は素数</para>
        /// <para>- 2^c | (<typeparamref name="TMod"/> - 1) かつ |<paramref name="a"/>| + |<paramref name="b"/>| - 1 ≤ 2^c なる c が存在する</para>
        /// <para>計算量: O((|<paramref name="a"/>|+|<paramref name="b"/>|)log(|<paramref name="a"/>|+|<paramref name="b"/>|) + log<typeparamref name="TMod"/>)</para>
        /// </remarks>
        public static uint[] Convolution<TMod>(uint[] a, uint[] b) where TMod : struct, IStaticMod
        {
            var n = a.Length;
            var m = b.Length;
            if (n == 0 || m == 0)
            {
                return Array.Empty<uint>();
            }

            if (System.Math.Min(n, m) <= 60)
            {
                var c = ConvolutionNaive<TMod>(a.Select(ai => new StaticModInt<TMod>(ai)).ToArray(),
                                               b.Select(bi => new StaticModInt<TMod>(bi)).ToArray());
                return c.Select(ci => (uint)ci.Value).ToArray();
            }
            else
            {
                int z = 1 << Internal.InternalMath.CeilPow2(n + m - 1);

                var aTemp = new StaticModInt<TMod>[z];
                for (int i = 0; i < a.Length; i++)
                {
                    aTemp[i] = new StaticModInt<TMod>(a[i]);
                }

                var bTemp = new StaticModInt<TMod>[z];
                for (int i = 0; i < b.Length; i++)
                {
                    bTemp[i] = new StaticModInt<TMod>(b[i]);
                }

                var c = Convolution<TMod>(aTemp, bTemp, n, m, z)[0..(n + m - 1)];
                var result = new uint[c.Length];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = (uint)c[i].Value;
                }
                return result;
            }
        }

        /// <summary>
        /// 畳み込みを mod <typeparamref name="TMod"/> で計算します。
        /// </summary>
        /// <remarks>
        /// <para><paramref name="a"/>, <paramref name="b"/> の少なくとも一方が空の場合は空配列を返します。</para>
        /// <para>制約:</para>
        /// <para>- 2≤<typeparamref name="TMod"/>≤2×10^9</para>
        /// <para>- <typeparamref name="TMod"/> は素数</para>
        /// <para>- 2^c | (<typeparamref name="TMod"/> - 1) かつ |<paramref name="a"/>| + |<paramref name="b"/>| - 1 ≤ 2^c なる c が存在する</para>
        /// <para>計算量: O((|<paramref name="a"/>|+|<paramref name="b"/>|)log(|<paramref name="a"/>|+|<paramref name="b"/>|) + log<typeparamref name="TMod"/>)</para>
        /// </remarks>
        public static long[] Convolution<TMod>(long[] a, long[] b) where TMod : struct, IStaticMod
        {
            var n = a.Length;
            var m = b.Length;
            if (n == 0 || m == 0)
            {
                return Array.Empty<long>();
            }

            if (System.Math.Min(n, m) <= 60)
            {
                var c = ConvolutionNaive<TMod>(a.Select(ai => new StaticModInt<TMod>(ai)).ToArray(),
                                               b.Select(bi => new StaticModInt<TMod>(bi)).ToArray());
                return c.Select(ci => (long)ci.Value).ToArray();
            }
            else
            {
                int z = 1 << Internal.InternalMath.CeilPow2(n + m - 1);

                var aTemp = new StaticModInt<TMod>[z];
                for (int i = 0; i < a.Length; i++)
                {
                    aTemp[i] = new StaticModInt<TMod>(a[i]);
                }

                var bTemp = new StaticModInt<TMod>[z];
                for (int i = 0; i < b.Length; i++)
                {
                    bTemp[i] = new StaticModInt<TMod>(b[i]);
                }

                var c = Convolution<TMod>(aTemp, bTemp, n, m, z)[0..(n + m - 1)];
                var result = new long[c.Length];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = c[i].Value;
                }
                return result;
            }
        }

        /// <summary>
        /// 畳み込みを mod <typeparamref name="TMod"/> で計算します。
        /// </summary>
        /// <remarks>
        /// <para><paramref name="a"/>, <paramref name="b"/> の少なくとも一方が空の場合は空配列を返します。</para>
        /// <para>制約:</para>
        /// <para>- 2≤<typeparamref name="TMod"/>≤2×10^9</para>
        /// <para>- <typeparamref name="TMod"/> は素数</para>
        /// <para>- 2^c | (<typeparamref name="TMod"/> - 1) かつ |<paramref name="a"/>| + |<paramref name="b"/>| - 1 ≤ 2^c なる c が存在する</para>
        /// <para>計算量: O((|<paramref name="a"/>|+|<paramref name="b"/>|)log(|<paramref name="a"/>|+|<paramref name="b"/>|) + log<typeparamref name="TMod"/>)</para>
        /// </remarks>
        public static ulong[] Convolution<TMod>(ulong[] a, ulong[] b) where TMod : struct, IStaticMod
        {
            var n = a.Length;
            var m = b.Length;
            if (n == 0 || m == 0)
            {
                return Array.Empty<ulong>();
            }

            if (System.Math.Min(n, m) <= 60)
            {
                var c = ConvolutionNaive<TMod>(a.Select(TakeMod).ToArray(),
                                               b.Select(TakeMod).ToArray());
                return c.Select(ci => (ulong)ci.Value).ToArray();
            }
            else
            {
                int z = 1 << Internal.InternalMath.CeilPow2(n + m - 1);

                var aTemp = new StaticModInt<TMod>[z];
                for (int i = 0; i < a.Length; i++)
                {
                    aTemp[i] = TakeMod(a[i]);
                }

                var bTemp = new StaticModInt<TMod>[z];
                for (int i = 0; i < b.Length; i++)
                {
                    bTemp[i] = TakeMod(b[i]);
                }

                var c = Convolution<TMod>(aTemp, bTemp, n, m, z)[0..(n + m - 1)];
                var result = new ulong[c.Length];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = (ulong)c[i].Value;
                }
                return result;
            }

            StaticModInt<TMod> TakeMod(ulong x) => StaticModInt<TMod>.Raw((int)(x % default(TMod).Mod));
        }

        /// <summary>
        /// 畳み込みを mod <typeparamref name="TMod"/> で計算します。
        /// </summary>
        /// <remarks>
        /// <para><paramref name="a"/>, <paramref name="b"/> の少なくとも一方が空の場合は空配列を返します。</para>
        /// <para>制約:</para>
        /// <para>- 2≤<typeparamref name="TMod"/>≤2×10^9</para>
        /// <para>- <typeparamref name="TMod"/> は素数</para>
        /// <para>- 2^c | (<typeparamref name="TMod"/> - 1) かつ |<paramref name="a"/>| + |<paramref name="b"/>| - 1 ≤ 2^c なる c が存在する</para>
        /// <para>計算量: O((|<paramref name="a"/>|+|<paramref name="b"/>|)log(|<paramref name="a"/>|+|<paramref name="b"/>|) + log<typeparamref name="TMod"/>)</para>
        /// </remarks>
        public static StaticModInt<TMod>[] Convolution<TMod>(StaticModInt<TMod>[] a, StaticModInt<TMod>[] b)
            where TMod : struct, IStaticMod
        {
            var temp = Convolution((ReadOnlySpan<StaticModInt<TMod>>)a, b);
            return temp.ToArray();
        }

        /// <summary>
        /// 畳み込みを mod <typeparamref name="TMod"/> で計算します。
        /// </summary>
        /// <remarks>
        /// <para><paramref name="a"/>, <paramref name="b"/> の少なくとも一方が空の場合は空配列を返します。</para>
        /// <para>制約:</para>
        /// <para>- 2≤<typeparamref name="TMod"/>≤2×10^9</para>
        /// <para>- <typeparamref name="TMod"/> は素数</para>
        /// <para>- 2^c | (<typeparamref name="TMod"/> - 1) かつ |<paramref name="a"/>| + |<paramref name="b"/>| - 1 ≤ 2^c なる c が存在する</para>
        /// <para>計算量: O((|<paramref name="a"/>|+|<paramref name="b"/>|)log(|<paramref name="a"/>|+|<paramref name="b"/>|) + log<typeparamref name="TMod"/>)</para>
        /// </remarks>
        public static Span<StaticModInt<TMod>> Convolution<TMod>(ReadOnlySpan<StaticModInt<TMod>> a, ReadOnlySpan<StaticModInt<TMod>> b)
            where TMod : struct, IStaticMod
        {
            var n = a.Length;
            var m = b.Length;
            if (n == 0 || m == 0)
            {
                return Array.Empty<StaticModInt<TMod>>();
            }

            if (System.Math.Min(n, m) <= 60)
            {
                return ConvolutionNaive(a, b);
            }

            int z = 1 << Internal.InternalMath.CeilPow2(n + m - 1);

            var aTemp = new StaticModInt<TMod>[z];
            a.CopyTo(aTemp);

            var bTemp = new StaticModInt<TMod>[z];
            b.CopyTo(bTemp);

            return Convolution(aTemp.AsSpan(), bTemp.AsSpan(), n, m, z);
        }

        private static Span<StaticModInt<TMod>> Convolution<TMod>(Span<StaticModInt<TMod>> a, Span<StaticModInt<TMod>> b, int n, int m, int z)
            where TMod : struct, IStaticMod
        {
            Internal.Butterfly<TMod>.Calculate(a);
            Internal.Butterfly<TMod>.Calculate(b);

            for (int i = 0; i < a.Length; i++)
            {
                a[i] *= b[i];
            }

            Internal.Butterfly<TMod>.CalculateInv(a);
            var result = a[0..(n + m - 1)];
            var iz = new StaticModInt<TMod>(z).Inv();
            foreach (ref var r in result)
            {
                r *= iz;
            }

            return result;
        }

        /// <summary>
        /// 畳み込みを計算します。
        /// </summary>
        /// <remarks>
        /// <para><paramref name="a"/>, <paramref name="b"/> の少なくとも一方が空の場合は空配列を返します。</para>
        /// <para>制約:</para>
        /// <para>- |<paramref name="a"/>| + |<paramref name="b"/>| - 1 ≤ 2^24 = 16,777,216</para>
        /// <para>- 畳み込んだ後の配列の要素が全て long に収まる</para>
        /// <para>計算量: O((|<paramref name="a"/>|+|<paramref name="b"/>|)log(|<paramref name="a"/>|+|<paramref name="b"/>|))</para>
        /// </remarks>
        public static long[] ConvolutionLong(ReadOnlySpan<long> a, ReadOnlySpan<long> b)
        {
            unchecked
            {
                var n = a.Length;
                var m = b.Length;

                if (n == 0 || m == 0)
                {
                    return Array.Empty<long>();
                }

                const ulong Mod1 = 754974721;
                const ulong Mod2 = 167772161;
                const ulong Mod3 = 469762049;
                const ulong M2M3 = Mod2 * Mod3;
                const ulong M1M3 = Mod1 * Mod3;
                const ulong M1M2 = Mod1 * Mod2;
                // (m1 * m2 * m3) % 2^64
                const ulong M1M2M3 = Mod1 * Mod2 * Mod3;

                ulong i1 = (ulong)Internal.InternalMath.InvGCD((long)M2M3, (long)Mod1).Item2;
                ulong i2 = (ulong)Internal.InternalMath.InvGCD((long)M1M3, (long)Mod2).Item2;
                ulong i3 = (ulong)Internal.InternalMath.InvGCD((long)M1M2, (long)Mod3).Item2;

                var c1 = Convolution<FFTMod1>(a, b);
                var c2 = Convolution<FFTMod2>(a, b);
                var c3 = Convolution<FFTMod3>(a, b);

                var c = new long[n + m - 1];

                Span<ulong> offset = stackalloc ulong[] { 0, 0, M1M2M3, 2 * M1M2M3, 3 * M1M2M3 };

                for (int i = 0; i < c.Length; i++)
                {
                    ulong x = 0;
                    x += (c1[i] * i1) % Mod1 * M2M3;
                    x += (c2[i] * i2) % Mod2 * M1M3;
                    x += (c3[i] * i3) % Mod3 * M1M2;

                    long diff = (long)c1[i] - Internal.InternalMath.SafeMod((long)x, (long)Mod1);
                    if (diff < 0)
                    {
                        diff += (long)Mod1;
                    }

                    // 真値を r, 得られた値を x, M1M2M3 % 2^64 = M', B = 2^63 として、
                    // r = x,
                    //     x -  M' + (0 or 2B),
                    //     x - 2M' + (0 or 2B or 4B),
                    //     x - 3M' + (0 or 2B or 4B or 6B)
                    // のいずれかが成り立つ、らしい
                    // -> see atcoder/convolution.hpp
                    x -= offset[(int)(diff % offset.Length)];
                    c[i] = (long)x;
                }

                return c;
            }


            ulong[] Convolution<TMod>(ReadOnlySpan<long> a, ReadOnlySpan<long> b) where TMod : struct, IStaticMod
            {
                int z = 1 << Internal.InternalMath.CeilPow2(a.Length + b.Length - 1);

                var aTemp = new StaticModInt<TMod>[z];
                for (int i = 0; i < a.Length; i++)
                {
                    aTemp[i] = new StaticModInt<TMod>(a[i]);
                }

                var bTemp = new StaticModInt<TMod>[z];
                for (int i = 0; i < b.Length; i++)
                {
                    bTemp[i] = new StaticModInt<TMod>(b[i]);
                }

                var c = AtCoder.Math.Convolution<TMod>(aTemp, bTemp, a.Length, b.Length, z);
                var result = new ulong[c.Length];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = (ulong)c[i].Value;
                }

                return result;
            }
        }

        private static StaticModInt<TMod>[] ConvolutionNaive<TMod>(ReadOnlySpan<StaticModInt<TMod>> a, ReadOnlySpan<StaticModInt<TMod>> b)
            where TMod : struct, IStaticMod
        {
            if (a.Length < b.Length)
            {
                // ref 構造体のため型引数として使えない
                var temp = a;
                a = b;
                b = temp;
            }

            var ans = new StaticModInt<TMod>[a.Length + b.Length - 1];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    ans[i + j] += a[i] * b[j];
                }
            }

            return ans;
        }

        private readonly struct FFTMod1 : IStaticMod
        {
            public uint Mod => 754974721;
            public bool IsPrime => true;
        }

        private readonly struct FFTMod2 : IStaticMod
        {
            public uint Mod => 167772161;
            public bool IsPrime => true;
        }

        private readonly struct FFTMod3 : IStaticMod
        {
            public uint Mod => 469762049;
            public bool IsPrime => true;
        }
    }
}

namespace AtCoder.Internal
{
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

namespace AtCoder.Internal
{
    public static partial class InternalMath
    {
        private static readonly Dictionary<int, int> primitiveRootsCache = new Dictionary<int, int>()
        {
            { 2, 1 },
            { 167772161, 3 },
            { 469762049, 3 },
            { 754974721, 11 },
            { 998244353, 3 }
        };

        /// <summary>
        /// <paramref name="m"/> の最小の原始根を求めます。
        /// </summary>
        /// <remarks>
        /// 制約: <paramref name="m"/> は素数
        /// </remarks>
        public static int PrimitiveRoot(int m)
        {
            Debug.Assert(m >= 2);

            if (primitiveRootsCache.TryGetValue(m, out var p))
            {
                return p;
            }

            return primitiveRootsCache[m] = Calculate(m);

            int Calculate(int m)
            {
                Span<int> divs = stackalloc int[20];
                divs[0] = 2;
                int cnt = 1;
                int x = (m - 1) / 2;

                while (x % 2 == 0)
                {
                    x >>= 1;
                }

                for (int i = 3; (long)i * i <= x; i += 2)
                {
                    if (x % i == 0)
                    {
                        divs[cnt++] = i;
                        while (x % i == 0)
                        {
                            x /= i;
                        }
                    }
                }

                if (x > 1)
                {
                    divs[cnt++] = x;
                }

                for (int g = 2; ; g++)
                {
                    bool ok = true;
                    for (int i = 0; i < cnt; i++)
                    {
                        if (Math.PowMod(g, (m - 1) / divs[i], m) == 1)
                        {
                            ok = false;
                            break;
                        }
                    }

                    if (ok)
                    {
                        return g;
                    }
                }
            }
        }
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

namespace AtCoder
{
    public static partial class Math
    {
        /// <summary>
        /// <paramref name="x"/>^<paramref name="n"/> mod <paramref name="m"/> を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/>, 1≤<paramref name="m"/></para>
        /// <para>計算量: O(log<paramref name="n"/>)</para>
        /// </remarks>
        public static long PowMod(long x, long n, int m)
        {
            Debug.Assert(0 <= n && 1 <= m);
            if (m == 1) return 0;
            Barrett barrett = new Barrett((uint)m);
            uint r = 1, y = (uint)InternalMath.SafeMod(x, m);
            while (0 < n)
            {
                if ((n & 1) != 0) r = barrett.Mul(r, y);
                y = barrett.Mul(y, y);
                n >>= 1;
            }
            return r;
        }
    }
}

namespace AtCoder.Internal
{
    public static class InternalBit
    {
        /// <summary>
        /// _blsi_u32 OR <paramref name="n"/> &amp; -<paramref name="n"/>
        /// <para><paramref name="n"/>で立っているうちの最下位の 1 ビットのみを立てた整数を返す</para>
        /// </summary>
        /// <param name="n"></param>
        /// <returns><paramref name="n"/> &amp; -<paramref name="n"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ExtractLowestSetBit(int n)
        {
            if (Bmi1.IsSupported)
            {
                return (int)Bmi1.ExtractLowestSetBit((uint)n);
            }
            return n & -n;
        }

        /// <summary>
        /// (<paramref name="n"/> &amp; (1 &lt;&lt; x)) != 0 なる最小の非負整数 x を求めます。
        /// </summary>
        /// <remarks>
        /// <para>BSF: Bit Scan Forward</para>
        /// <para>制約: 1 ≤ <paramref name="n"/></para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BSF(uint n)
        {
            Debug.Assert(n >= 1);
            return BitOperations.TrailingZeroCount(n);
        }
    }
}

namespace Test20200915
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionA();
            var answers = question.Solve(Console.In);

            var writer = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(writer);
            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }
            Console.Out.Flush();
        }
    }
}

#region Base Class

namespace Test20200915.Questions
{

    public interface IAtCoderQuestion
    {
        IEnumerable<object> Solve(string input);
        IEnumerable<object> Solve(TextReader inputStream);
    }

    public abstract class AtCoderQuestionBase : IAtCoderQuestion
    {
        public IEnumerable<object> Solve(string input)
        {
            var stream = new MemoryStream(Encoding.Unicode.GetBytes(input));
            var reader = new StreamReader(stream, Encoding.Unicode);

            return Solve(reader);
        }

        public abstract IEnumerable<object> Solve(TextReader inputStream);
    }
}

#endregion

#region Extensions

namespace Test20200915.Extensions
{
    public static class StringExtensions
    {
        public static string Join<T>(this IEnumerable<T> source) => string.Concat(source);
        public static string Join<T>(this IEnumerable<T> source, char separator) => string.Join(separator, source);
        public static string Join<T>(this IEnumerable<T> source, string separator) => string.Join(separator, source);
    }

    public static class TextReaderExtensions
    {
        public static int ReadInt(this TextReader reader) => int.Parse(ReadString(reader));
        public static long ReadLong(this TextReader reader) => long.Parse(ReadString(reader));
        public static double ReadDouble(this TextReader reader) => double.Parse(ReadString(reader));
        public static string ReadString(this TextReader reader) => reader.ReadLine();

        public static int[] ReadIntArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(int.Parse).ToArray();
        public static long[] ReadLongArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(long.Parse).ToArray();
        public static double[] ReadDoubleArray(this TextReader reader, char separator = ' ') => ReadStringArray(reader, separator).Select(double.Parse).ToArray();
        public static string[] ReadStringArray(this TextReader reader, char separator = ' ') => reader.ReadLine().Split(separator);

        // Supports primitive type only.
        public static T1 ReadValue<T1>(this TextReader reader) => (T1)Convert.ChangeType(reader.ReadLine(), typeof(T1));

        public static (T1, T2) ReadValue<T1, T2>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            return (v1, v2);
        }

        public static (T1, T2, T3) ReadValue<T1, T2, T3>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            return (v1, v2, v3);
        }

        public static (T1, T2, T3, T4) ReadValue<T1, T2, T3, T4>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            var v4 = (T4)Convert.ChangeType(inputs[3], typeof(T4));
            return (v1, v2, v3, v4);
        }

        public static (T1, T2, T3, T4, T5) ReadValue<T1, T2, T3, T4, T5>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            var v4 = (T4)Convert.ChangeType(inputs[3], typeof(T4));
            var v5 = (T5)Convert.ChangeType(inputs[4], typeof(T5));
            return (v1, v2, v3, v4, v5);
        }

        public static (T1, T2, T3, T4, T5, T6) ReadValue<T1, T2, T3, T4, T5, T6>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            var v4 = (T4)Convert.ChangeType(inputs[3], typeof(T4));
            var v5 = (T5)Convert.ChangeType(inputs[4], typeof(T5));
            var v6 = (T6)Convert.ChangeType(inputs[5], typeof(T6));
            return (v1, v2, v3, v4, v5, v6);
        }

        public static (T1, T2, T3, T4, T5, T6, T7) ReadValue<T1, T2, T3, T4, T5, T6, T7>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            var v4 = (T4)Convert.ChangeType(inputs[3], typeof(T4));
            var v5 = (T5)Convert.ChangeType(inputs[4], typeof(T5));
            var v6 = (T6)Convert.ChangeType(inputs[5], typeof(T6));
            var v7 = (T7)Convert.ChangeType(inputs[6], typeof(T7));
            return (v1, v2, v3, v4, v5, v6, v7);
        }

        public static (T1, T2, T3, T4, T5, T6, T7, T8) ReadValue<T1, T2, T3, T4, T5, T6, T7, T8>(this TextReader reader, char separator = ' ')
        {
            var inputs = ReadStringArray(reader, separator);
            var v1 = (T1)Convert.ChangeType(inputs[0], typeof(T1));
            var v2 = (T2)Convert.ChangeType(inputs[1], typeof(T2));
            var v3 = (T3)Convert.ChangeType(inputs[2], typeof(T3));
            var v4 = (T4)Convert.ChangeType(inputs[3], typeof(T4));
            var v5 = (T5)Convert.ChangeType(inputs[4], typeof(T5));
            var v6 = (T6)Convert.ChangeType(inputs[5], typeof(T6));
            var v7 = (T7)Convert.ChangeType(inputs[6], typeof(T7));
            var v8 = (T8)Convert.ChangeType(inputs[7], typeof(T8));
            return (v1, v2, v3, v4, v5, v6, v7, v8);
        }
    }
}

#endregion