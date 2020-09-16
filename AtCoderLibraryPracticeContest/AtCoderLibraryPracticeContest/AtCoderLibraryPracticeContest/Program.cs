using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderLibraryPracticeContest.Extensions;
using AtCoderLibraryPracticeContest.Questions;
using System.Diagnostics;
using AtCoder.Internal;
using System.Runtime.Intrinsics.X86;
using System.Numerics;

namespace AtCoderLibraryPracticeContest
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionD();
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

namespace AtCoder
{
    public class DSU
    {
        private int Count;
        private int[] ParentOrSize;

        /// <summary>
        /// <see cref="DSU"/> クラスの新しいインスタンスを、<paramref name="n"/> 頂点 0 辺のグラフとして初期化します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/>≤10^8</para>
        /// <para>計算量: O(<paramref name="n"/>)</para>
        /// </remarks>
        public DSU(int n)
        {
            Count = n;
            ParentOrSize = new int[n];
            for (int i = 0; i < ParentOrSize.Length; i++) ParentOrSize[i] = -1;
        }

        /// <summary>
        /// 頂点 <paramref name="a"/> と頂点 <paramref name="b"/> を結ぶ辺を追加し、それらの代表元を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="a"/>, <paramref name="b"/>&lt;n</para>
        /// <para>計算量: ならしO(a(n))</para>
        /// </remarks>
        public int Merge(int a, int b)
        {
            Debug.Assert(0 <= a && a < Count);
            Debug.Assert(0 <= b && b < Count);
            int x = Leader(a), y = Leader(b);
            if (x == y) return x;
            if (-ParentOrSize[x] < ParentOrSize[y]) (x, y) = (y, x);
            ParentOrSize[x] += ParentOrSize[y];
            ParentOrSize[y] = x;
            return x;
        }

        /// <summary>
        /// 頂点 <paramref name="a"/>, <paramref name="b"/> が連結かどうかを返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="a"/>, <paramref name="b"/>&lt;n</para>
        /// <para>計算量: ならしO(a(n))</para>
        /// </remarks>
        public bool Same(int a, int b)
        {
            Debug.Assert(0 <= a && a < Count);
            Debug.Assert(0 <= b && b < Count);
            return Leader(a) == Leader(b);
        }

        /// <summary>
        /// 頂点 <paramref name="a"/> の属する連結成分の代表元を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="a"/>&lt;n</para>
        /// <para>計算量: ならしO(a(n))</para>
        /// </remarks>
        public int Leader(int a)
        {
            if (ParentOrSize[a] < 0) return a;
            while (0 <= ParentOrSize[ParentOrSize[a]])
            {
                (a, ParentOrSize[a]) = (ParentOrSize[a], ParentOrSize[ParentOrSize[a]]);
            }
            return ParentOrSize[a];
        }


        /// <summary>
        /// 頂点 <paramref name="a"/> の属する連結成分のサイズを返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="a"/>&lt;n</para>
        /// <para>計算量: ならしO(a(n))</para>
        /// </remarks>
        public int Size(int a)
        {
            Debug.Assert(0 <= a && a < Count);
            return -ParentOrSize[Leader(a)];
        }

        /// <summary>
        /// グラフを連結成分に分け、その情報を返します。
        /// </summary>
        /// <para>計算量: O(n)</para>
        /// <returns>「一つの連結成分の頂点番号のリスト」のリスト。</returns>
        public Span<int[]> Groups()
        {
            int[] leaderBuf = new int[Count];
            int[] id = new int[Count];
            Span<int[]> result = new int[Count][];
            int groupCount = 0;
            for (int i = 0; i < leaderBuf.Length; i++)
            {
                leaderBuf[i] = Leader(i);
                if (i == leaderBuf[i])
                {
                    id[i] = groupCount;
                    result[id[i]] = new int[-ParentOrSize[i]];
                    groupCount++;
                }
            }
            int[] ind = new int[groupCount];
            result = result.Slice(0, groupCount);
            for (int i = 0; i < leaderBuf.Length; i++)
            {
                var leaderID = id[leaderBuf[i]];
                result[leaderID][ind[leaderID]] = i;
                ind[leaderID]++;
            }
            return result;
        }
    }
}

namespace AtCoder
{
#pragma warning disable CA1815 // Override equals and operator equals on value types
    public interface INumOperator<T> : IEqualityComparer<T>, IComparer<T> where T : struct
    {
        /// <summary>
        /// MinValue
        /// </summary>
        public T MinValue { get; }
        /// <summary>
        /// MaxValue
        /// </summary>
        public T MaxValue { get; }
        /// <summary>
        /// Addition operator +
        /// </summary>
        /// <returns><paramref name="x"/> + <paramref name="y"/></returns>
        T Add(T x, T y);
        /// <summary>
        /// Subtraction operator -
        /// </summary>
        /// <returns><paramref name="x"/> - <paramref name="y"/></returns>
        T Subtract(T x, T y);
        /// <summary>
        /// Multiplication operator *
        /// </summary>
        /// <returns><paramref name="x"/> * <paramref name="y"/></returns>
        T Multiply(T x, T y);
        /// <summary>
        /// Division operator /
        /// </summary>
        /// <returns><paramref name="x"/> / <paramref name="y"/></returns>
        T Divide(T x, T y);
        /// <summary>
        /// Remainder operator %
        /// </summary>
        /// <returns><paramref name="x"/> % <paramref name="y"/></returns>
        T Modulo(T x, T y);
        /// <summary>
        /// Greater than operator &gt;
        /// </summary>
        /// <returns><paramref name="x"/> &gt; <paramref name="y"/></returns>
        bool GreaterThan(T x, T y);
        /// <summary>
        /// Greater than or equal operator &gt;=
        /// </summary>
        /// <returns><paramref name="x"/> &gt;= <paramref name="y"/></returns>
        bool GreaterThanOrEqual(T x, T y);
        /// <summary>
        /// Less than operator &lt;
        /// </summary>
        /// <returns><paramref name="x"/> &lt; <paramref name="y"/></returns>
        bool LessThan(T x, T y);
        /// <summary>
        /// Less than or equal operator &lt;=
        /// </summary>
        /// <returns><paramref name="x"/> &lt;= <paramref name="y"/></returns>
        bool LessThanOrEqual(T x, T y);
    }
    public readonly struct IntOperator : INumOperator<int>
    {
        public int MinValue => int.MinValue;
        public int MaxValue => int.MaxValue;
        public int Add(int x, int y) => x + y;
        public int Subtract(int x, int y) => x - y;
        public int Multiply(int x, int y) => x * y;
        public int Divide(int x, int y) => x / y;
        public int Modulo(int x, int y) => x % y;
        public bool GreaterThan(int x, int y) => x > y;
        public bool GreaterThanOrEqual(int x, int y) => x >= y;
        public bool LessThan(int x, int y) => x < y;
        public bool LessThanOrEqual(int x, int y) => x <= y;
        public int Compare(int x, int y) => x.CompareTo(y);
        public bool Equals(int x, int y) => x == y;
        public int GetHashCode(int obj) => obj.GetHashCode();
    }
    public readonly struct LongOperator : INumOperator<long>
    {
        public long MinValue => long.MinValue;
        public long MaxValue => long.MaxValue;
        public long Add(long x, long y) => x + y;
        public long Subtract(long x, long y) => x - y;
        public long Multiply(long x, long y) => x * y;
        public long Divide(long x, long y) => x / y;
        public long Modulo(long x, long y) => x % y;
        public bool GreaterThan(long x, long y) => x > y;
        public bool GreaterThanOrEqual(long x, long y) => x >= y;
        public bool LessThan(long x, long y) => x < y;
        public bool LessThanOrEqual(long x, long y) => x <= y;
        public int Compare(long x, long y) => x.CompareTo(y);
        public bool Equals(long x, long y) => x == y;
        public int GetHashCode(long obj) => obj.GetHashCode();
    }
    public readonly struct UIntOperator : INumOperator<uint>
    {
        public uint MinValue => uint.MinValue;
        public uint MaxValue => uint.MaxValue;
        public uint Add(uint x, uint y) => x + y;
        public uint Subtract(uint x, uint y) => x - y;
        public uint Multiply(uint x, uint y) => x * y;
        public uint Divide(uint x, uint y) => x / y;
        public uint Modulo(uint x, uint y) => x % y;
        public bool GreaterThan(uint x, uint y) => x > y;
        public bool GreaterThanOrEqual(uint x, uint y) => x >= y;
        public bool LessThan(uint x, uint y) => x < y;
        public bool LessThanOrEqual(uint x, uint y) => x <= y;
        public int Compare(uint x, uint y) => x.CompareTo(y);
        public bool Equals(uint x, uint y) => x == y;
        public int GetHashCode(uint obj) => obj.GetHashCode();
    }
    public readonly struct ULongOperator : INumOperator<ulong>
    {
        public ulong MinValue => ulong.MinValue;
        public ulong MaxValue => ulong.MaxValue;
        public ulong Add(ulong x, ulong y) => x + y;
        public ulong Subtract(ulong x, ulong y) => x - y;
        public ulong Multiply(ulong x, ulong y) => x * y;
        public ulong Divide(ulong x, ulong y) => x / y;
        public ulong Modulo(ulong x, ulong y) => x % y;
        public bool GreaterThan(ulong x, ulong y) => x > y;
        public bool GreaterThanOrEqual(ulong x, ulong y) => x >= y;
        public bool LessThan(ulong x, ulong y) => x < y;
        public bool LessThanOrEqual(ulong x, ulong y) => x <= y;
        public int Compare(ulong x, ulong y) => x.CompareTo(y);
        public bool Equals(ulong x, ulong y) => x == y;
        public int GetHashCode(ulong obj) => obj.GetHashCode();
    }
    public readonly struct DoubleOperator : INumOperator<double>
    {
        public double MinValue => double.MinValue;
        public double MaxValue => double.MaxValue;
        public double Add(double x, double y) => x + y;
        public double Subtract(double x, double y) => x - y;
        public double Multiply(double x, double y) => x * y;
        public double Divide(double x, double y) => x / y;
        public double Modulo(double x, double y) => x % y;
        public bool GreaterThan(double x, double y) => x > y;
        public bool GreaterThanOrEqual(double x, double y) => x >= y;
        public bool LessThan(double x, double y) => x < y;
        public bool LessThanOrEqual(double x, double y) => x <= y;
        public int Compare(double x, double y) => x.CompareTo(y);
        public bool Equals(double x, double y) => x == y;
        public int GetHashCode(double obj) => obj.GetHashCode();
    }
#pragma warning restore CA1815 // Override equals and operator equals on value types
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
            if (Bmi1.IsSupported)
            {
                // O(1)
                return (int)Bmi1.TrailingZeroCount(n);
            }
            else if (Popcnt.IsSupported)
            {
                // O(1)
                return (int)Popcnt.PopCount(~n & (n - 1));
            }
            else
            {
                // O(logn)
                return BitOperations.TrailingZeroCount(n);
            }
        }
    }
}

namespace AtCoder
{

    /// <summary>
    /// 長さ N の配列に対し、
    /// <list type="bullet">
    /// <item>
    /// <description>要素の 1 点変更</description>
    /// </item>
    /// <item>
    /// <description>区間の要素の総和</description>
    /// </item>
    /// </list>
    /// <para>を O(log⁡N) で求めることが出来るデータ構造です。</para>
    /// </summary>
    public class IntFenwickTree : FenwickTree<int, IntOperator> { public IntFenwickTree(int n) : base(n) { } }

    /// <summary>
    /// 長さ N の配列に対し、
    /// <list type="bullet">
    /// <item>
    /// <description>要素の 1 点変更</description>
    /// </item>
    /// <item>
    /// <description>区間の要素の総和</description>
    /// </item>
    /// </list>
    /// <para>を O(log⁡N) で求めることが出来るデータ構造です。</para>
    /// </summary>
    public class UIntFenwickTree : FenwickTree<uint, UIntOperator> { public UIntFenwickTree(int n) : base(n) { } }

    /// <summary>
    /// 長さ N の配列に対し、
    /// <list type="bullet">
    /// <item>
    /// <description>要素の 1 点変更</description>
    /// </item>
    /// <item>
    /// <description>区間の要素の総和</description>
    /// </item>
    /// </list>
    /// <para>を O(log⁡N) で求めることが出来るデータ構造です。</para>
    /// </summary>
    public class LongFenwickTree : FenwickTree<long, LongOperator> { public LongFenwickTree(int n) : base(n) { } }

    /// <summary>
    /// 長さ N の配列に対し、
    /// <list type="bullet">
    /// <item>
    /// <description>要素の 1 点変更</description>
    /// </item>
    /// <item>
    /// <description>区間の要素の総和</description>
    /// </item>
    /// </list>
    /// <para>を O(log⁡N) で求めることが出来るデータ構造です。</para>
    /// </summary>
    public class ULongFenwickTree : FenwickTree<ulong, ULongOperator> { public ULongFenwickTree(int n) : base(n) { } }

    /// <summary>
    /// 長さ N の配列に対し、
    /// <list type="bullet">
    /// <item>
    /// <description>要素の 1 点変更</description>
    /// </item>
    /// <item>
    /// <description>区間の要素の総和</description>
    /// </item>
    /// </list>
    /// <para>を O(log⁡N) で求めることが出来るデータ構造です。</para>
    /// </summary>
    // TODO: public class ModIntFenwickTree : FenwickTree<ModInt, ModIntOperator> { public ModIntFenwickTree(int n) : base(n) { } }


    /// <summary>
    /// 長さ N の配列に対し、
    /// <list type="bullet">
    /// <item>
    /// <description>要素の 1 点変更</description>
    /// </item>
    /// <item>
    /// <description>区間の要素の総和</description>
    /// </item>
    /// </list>
    /// <para>を O(log⁡N) で求めることが出来るデータ構造です。</para>
    /// </summary>
    /// <typeparam name="TValue">配列要素の型</typeparam>
    /// <typeparam name="TOp">配列要素の操作を表す型</typeparam>
    [DebuggerTypeProxy(typeof(FenwickTree<,>.DebugView))]
    public class FenwickTree<TValue, TOp>
        where TValue : struct
        where TOp : struct, INumOperator<TValue>
    {
        private static readonly TOp op = default;
        private readonly TValue[] data;

        /// <summary>
        /// 長さ <paramref name="n"/> の配列aを持つ <see cref="FenwickTree{TValue, TOp}"/> クラスの新しいインスタンスを作ります。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/>≤10^8</para>
        /// <para>計算量: O(<paramref name="n"/>)</para>
        /// </remarks>
        /// <param name="n">配列の長さ</param>
        public FenwickTree(int n)
        {
            Debug.Assert(unchecked((uint)n <= 100_000_000));
            data = new TValue[n + 1];
        }

        /// <summary>
        /// a[<paramref name="p"/>] += <paramref name="x"/> を行います。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="p"/>&lt;n</para>
        /// <para>計算量: O(log n)</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(int p, TValue x)
        {
            Debug.Assert(unchecked((uint)p < data.Length));
            for (p++; p < data.Length; p += InternalBit.ExtractLowestSetBit(p))
            {
                data[p] = op.Add(data[p], x);
            }
        }

        /// <summary>
        /// a[<paramref name="l"/>] + a[<paramref name="l"/> - 1] + ... + a[<paramref name="r"/> - 1] を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="l"/>≤<paramref name="r"/>≤n</para>
        /// <para>計算量: O(log n)</para>
        /// </remarks>
        /// <returns>a[<paramref name="l"/>] + a[<paramref name="l"/> - 1] + ... + a[<paramref name="r"/> - 1]</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TValue Sum(int l, int r)
        {
            Debug.Assert(0 <= l && l <= r && r < data.Length);
            return op.Subtract(Sum(r), Sum(l));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TValue Sum(int r)
        {
            TValue s = default;
            for (; r > 0; r -= InternalBit.ExtractLowestSetBit(r))
            {
                s = op.Add(s, data[r]);
            }
            return s;
        }


        [DebuggerDisplay("Value = {" + nameof(value) + "}, Sum = {" + nameof(sum) + "}")]
        private struct DebugItem
        {
            public DebugItem(TValue value, TValue sum)
            {
                this.sum = sum;
                this.value = value;
            }
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public readonly TValue value;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            public readonly TValue sum;
        }
        private class DebugView
        {
            private readonly FenwickTree<TValue, TOp> fenwickTree;
            public DebugView(FenwickTree<TValue, TOp> fenwickTree)
            {
                this.fenwickTree = fenwickTree;
            }
            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public DebugItem[] Items
            {
                get
                {
                    var data = fenwickTree.data;
                    var items = new DebugItem[data.Length - 1];
                    items[0] = new DebugItem(data[1], data[1]);
                    for (int i = 2; i < data.Length; i++)
                    {
                        int length = InternalBit.ExtractLowestSetBit(i);
                        var pr = i - length - 1;
                        var sum = op.Add(data[i], 0 <= pr ? items[pr].sum : default);
                        var val = op.Subtract(sum, items[i - 2].sum);
                        items[i - 1] = new DebugItem(val, sum);
                    }
                    return items;
                }
            }
        }
    }
}

#region Base Class

namespace AtCoderLibraryPracticeContest.Questions
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

namespace AtCoderLibraryPracticeContest.Extensions
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