using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ACLBeginnerContest.Algorithms;
using ACLBeginnerContest.Collections;
using ACLBeginnerContest.Numerics;
using ACLBeginnerContest.Questions;
using AtCoder;
using AtCoder.Internal;

namespace ACLBeginnerContest
{
    class Program
    {
        static void Main(string[] args)
        {
            IAtCoderQuestion question = new QuestionF();
            using var io = new IOManager(Console.OpenStandardInput(), Console.OpenStandardOutput());
            question.Solve(io);
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
            if (-ParentOrSize[x] < -ParentOrSize[y]) (x, y) = (y, x);
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


namespace AtCoder
{
    /// <summary>
    /// 最大フロー問題 を解くライブラリ(int版)です。
    /// </summary>
    public class MFGraphInt : MFGraph<int, IntOperator> { public MFGraphInt(int n) : base(n) { } }

    /// <summary>
    /// 最大フロー問題 を解くライブラリ(long版)です。
    /// </summary>
    public class MFGraphLong : MFGraph<long, LongOperator> { public MFGraphLong(int n) : base(n) { } }

    /// <summary>
    /// 最大フロー問題 を解くライブラリです。
    /// </summary>
    /// <typeparam name="TValue">容量の型</typeparam>
    /// <typeparam name="TOp"><typeparamref name="TValue"/>に対応する演算を提要する型</typeparam>
    /// <remarks>
    /// <para>制約: <typeparamref name="TValue"/> は int, long。</para>
    /// <para>
    /// 内部では各辺 e について 2 つの変数、流量 f_e と容量 c_e を管理しています。
    /// 頂点 v から出る辺の集合を out(v)、入る辺の集合を in(v)、
    /// また頂点 v について g(v, f) = (Σ_in(v) f_e) - (Σ_out(v) f_e) とします。 
    /// </para>
    /// </remarks>
    public class MFGraph<TValue, TOp>
         where TValue : struct
         where TOp : struct, INumOperator<TValue>
    {
        static readonly TOp op = default;

        /// <summary>
        /// <paramref name="n"/> 頂点 0 辺のグラフを作ります。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0 ≤ <paramref name="n"/> ≤ 10^8</para>
        /// <para>計算量: O(<paramref name="n"/>)</para>
        /// </remarks>
        public MFGraph(int n)
        {
            _n = n;
            _g = new List<EdgeInternal>[n];
            for (int i = 0; i < n; i++)
            {
                _g[i] = new List<EdgeInternal>();
            }
            _pos = new List<(int first, int second)>();
        }

        /// <summary>
        /// <paramref name="from"/> から <paramref name="to"/> へ
        /// 最大容量 <paramref name="cap"/>、流量 0 の辺を追加し、何番目に追加された辺かを返します。
        /// </summary>
        /// <remarks>
        /// 制約: 
        /// <list type="bullet">
        /// <item>
        /// <description>0 ≤ <paramref name="from"/>, <paramref name="to"/> &lt; n</description>
        /// </item>
        /// <item>
        /// <description>0 ≤ <paramref name="cap"/></description>
        /// </item>
        /// </list>
        /// <para>計算量: ならしO(1)</para>
        /// </remarks>
        public int AddEdge(int from, int to, TValue cap)
        {
            int m = _pos.Count;
            Debug.Assert(0 <= from && from < _n);
            Debug.Assert(0 <= to && to < _n);
            Debug.Assert(op.LessThanOrEqual(default, cap));
            _pos.Add((from, _g[from].Count));
            _g[from].Add(new EdgeInternal(to, _g[to].Count, cap));
            _g[to].Add(new EdgeInternal(from, _g[from].Count - 1, default));
            return m;
        }

        /// <summary>
        /// 今の内部の辺の状態を返します。
        /// </summary>
        /// <remarks>
        /// <para>AddEdge で <paramref name="i"/> 番目 (0-indexed) に追加された辺を返す。</para>
        /// <para>制約: m を追加された辺数として 0 ≤ i &lt; m</para>
        /// <para>計算量: O(1)</para>
        /// </remarks>
        public Edge GetEdge(int i)
        {
            int m = _pos.Count;
            Debug.Assert(0 <= i && i < m);
            var _e = _g[_pos[i].first][_pos[i].second];
            var _re = _g[_e.To][_e.Rev];
            return new Edge(_pos[i].first, _e.To, op.Add(_e.Cap, _re.Cap), _re.Cap);
        }

        /// <summary>
        /// 今の内部の辺の状態を返します。
        /// </summary>
        /// <remarks>
        /// <para>辺の順番はadd_edgeで追加された順番と同一。</para>
        /// <para>計算量: m を追加された辺数として O(m)</para>
        /// </remarks>
        public List<Edge> Edges()
        {
            int m = _pos.Count;
            var result = new List<Edge>();
            for (int i = 0; i < m; i++)
            {
                result.Add(GetEdge(i));
            }
            return result;
        }

        /// <summary>
        /// <paramref name="i"/> 番目に追加された辺の容量、流量を
        /// <paramref name="newCap"/>, <paramref name="newFlow"/> に変更します。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 他の辺の容量、流量は変更しません。
        /// 辺 <paramref name="i"/> の流量、容量のみを
        /// <paramref name="newCap"/>, <paramref name="newFlow"/> へ変更します。
        /// </para>
        /// </remarks>
        public void ChangeEdge(int i, TValue newCap, TValue newFlow)
        {
            int m = _pos.Count;
            Debug.Assert(0 <= i && i < m);
            Debug.Assert(op.LessThanOrEqual(default, newFlow) && op.LessThanOrEqual(newFlow, newCap));
            var _e = _g[_pos[i].first][_pos[i].second];
            var _re = _g[_e.To][_e.Rev];
            _e.Cap = op.Subtract(newCap, newFlow);
            _re.Cap = newFlow;
        }

        /// <summary>
        /// 頂点 <paramref name="s"/> から <paramref name="t"/> へ流せる限り流し、
        /// 流せた量を返します。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 複数回呼ぶことも可能で、その時の挙動は
        /// 変更前と変更後の流量を f_e, f'_e として、以下の条件を満たすように変更します。
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>0 ≤ f'_e ≤ C_e</description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="s"/>, <paramref name="t"/> 以外の頂天 v について、
        /// g(v, f) = g(v, f')
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// (flowLimit を指定した場合) g(t, f') - g(t, f) ≤ flowLimit
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// g(t, f') - g(t, f) が委譲の条件を満たすうち最大。この g(t, f') - g(t, f) を返す。
        /// </description>
        /// </item>
        /// </list>
        /// <para>制約: 返値が <typeparamref name="TValue"/> に収まる。</para>
        /// 計算量: m を追加された辺数として、
        /// <list type="bullet">
        /// <item>
        /// <description>O(min(n^(2/3) m, m^(3/2))) (辺の容量が全部 1 の時)</description>
        /// </item>
        /// <item>
        /// <description>O(n^2 m)</description>
        /// </item>
        /// </list>
        /// </remarks>
        public TValue Flow(int s, int t)
        {
            return Flow(s, t, op.MaxValue);
        }

        /// <summary>
        /// 頂点 <paramref name="s"/> から <paramref name="t"/> へ
        /// 流量 <paramref name="flowLimit"/> に達するまで流せる限り流し、
        /// 流せた量を返します。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 複数回呼ぶことも可能で、その時の挙動は
        /// 変更前と変更後の流量を f_e, f'_e として、以下の条件を満たすように変更します。
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>0 ≤ f'_e ≤ C_e</description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="s"/>, <paramref name="t"/> 以外の頂天 v について、
        /// g(v, f) = g(v, f')
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// (<paramref name="flowLimit"/> を指定した場合) g(t, f') - g(t, f) ≤ <paramref name="flowLimit"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// g(t, f') - g(t, f) が委譲の条件を満たすうち最大。この g(t, f') - g(t, f) を返す。
        /// </description>
        /// </item>
        /// </list>
        /// <para>制約: 返値が <typeparamref name="TValue"/> に収まる。</para>
        /// 計算量: m を追加された辺数として、
        /// <list type="bullet">
        /// <item>
        /// <description>O(min(n^(2/3) m, m^(3/2))) (辺の容量が全部 1 の時)</description>
        /// </item>
        /// <item>
        /// <description>O(n^2 m)</description>
        /// </item>
        /// </list>
        /// </remarks>
        public TValue Flow(int s, int t, TValue flowLimit)
        {
            Debug.Assert(0 <= s && s < _n);
            Debug.Assert(0 <= t && t < _n);

            var level = new int[_n];
            var iter = new int[_n];
            var que = new Queue<int>();

            void Bfs()
            {
                for (int i = 0; i < _n; i++)
                {
                    level[i] = -1;
                }

                level[s] = 0;
                que.Clear();
                que.Enqueue(s);
                while (que.Count > 0)
                {
                    int v = que.Dequeue();
                    foreach (var e in _g[v])
                    {
                        if (op.Equals(e.Cap, default) || level[e.To] >= 0) continue;
                        level[e.To] = level[v] + 1;
                        if (e.To == t) return;
                        que.Enqueue(e.To);
                    }
                }
            }

            TValue Dfs(int v, TValue up)
            {
                if (v == s) return up;
                var res = default(TValue);
                int level_v = level[v];
                for (; iter[v] < _g[v].Count; iter[v]++)
                {
                    EdgeInternal e = _g[v][iter[v]];
                    if (level_v <= level[e.To] || op.Equals(_g[e.To][e.Rev].Cap, default)) continue;
                    var up1 = op.Subtract(up, res);
                    var up2 = _g[e.To][e.Rev].Cap;
                    var d = Dfs(e.To, op.LessThan(up1, up2) ? up1 : up2);
                    if (op.Compare(d, default) <= 0) continue;
                    _g[v][iter[v]].Cap = op.Add(_g[v][iter[v]].Cap, d);
                    _g[e.To][e.Rev].Cap = op.Subtract(_g[e.To][e.Rev].Cap, d);
                    res = op.Add(res, d);
                    if (res.Equals(up)) break;
                }

                return res;
            }

            TValue flow = default;
            while (op.LessThan(flow, flowLimit))
            {
                Bfs();
                if (level[t] == -1) break;
                for (int i = 0; i < _n; i++)
                {
                    iter[i] = 0;
                }
                while (op.LessThan(flow, flowLimit))
                {
                    var f = Dfs(t, op.Subtract(flowLimit, flow));
                    if (op.Equals(f, default)) break;
                    flow = op.Add(flow, f);
                }
            }
            return flow;
        }

        /// <summary>
        /// 長さ n の配列を返します。
        /// i 番目の要素には、頂点 <paramref name="s"/> から i へ残余グラフで到達可能なとき、
        /// またその時のみ true を返します。
        /// Flow(s, t) を flowLimit なしでちょうど一回呼んだ後に呼ぶと、
        /// 返り値はs, t 間の mincut に対応します。
        /// </summary>
        /// <remarks>
        /// <para>
        /// 各辺 e = (u, v, f_e, c_e) について、 f_e &lt; c_e ならば辺 (u, v) を張り、
        /// 0 &lt; f_e ならば辺 (u, v) を張ったと仮定したとき、
        /// 頂点 ss から到達可能な頂点の集合を返します。
        /// </para>
        /// 計算量: m を追加された辺数として、
        /// <list type="bullet">
        /// <item>
        /// <description>O(n + m)</description>
        /// </item>
        /// </list>
        /// </remarks>
        public bool[] MinCut(int s)
        {
            var visited = new bool[_n];
            var que = new Queue<int>();
            que.Enqueue(s);
            while (que.Count > 0)
            {
                int p = que.Dequeue();
                visited[p] = true;
                foreach (var e in _g[p])
                {
                    if (!op.Equals(e.Cap, default) && !visited[e.To])
                    {
                        visited[e.To] = true;
                        que.Enqueue(e.To);
                    }
                }
            }

            return visited;
        }

        /// <summary>
        /// フロー流すグラフの各辺に対応した情報を持ちます。
        /// </summary>
        public struct Edge
        {
            /// <summary>フローが流出する頂点。</summary>
            public int From { get; set; }
            /// <summary>フローが流入する頂点。</summary>
            public int To { get; set; }
            /// <summary>辺の容量。</summary>
            public TValue Cap { get; set; }
            /// <summary>辺の流量。</summary>
            public TValue Flow { get; set; }
            public Edge(int from, int to, TValue cap, TValue flow)
            {
                From = from;
                To = to;
                Cap = cap;
                Flow = flow;
            }
        };

        private class EdgeInternal
        {
            public int To { get; set; }
            public int Rev { get; set; }
            public TValue Cap { get; set; }
            public EdgeInternal(int to, int rev, TValue cap)
            {
                To = to;
                Rev = rev;
                Cap = cap;
            }
        };

        private readonly int _n;
        private readonly List<(int first, int second)> _pos;
        private readonly List<EdgeInternal>[] _g;
    }
}


namespace AtCoder
{
    public interface ICastOperator<TFrom, TTo>
        where TFrom : struct
        where TTo : struct
    {
        TTo Cast(TFrom y);
    }

    public struct SameTypeCastOperator<T> : ICastOperator<T, T>
        where T : struct
    {
        public T Cast(T y) => y;
    }

    public struct IntToLongCastOperator : ICastOperator<int, long>
    {
        public long Cast(int y) => y;
    }

    /// <summary>
    /// Minimum-cost flow problem を扱うライブラリ(int版)です。
    /// </summary>
    public class McfGraphInt
        : McfGraph<int, IntOperator, int, IntOperator, SameTypeCastOperator<int>>
    {
        public McfGraphInt(int n) : base(n) { }
    }

    /// <summary>
    /// Minimum-cost flow problem を扱うライブラリ(long版)です。
    /// </summary>
    public class McfGraphLong
       : McfGraph<long, LongOperator, long, LongOperator, SameTypeCastOperator<long>>
    {
        public McfGraphLong(int n) : base(n) { }
    }

    /// <summary>
    /// Minimum-cost flow problem を扱うライブラリです。
    /// </summary>
    /// <typeparam name="TCap">容量の型</typeparam>
    /// <typeparam name="TCapOp"><typeparamref name="TCap"/> に対応する演算を提供する型</typeparam>
    /// <typeparam name="TCost">コストの型</typeparam>
    /// <typeparam name="TCostOp"><typeparamref name="TCost"/> に対応する演算を提供する型</typeparam>
    /// <typeparam name="TCast">
    /// <typeparamref name="TCap"/> から <typeparamref name="TCost"/> への型変換を提供する型
    /// </typeparam>
    /// <remarks>
    /// <para>制約: <typeparamref name="TValue"/> は int, long。</para>
    /// </remarks>
    public class McfGraph<TCap, TCapOp, TCost, TCostOp, TCast>
        where TCap : struct
        where TCapOp : struct, INumOperator<TCap>
        where TCost : struct
        where TCostOp : struct, INumOperator<TCost>
        where TCast : ICastOperator<TCap, TCost>
    {
        static readonly TCapOp capOp = default;
        static readonly TCostOp costOp = default;
        static readonly TCast cast = default;

        /// <summary>
        /// <paramref name="n"/> 頂点 0 辺のグラフを作ります。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0 ≤ <paramref name="n"/> ≤ 10^8</para>
        /// <para>計算量: O(<paramref name="n"/>)</para>
        /// </remarks>
        public McfGraph(int n)
        {
            _n = n;
            _g = new List<EdgeInternal>[n];
            for (int i = 0; i < n; i++)
            {
                _g[i] = new List<EdgeInternal>();
            }
            _pos = new List<(int first, int second)>();
        }

        /// <summary>
        /// <paramref name="from"/> から <paramref name="to"/> へ
        /// 最大容量 <paramref name="cap"/>、コスト <paramref name="cost"/> の辺を追加し、
        /// 何番目に追加された辺かを返します。
        /// </summary>
        /// <remarks>
        /// 制約: 
        /// <list type="bullet">
        /// <item>
        /// <description>0 ≤ <paramref name="from"/>, <paramref name="to"/> &lt; n</description>
        /// </item>
        /// <item>
        /// <description>0 ≤ <paramref name="cap"/>, <paramref name="cost"/></description>
        /// </item>
        /// </list>
        /// <para>計算量: ならしO(1)</para>
        /// </remarks>
        public int AddEdge(int from, int to, TCap cap, TCost cost)
        {
            Debug.Assert(0 <= from && from < _n);
            Debug.Assert(0 <= to && to < _n);
            int m = _pos.Count;
            _pos.Add((from, _g[from].Count));
            _g[from].Add(new EdgeInternal(to, _g[to].Count, cap, cost));
            _g[to].Add(new EdgeInternal(from, _g[from].Count - 1, default, costOp.Minus(cost)));
            return m;
        }

        /// <summary>
        /// 今の内部の辺の状態を返します。
        /// </summary>
        /// <remarks>
        /// <para>AddEdge で <paramref name="i"/> 番目 (0-indexed) に追加された辺を返す。</para>
        /// <para>制約: m を追加された辺数として 0 ≤ i &lt; m</para>
        /// <para>計算量: O(1)</para>
        /// </remarks>
        public Edge GetEdge(int i)
        {
            int m = _pos.Count;
            Debug.Assert(0 <= i && i < m);
            var _e = _g[_pos[i].first][_pos[i].second];
            var _re = _g[_e.To][_e.Rev];
            return new Edge(_pos[i].first, _e.To, capOp.Add(_e.Cap, _re.Cap), _re.Cap, _e.Cost);
        }

        /// <summary>
        /// 今の内部の辺の状態を返します。
        /// </summary>
        /// <remarks>
        /// <para>辺の順番はadd_edgeで追加された順番と同一。</para>
        /// <para>計算量: m を追加された辺数として O(m)</para>
        /// </remarks>
        public List<Edge> Edges()
        {
            int m = _pos.Count;
            var result = new List<Edge>();
            for (int i = 0; i < m; i++)
            {
                result.Add(GetEdge(i));
            }
            return result;
        }

        /// <summary>
        /// 頂点 <paramref name="s"/> から <paramref name="t"/> へ流せる限り流し、
        /// その流量とコストを返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: Slope関数と同じ</para>
        /// <para>計算量: Slope関数と同じ</para>
        /// </remarks>
        public (TCap cap, TCost cost) Flow(int s, int t)
        {
            return Flow(s, t, capOp.MaxValue);
        }

        /// <summary>
        /// 頂点 <paramref name="s"/> から <paramref name="t"/> へ
        /// 流量 <paramref name="flowLimit"/> に達するまで流せる限り流し、
        /// その流量とコストを返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: Slope関数と同じ</para>
        /// <para>計算量: Slope関数と同じ</para>
        /// </remarks>
        public (TCap cap, TCost cost) Flow(int s, int t, TCap flowLimit)
        {
            return Slope(s, t, flowLimit).Last();
        }

        /// <summary>
        /// 返り値に流量とコストの関係の折れ線が入ります。
        /// 全ての x について、流量 x の時の最小コストを g(x) とすると、
        /// (x, g(x)) は返り値を折れ線として見たものに含まれます。
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>返り値の最初の要素は (0, 0)。</description>
        /// </item>
        /// <item>
        /// <description>返り値の .first、.second は共に狭義単調増加。</description>
        /// </item>
        /// <item>
        /// <description>3点が同一線上にあることは無い。</description>
        /// </item>
        /// <item>
        /// <description>返り値の最後の要素は最大流量 x として (x, g(x))。</description>
        /// </item>
        /// </list>
        /// 制約: 辺のコストの最大を x として
        /// <list type="bullet">
        /// <item>
        /// <description><paramref name="s"/> ≠ <paramref name="t"/></description>
        /// </item>
        /// <item>
        /// <description>Flow や Slope 関数を合わせて複数回呼んだときの挙動は未定義。</description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="s"/> から <paramref name="t"/> へ流したフローの
        /// 流量が cap に収まる。
        /// </description>
        /// </item>
        /// <item>
        /// <description>流したコストの総和が cost に収まる。</description>
        /// </item>
        /// <item>
        /// <description>(Cost: int) 0 ≤ nx ≤ 2 * 10^9 + 1000 </description>
        /// </item>
        /// <item>
        /// <description>(Cost: long) 0 ≤ nx ≤ 8 * 10^18 + 1000 </description>
        /// </item>
        /// </list>
        /// 計算量: F を流量、m を追加した辺の本数として 
        /// O(F(n + m) log n)
        /// </remarks>
        public List<(TCap cap, TCost cost)> Slope(int s, int t)
        {
            return Slope(s, t, capOp.MaxValue);
        }

        /// <summary>
        /// 返り値に流量とコストの関係の折れ線が入ります。
        /// 全ての x について、流量 x の時の最小コストを g(x) とすると、
        /// (x, g(x)) は返り値を折れ線として見たものに含まれます。
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>返り値の最初の要素は (0, 0)。</description>
        /// </item>
        /// <item>
        /// <description>返り値の .first、.second は共に狭義単調増加。</description>
        /// </item>
        /// <item>
        /// <description>3点が同一線上にあることは無い。</description>
        /// </item>
        /// <item>
        /// <description>
        /// 返り値の最後の要素は
        /// y = min(x, <paramref name="flowLimit"/>) として (y, g(y))。</description>
        /// </item>
        /// </list>
        /// 制約: 辺のコストの最大を x として
        /// <list type="bullet">
        /// <item>
        /// <description><paramref name="s"/> ≠ <paramref name="t"/></description>
        /// </item>
        /// <item>
        /// <description>Flow や Slope 関数を合わせて複数回呼んだときの挙動は未定義。</description>
        /// </item>
        /// <item>
        /// <description>
        /// <paramref name="s"/> から <paramref name="t"/> へ流したフローの
        /// 流量が cap に収まる。
        /// </description>
        /// </item>
        /// <item>
        /// <description>流したコストの総和が cost に収まる。</description>
        /// </item>
        /// <item>
        /// <description>(Cost: int) 0 ≤ nx ≤ 2 * 10^9 + 1000 </description>
        /// </item>
        /// <item>
        /// <description>(Cost: long) 0 ≤ nx ≤ 8 * 10^18 + 1000 </description>
        /// </item>
        /// </list>
        /// 計算量: F を流量、m を追加した辺の本数として 
        /// O(F(n + m) log n)
        /// </remarks>
        public List<(TCap cap, TCost cost)> Slope(int s, int t, TCap flowLimit)
        {
            Debug.Assert(0 <= s && s < _n);
            Debug.Assert(0 <= t && t < _n);
            Debug.Assert(s != t);
            // variants (C = maxcost):
            // -(n-1)C <= dual[s] <= dual[i] <= dual[t] = 0
            // reduced cost (= e.cost + dual[e.from] - dual[e.to]) >= 0 for all edge
            var dual = new TCost[_n];
            var dist = new TCost[_n];
            var pv = new int[_n];
            var pe = new int[_n];
            var vis = new bool[_n];

            bool DualRef()
            {
                dist.AsSpan().Fill(costOp.MaxValue);
                pv.AsSpan().Fill(-1);
                pe.AsSpan().Fill(-1);
                vis.AsSpan().Fill(false);

                var que = new PriorityQueueForMcf();
                dist[s] = default;
                que.Enqueue(default, s);
                while (que.Count > 0)
                {
                    int v = que.Dequeue().to;
                    if (vis[v]) continue;
                    vis[v] = true;
                    if (v == t) break;
                    // dist[v] = shortest(s, v) + dual[s] - dual[v]
                    // dist[v] >= 0 (all reduced cost are positive)
                    // dist[v] <= (n-1)C
                    for (int i = 0; i < _g[v].Count; i++)
                    {
                        var e = _g[v][i];
                        if (vis[e.To] || capOp.Equals(e.Cap, default)) continue;
                        // |-dual[e.to] + dual[v]| <= (n-1)C
                        // cost <= C - -(n-1)C + 0 = nC
                        TCost cost = costOp.Add(costOp.Subtract(e.Cost, dual[e.To]), dual[v]);
                        if (costOp.GreaterThan(costOp.Subtract(dist[e.To], dist[v]), cost))
                        {
                            dist[e.To] = costOp.Add(dist[v], cost);
                            pv[e.To] = v;
                            pe[e.To] = i;
                            que.Enqueue(dist[e.To], e.To);
                        }
                    }
                }

                if (!vis[t])
                {
                    return false;
                }

                for (int v = 0; v < _n; v++)
                {
                    if (!vis[v]) continue;
                    // dual[v] = dual[v] - dist[t] + dist[v]
                    //         = dual[v] - (shortest(s, t) + dual[s] - dual[t]) + (shortest(s, v) + dual[s] - dual[v])
                    //         = - shortest(s, t) + dual[t] + shortest(s, v)
                    //         = shortest(s, v) - shortest(s, t) >= 0 - (n-1)C
                    dual[v] = costOp.Subtract(dual[v], costOp.Subtract(dist[t], dist[v]));
                }

                return true;
            }

            TCap flow = default;
            TCost cost = default;
            TCost prev_cost = costOp.Decrement(default); //-1
            var result = new List<(TCap cap, TCost cost)>();
            result.Add((flow, cost));
            while (capOp.LessThan(flow, flowLimit))
            {
                if (!DualRef()) break;
                TCap c = capOp.Subtract(flowLimit, flow);
                for (int v = t; v != s; v = pv[v])
                {
                    if (capOp.LessThan(_g[pv[v]][pe[v]].Cap, c))
                    {
                        c = _g[pv[v]][pe[v]].Cap;
                    }
                }
                for (int v = t; v != s; v = pv[v])
                {
                    _g[pv[v]][pe[v]].Cap = capOp.Subtract(_g[pv[v]][pe[v]].Cap, c);
                    _g[v][_g[pv[v]][pe[v]].Rev].Cap = capOp.Add(_g[v][_g[pv[v]][pe[v]].Rev].Cap, c);
                }
                TCost d = costOp.Minus(dual[s]);
                flow = capOp.Add(flow, c);
                cost = costOp.Add(cost, costOp.Multiply(cast.Cast(c), d));
                if (costOp.Equals(prev_cost, d))
                {
                    result.RemoveAt(result.Count - 1);
                }
                result.Add((flow, cost));
                prev_cost = cost;
            }
            return result;
        }

        /// <summary>
        /// フローを流すグラフの各辺に対応した情報を持ちます。
        /// </summary>
        public struct Edge
        {
            /// <summary>フローが流出する頂点。</summary>
            public int From { get; set; }
            /// <summary>フローが流入する頂点。</summary>
            public int To { get; set; }
            /// <summary>辺の容量。</summary>
            public TCap Cap { get; set; }
            /// <summary>辺の流量。</summary>
            public TCap Flow { get; set; }
            /// <summary>辺の費用</summary>
            public TCost Cost { get; set; }
            public Edge(int from, int to, TCap cap, TCap flow, TCost cost)
            {
                From = from;
                To = to;
                Cap = cap;
                Flow = flow;
                Cost = cost;
            }
        };

        private class EdgeInternal
        {
            public int To { get; set; }
            public int Rev { get; set; }
            public TCap Cap { get; set; }
            public TCost Cost { get; set; }
            public EdgeInternal(int to, int rev, TCap cap, TCost cost)
            {
                To = to;
                Rev = rev;
                Cap = cap;
                Cost = cost;
            }
        };

        private readonly int _n;
        private readonly List<(int first, int second)> _pos;
        private readonly List<EdgeInternal>[] _g;

        private class PriorityQueueForMcf
        {
            private (TCost cost, int to)[] _heap;

            public int Count { get; private set; } = 0;
            public PriorityQueueForMcf()
            {
                _heap = new (TCost cost, int to)[1024];
            }

            public void Enqueue(TCost cost, int to)
            {
                var pair = (cost, to);
                if (_heap.Length == Count)
                {
                    var newHeap = new (TCost cost, int to)[_heap.Length * 2];
                    _heap.CopyTo(newHeap, 0);
                    _heap = newHeap;
                }

                _heap[Count] = pair;
                ++Count;

                int c = Count - 1;
                while (c > 0)
                {
                    int p = (c - 1) >> 1;
                    if (Compare(_heap[p].cost, cost) < 0)
                    {
                        _heap[c] = _heap[p];
                        c = p;
                    }
                    else
                    {
                        break;
                    }
                }

                _heap[c] = pair;
            }

            public (TCost cost, int to) Dequeue()
            {
                (TCost cost, int to) ret = _heap[0];
                int n = Count - 1;

                var item = _heap[n];
                int p = 0;
                int c = (p << 1) + 1;
                while (c < n)
                {
                    if (c != n - 1 && Compare(_heap[c + 1].cost, _heap[c].cost) > 0)
                    {
                        ++c;
                    }

                    if (Compare(item.cost, _heap[c].cost) < 0)
                    {
                        _heap[p] = _heap[c];
                        p = c;
                        c = (p << 1) + 1;
                    }
                    else
                    {
                        break;
                    }
                }

                _heap[p] = item;
                Count--;

                return ret;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private int Compare(TCost x, TCost y) => costOp.Compare(y, x);
        }
    }
}


namespace AtCoder
{
    /// <summary>
    /// 有向グラフを強連結成分分解します。
    /// </summary>
    [DebuggerDisplay("Vertices = {_internal._n}, Edges = {_internal.edges.Count}")]
    public class SCCGraph
    {
        Internal.SCCGraph _internal;

        /// <summary>
        /// <see cref="SCCGraph"/> クラスの新しいインスタンスを、<paramref name="n"/> 頂点 0 辺の有向グラフとして初期化します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/>≤10^8</para>
        /// <para>計算量: O(<paramref name="n"/>)</para>
        /// </remarks>
        public SCCGraph(int n)
        {
            Debug.Assert(unchecked((uint)n <= 100_000_000));
            _internal = new Internal.SCCGraph(n);
        }

        /// <summary>
        /// 頂点 <paramref name="from"/> から頂点 <paramref name="to"/> へ有向辺を追加します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="from"/>, <paramref name="to"/>&lt;n</para>
        /// <para>計算量: ならしO(1)</para>
        /// </remarks>
        public void AddEdge(int from, int to)
        {
            int n = _internal.VerticesNumbers;
            Debug.Assert(unchecked((uint)from < n));
            Debug.Assert(unchecked((uint)to < n));
            _internal.AddEdge(from, to);
        }

        /// <summary>
        /// 強連結成分分解の結果である「頂点のリスト」のリストを取得します。
        /// </summary>
        /// <remarks>
        /// <para>- 全ての頂点がちょうど1つずつ、どれかのリストに含まれます。</para>
        /// <para>- 内側のリストと強連結成分が一対一に対応します。リスト内での頂点の順序は未定義です。</para>
        /// <para>- リストはトポロジカルソートされています。異なる強連結成分の頂点 u, v について、u から v に到達できる時、u の属するリストは v の属するリストよりも前です。</para>
        /// <para>計算量: 追加された辺の本数を m として O(n+m)</para>
        /// </remarks>
        public List<List<int>> SCC() => _internal.SCC();
    }
}


namespace AtCoder
{
    /// <summary>
    /// モノイドを定義するインターフェイスです。
    /// </summary>
    /// <typeparam name="T">操作を行う型。</typeparam>
    public interface IMonoidOperator<T>
    {
        /// <summary>
        /// Operate(x, <paramref name="Identity"/>) = xを満たす単位元。
        /// </summary>
        T Identity { get; }
        /// <summary>
        /// 結合律 Operate(Operate(a, b), c) = Operate(a, Operate(b, c)) を満たす写像。
        /// </summary>
        T Operate(T x, T y);
    }

    /// <summary>
    /// 長さ N の配列に対し、
    /// <list type="bullet">
    /// <item>
    /// <description>要素の 1 点変更</description>
    /// </item>
    /// <item>
    /// <description>区間の要素の総積の取得</description>
    /// </item>
    /// </list>
    /// <para>を O(log N) で求めることが出来るデータ構造です。</para>
    /// </summary>
    [DebuggerTypeProxy(typeof(Segtree<,>.DebugView))]
    public class Segtree<TValue, TOp> where TOp : struct, IMonoidOperator<TValue>
    {
        private static readonly TOp op = default;

        /// <summary>
        /// 数列 a の長さ n を返します。
        /// </summary>
        public int Length { get; }

        private readonly int log;
        private readonly int size;
        private readonly TValue[] d;


        /// <summary>
        /// 長さ <paramref name="n"/> の数列 a　を持つ <see cref="Segtree{TValue, TOp}"/> クラスの新しいインスタンスを作ります。初期値は <see cref="TOp.Identity"/> です。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/>≤10^8</para>
        /// <para>計算量: O(<paramref name="n"/>)</para>
        /// </remarks>
        /// <param name="n">配列の長さ</param>
        public Segtree(int n)
        {
            AssertMonoid(op.Identity);
            Length = n;
            log = InternalMath.CeilPow2(n);
            size = 1 << log;
            d = new TValue[2 * size];
            Array.Fill(d, op.Identity);
        }

        /// <summary>
        /// 長さ n=<paramref name="v"/>.Length の数列 a　を持つ <see cref="Segtree{TValue, TOp}"/> クラスの新しいインスタンスを作ります。初期値は <paramref name="v"/> です。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/>≤10^8</para>
        /// <para>計算量: O(<paramref name="n"/>)</para>
        /// </remarks>
        /// <param name="n">配列の長さ</param>
        public Segtree(TValue[] v) : this(v.Length)
        {
            for (int i = 0; i < v.Length; i++) d[size + i] = v[i];
            for (int i = size - 1; i >= 1; i--)
            {
                Update(i);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Update(int k) => d[k] = op.Operate(d[2 * k], d[2 * k + 1]);

        /// <summary>
        /// a[<paramref name="p"/>] を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="p"/>&lt;n</para>
        /// <para>計算量(set): O(log n)</para>
        /// <para>計算量(get): O(1)</para>
        /// </remarks>
        /// <returns></returns>
        public TValue this[int p]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                AssertMonoid(value);
                Debug.Assert((uint)p < Length);
                p += size;
                d[p] = value;
                for (int i = 1; i <= log; i++) Update(p >> i);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Debug.Assert((uint)p < Length);
                AssertMonoid(d[p + size]);
                return d[p + size];
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
            TValue sml = op.Identity, smr = op.Identity;
            l += size;
            r += size;

            while (l < r)
            {
                if ((l & 1) != 0) sml = op.Operate(sml, d[l++]);
                if ((r & 1) != 0) smr = op.Operate(d[--r], smr);
                l >>= 1;
                r >>= 1;
            }
            AssertMonoid(op.Operate(sml, smr));
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
        /// 以下の条件を両方満たす r を(いずれか一つ)返します。
        /// <list type="bullet">
        /// <item>
        /// <description>r = <paramref name="l"/> もしくは <paramref name="f"/>(op(a[<paramref name="l"/>], a[<paramref name="l"/> + 1], ..., a[r - 1])) = true</description>
        /// </item>
        /// <item>
        /// <description>r = n もしくは <paramref name="f"/>(op(a[<paramref name="l"/>], a[<paramref name="l"/> + 1], ..., a[r])) = false</description>
        /// </item>
        /// </list>
        /// <para><paramref name="f"/> が単調だとすれば、<paramref name="f"/>(op(a[<paramref name="l"/>], a[<paramref name="l"/> + 1], ..., a[r - 1])) = true となる最大の r、と解釈することが可能です。</para>
        /// </summary>
        /// <remarks>
        /// 制約
        /// <list type="bullet">
        /// <item>
        /// <description><paramref name="f"/> を同じ引数で呼んだ時、返り値は等しい(=副作用はない)。</description>
        /// </item>
        /// <item>
        /// <description><paramref name="f"/>(<see cref="TOp.Identity"/>) = true</description>
        /// </item>
        /// <item>
        /// <description>0≤<paramref name="l"/>≤n</description>
        /// </item>
        /// </list>
        /// <para>計算量: O(log n)</para>
        /// </remarks>
        public int MaxRight(int l, Predicate<TValue> f)
        {
            Debug.Assert((uint)l <= Length);
            Debug.Assert(f(op.Identity));
            if (l == Length) return Length;
            l += size;
            var sm = op.Identity;
            do
            {
                while (l % 2 == 0) l >>= 1;
                if (!f(op.Operate(sm, d[l])))
                {
                    while (l < size)
                    {
                        l = (2 * l);
                        if (f(op.Operate(sm, d[l])))
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
        /// <description>l = <paramref name="r"/> もしくは <paramref name="f"/>(op(a[l], a[l + 1], ..., a[<paramref name="r"/> - 1])) = true</description>
        /// </item>
        /// <item>
        /// <description>l = 0 もしくは <paramref name="f"/>(op(a[l - 1], a[l], ..., a[<paramref name="r"/> - 1])) = false</description>
        /// </item>
        /// </list>
        /// <para><paramref name="f"/> が単調だとすれば、<paramref name="f"/>(op(a[l], a[l + 1], ..., a[<paramref name="r"/> - 1])) = true となる最小の l、と解釈することが可能です。</para>
        /// </summary>
        /// <remarks>
        /// 制約
        /// <list type="bullet">
        /// <item>
        /// <description><paramref name="f"/> を同じ引数で呼んだ時、返り値は等しい(=副作用はない)。</description>
        /// </item>
        /// <item>
        /// <description><paramref name="f"/>(<see cref="TOp.Identity"/>) = true</description>
        /// </item>
        /// <item>
        /// <description>0≤<paramref name="r"/>≤n</description>
        /// </item>
        /// </list>
        /// <para>計算量: O(log n)</para>
        /// </remarks>
        public int MinLeft(int r, Predicate<TValue> f)
        {
            Debug.Assert((uint)r <= Length);
            Debug.Assert(f(op.Identity));
            if (r == 0) return 0;
            r += size;
            var sm = op.Identity;
            do
            {
                r--;
                while (r > 1 && (r % 2) != 0) r >>= 1;
                if (!f(op.Operate(d[r], sm)))
                {
                    while (r < size)
                    {
                        r = (2 * r + 1);
                        if (f(op.Operate(d[r], sm)))
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


        [DebuggerDisplay("{" + nameof(value) + "}", Name = "{" + nameof(key) + ",nq}")]
        private struct DebugItem
        {
            public DebugItem(int l, int r, TValue value)
            {
                if (r - l == 1)
                    key = $"[{l}]";
                else
                    key = $"[{l}-{r})";
                this.value = value;
            }
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly string key;
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly TValue value;
        }
        private class DebugView
        {
            private readonly Segtree<TValue, TOp> segtree;
            public DebugView(Segtree<TValue, TOp> segtree)
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
                                items.Add(new DebugItem(l, r, segtree.d[i + len]));
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
    }
}


namespace AtCoder
{
    /// <summary>
    /// 2-SATを解きます。 
    /// <para>
    /// 変数 x_0, x_1,…, x_{n-1} に関して (x_i=f)∨(x_j=g) というクローズを足し、これをすべて満たす変数の割当があるかを解きます。
    /// </para>
    /// </summary>
    [DebuggerDisplay("Count = {_n}")]
    public class TwoSat
    {
        readonly int _n;
        readonly private bool[] _answer;
        readonly private SCCGraph scc;

        /// <summary>
        /// <see cref="TwoSat"/> クラスの新しいインスタンスを、<paramref name="n"/> 変数の 2-SAT として初期化します。
        /// </summary>
        /// <remarks>
        /// <para>制約 : 0≤<paramref name="n"/>≤10^8</para>
        /// </remarks>
        public TwoSat(int n)
        {
            Debug.Assert(unchecked((uint)n <= 100_000_000));
            _n = n;
            _answer = new bool[n];
            scc = new SCCGraph(2 * n);
        }

        /// <summary>
        /// (x_<paramref name="i"/>=<paramref name="f"/>)∨(x_<paramref name="j"/>=<paramref name="g"/>) というクローズを追加します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="i"/>&lt;n, 0≤<paramref name="j"/>&lt;n</para>
        /// <para>計算量: ならし O(1)</para>
        /// </remarks>
        public void AddClause(int i, bool f, int j, bool g)
        {
            Debug.Assert(unchecked((uint)i < _n));
            Debug.Assert(unchecked((uint)j < _n));
            scc.AddEdge(2 * i + (f ? 0 : 1), 2 * j + (g ? 1 : 0));
            scc.AddEdge(2 * j + (g ? 0 : 1), 2 * i + (f ? 1 : 0));
        }

        /// <summary>
        /// 条件を満たす割当が存在するかどうかを判定します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 複数回呼ぶことも可能。</para>
        /// <para>計算量: 足した制約の個数を m として O(n+m)</para>
        /// </remarks>
        /// <returns>割当が存在するならば <c>true</c>、そうでないなら <c>false</c>。</returns>
        public bool Satisfiable()
        {
            var sccs = scc.SCC();
            var id = new int[2 * _n];

            // 強連結成分のリストを id として展開。
            for (int i = 0; i < sccs.Count; i++)
            {
                foreach (var v in sccs[i])
                {
                    id[v] = i;
                }
            }

            for (int i = 0; i < _n; i++)
            {
                if (id[2 * i] == id[2 * i + 1])
                {
                    return false;
                }
                else
                {
                    _answer[i] = id[2 * i] < id[2 * i + 1];
                }
            }

            return true;
        }

        /// <summary>
        /// 最後に実行した <see cref="Satisfiable"/> の、クローズを満たす割当を返します。実行前や、割当が存在しなかった場合は中身が未定義の長さ n の配列を返します。
        /// </summary>
        /// <remarks>
        /// <para>計算量: O(n)</para>
        /// </remarks>
        /// <returns>最後に呼んだ <see cref="Satisfiable"/> の、クローズを満たす割当の配列。</returns>
        public bool[] Answer() => _answer;
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
        /// Unary minus operator -
        /// </summary>
        /// <returns>-<paramref name="x"/></returns>
        T Minus(T x);
        /// <summary>
        /// Increment operator ++
        /// </summary>
        /// <returns>++<paramref name="x"/></returns>
        T Increment(T x);
        /// <summary>
        /// Decrement operator --
        /// </summary>
        /// <returns>--<paramref name="x"/></returns>
        T Decrement(T x);
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
        public int Minus(int x) => -x;
        public int Increment(int x) => ++x;
        public int Decrement(int x) => --x;
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
        public long Minus(long x) => -x;
        public long Increment(long x) => ++x;
        public long Decrement(long x) => --x;
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
        public uint Minus(uint x) => throw new InvalidOperationException("Uint type cannot be negative.");
        public uint Increment(uint x) => ++x;
        public uint Decrement(uint x) => --x;
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
        public ulong Minus(ulong x) => throw new InvalidOperationException("Ulong type cannot be negative.");
        public ulong Increment(ulong x) => ++x;
        public ulong Decrement(ulong x) => --x;
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
        public double Minus(double x) => -x;
        public double Increment(double x) => ++x;
        public double Decrement(double x) => --x;
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
            return BitOperations.TrailingZeroCount(n);
        }
    }
}


namespace AtCoder.Internal
{
    /// <summary>
    /// 有向グラフを強連結成分分解します。
    /// </summary>
    [DebuggerDisplay("Vertices = {_n}, Edges = {edges.Count}")]
    public class SCCGraph
    {
        private readonly int _n;
        private readonly List<Edge> edges;

        public int VerticesNumbers => _n;

        /// <summary>
        /// <see cref="SCCGraph"/> クラスの新しいインスタンスを、<paramref name="n"/> 頂点 0 辺の有向グラフとして初期化します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/>≤10^8</para>
        /// <para>計算量: O(<paramref name="n"/>)</para>
        /// </remarks>
        public SCCGraph(int n)
        {
            _n = n;
            edges = new List<Edge>();
        }

        /// <summary>
        /// 頂点 <paramref name="from"/> から頂点 <paramref name="to"/> へ有向辺を追加します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="from"/>, <paramref name="to"/>&lt;n</para>
        /// <para>計算量: ならしO(1)</para>
        /// </remarks>
        public void AddEdge(int from, int to) => edges.Add(new Edge(from, to));

        /// <summary>
        /// 強連結成分ごとに ID を割り振り、各頂点の所属する強連結成分の ID が記録された配列を取得します。
        /// </summary>
        /// <remarks>
        /// <para>強連結成分の ID はトポロジカルソートされています。異なる強連結成分の頂点 u, v について、u から v に到達できる時、u の ID は v の ID よりも小さくなります。</para>
        /// <para>計算量: 追加された辺の本数を m として O(n+m)</para>
        /// </remarks>
        public (int groupNum, int[] ids) SCCIDs()
        {
            // R. Tarjan のアルゴリズム
            var g = new CSR(_n, edges);
            int nowOrd = 0;
            int groupNum = 0;
            var visited = new Stack<int>(_n);
            var low = new int[_n];
            var ord = Enumerable.Repeat(-1, _n).ToArray();
            var ids = new int[_n];

            for (int i = 0; i < ord.Length; i++)
            {
                if (ord[i] == -1)
                {
                    DFS(i);
                }
            }

            foreach (ref var x in ids.AsSpan())
            {
                // トポロジカル順序にするには逆順にする必要がある。
                x = groupNum - 1 - x;
            }

            return (groupNum, ids);

            void DFS(int v)
            {
                low[v] = nowOrd;
                ord[v] = nowOrd++;
                visited.Push(v);

                // 頂点 v から伸びる有向辺を探索する。
                for (int i = g.Start[v]; i < g.Start[v + 1]; i++)
                {
                    int to = g.EList[i];
                    if (ord[to] == -1)
                    {
                        DFS(to);
                        low[v] = System.Math.Min(low[v], low[to]);
                    }
                    else
                    {
                        low[v] = System.Math.Min(low[v], ord[to]);
                    }
                }

                // v がSCCの根である場合、強連結成分に ID を割り振る。
                if (low[v] == ord[v])
                {
                    while (true)
                    {
                        int u = visited.Pop();
                        ord[u] = _n;
                        ids[u] = groupNum;

                        if (u == v)
                        {
                            break;
                        }
                    }

                    groupNum++;
                }
            }
        }

        /// <summary>
        /// 強連結成分分解の結果である「頂点のリスト」のリストを取得します。
        /// </summary>
        /// <remarks>
        /// <para>- 全ての頂点がちょうど1つずつ、どれかのリストに含まれます。</para>
        /// <para>- 内側のリストと強連結成分が一対一に対応します。リスト内での頂点の順序は未定義です。</para>
        /// <para>- リストはトポロジカルソートされています。異なる強連結成分の頂点 u, v について、u から v に到達できる時、u の属するリストは v の属するリストよりも前です。</para>
        /// <para>計算量: 追加された辺の本数を m として O(n+m)</para>
        /// </remarks>
        public List<List<int>> SCC()
        {
            var (groupNum, ids) = SCCIDs();
            var counts = new int[groupNum];

            foreach (var x in ids)
            {
                counts[x]++;
            }

            var groups = new List<List<int>>(groupNum);

            for (int i = 0; i < groupNum; i++)
            {
                groups.Add(new List<int>(counts[i]));
            }

            for (int i = 0; i < ids.Length; i++)
            {
                groups[ids[i]].Add(i);
            }

            return groups;
        }

        /// <summary>
        /// 有向グラフの辺集合を表します。
        /// </summary>
        /// <example>
        /// <code>
        /// for (int i = graph.Starts[v]; i < graph.Starts[v + 1]; i++)
        /// {
        ///     int to = graph.Edges[i];
        /// }
        /// </code>
        /// </example>
        private class CSR
        {
            /// <summary>
            /// 各頂点から伸びる有向辺数の累積和を取得します。
            /// </summary>
            public int[] Start { get; }

            /// <summary>
            /// 有向辺の終点の配列を取得します。
            /// </summary>
            public int[] EList { get; }

            public CSR(int n, List<Edge> edges)
            {
                // 本家 C++ 版 ACL を参考に実装。通常の隣接リストと比較して高速か否かは未検証。
                Start = new int[n + 1];
                EList = new int[edges.Count];

                foreach (var e in edges)
                {
                    Start[e.From + 1]++;
                }

                for (int i = 1; i <= n; i++)
                {
                    Start[i] += Start[i - 1];
                }

                var counter = new int[Start.Length];
                Start.CopyTo(counter, 0);
                foreach (var e in edges)
                {
                    EList[counter[e.From]++] = e.To;
                }
            }
        }

        [DebuggerDisplay("From = {From}, To = {To}")]
        private readonly struct Edge
        {
            public int From { get; }
            public int To { get; }

            public Edge(int from, int to)
            {
                From = from;
                To = to;
            }
        }
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


namespace AtCoder
{
    public static partial class Math
    {
        /// <summary>
        /// 同じ長さ n の配列 <paramref name="r"/>, <paramref name="m"/> について、x≡<paramref name="r"/>[i] (mod <paramref name="m"/>[i]),∀i∈{0,1,⋯,n−1} を解きます。
        /// </summary>
        /// <remarks>
        /// <para>制約: |<paramref name="r"/>|=|<paramref name="m"/>|, 1≤<paramref name="m"/>[i], lcm(m[i]) が ll に収まる</para>
        /// <para>計算量: O(nloglcm(<paramref name="m"/>))</para>
        /// </remarks>
        /// <returns>答えは(存在するならば) y,z(0≤y&lt;z=lcm(<paramref name="m"/>[i])) を用いて x≡y(mod z) の形で書ける。答えがない場合は(0,0)、n=0 の時は(0,1)、それ以外の場合は(y,z)。</returns>
        public static (long, long) CRT(long[] r, long[] m)
        {
            Debug.Assert(r.Length == m.Length);

            long r0 = 0, m0 = 1;
            for (int i = 0; i < m.Length; i++)
            {
                Debug.Assert(1 <= m[i]);
                long r1 = InternalMath.SafeMod(r[i], m[i]);
                long m1 = m[i];
                if (m0 < m1)
                {
                    (r0, r1) = (r1, r0);
                    (m0, m1) = (m1, m0);
                }
                if (m0 % m1 == 0)
                {
                    if (r0 % m1 != r1) return (0, 0);
                    continue;
                }
                var (g, im) = InternalMath.InvGCD(m0, m1);

                long u1 = (m1 / g);
                if ((r1 - r0) % g != 0) return (0, 0);

                long x = (r1 - r0) / g % u1 * im % u1;
                r0 += x * m0;
                m0 *= u1;
                if (r0 < 0) r0 += m0;
            }
            return (r0, m0);
        }
    }
}


namespace AtCoder
{
    public static partial class Math
    {
        /// <summary>
        /// sum_{i=0}^{<paramref name="n"/>-1} floor(<paramref name="a"/>*i+<paramref name="b"/>/<paramref name="m"/>) を返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤<paramref name="n"/>, <paramref name="m"/>≤10^9, 0≤<paramref name="a"/>, <paramref name="b"/>&lt;<paramref name="m"/></para>
        /// <para>計算量: O(log(n+m+a+b))</para>
        /// </remarks>
        /// <returns></returns>
        public static long FloorSum(long n, long m, long a, long b)
        {
            long ans = 0;
            while (true)
            {
                if (a >= m)
                {
                    ans += (n - 1) * n * (a / m) / 2;
                    a %= m;
                }
                if (b >= m)
                {
                    ans += n * (b / m);
                    b %= m;
                }

                long yMax = (a * n + b) / m;
                long xMax = yMax * m - b;
                if (yMax == 0) return ans;
                ans += (n - (xMax + a - 1) / a) * yMax;
                (n, m, a, b) = (yMax, a, m, (a - xMax % a) % a);
            }
        }
    }
}


namespace AtCoder
{
    public static partial class Math
    {
        /// <summary>
        /// <paramref name="x"/>y≡1(mod <paramref name="m"/>) なる y のうち、0≤y&lt;<paramref name="m"/> を満たすものを返します。
        /// </summary>
        /// <remarks>
        /// <para>制約: gcd(<paramref name="x"/>,<paramref name="m"/>)=1, 1≤<paramref name="m"/></para>
        /// <para>計算量: O(log<paramref name="m"/>)</para>
        /// </remarks>
        public static long InvMod(long x, int m)
        {
            Debug.Assert(1 <= m);
            var (g, res) = InternalMath.InvGCD(x, m);
            Debug.Assert(g == 1);
            return res;
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

        public static StaticModInt<T> operator +(StaticModInt<T> lhs, StaticModInt<T> rhs)
        {
            var v = lhs._v + rhs._v;
            if (v >= default(T).Mod)
            {
                v -= default(T).Mod;
            }
            return new StaticModInt<T>(v);
        }

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


namespace AtCoder
{
    public static partial class String
    {
        /// <summary>
        /// 列 <paramref name="s"/> の LCP Array として、長さ |<paramref name="s"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>LCP Array とは、i 番目の要素が s[sa[i]..|<paramref name="s"/>|), s[sa[i+1]..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さのもの。</para>
        /// <para>制約: 0≤|<paramref name="s"/>|≤10^8, <paramref name="sa"/> は <paramref name="s"/> の Suffix Array</para>
        /// <para>計算量: O(|<paramref name="s"/>|)</para>
        /// </remarks>
        public static int[] LCPArray<T>(ReadOnlySpan<T> s, int[] sa)
        {
            Debug.Assert(1 <= s.Length);
            int[] rnk = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                rnk[sa[i]] = i;
            }
            int[] lcp = new int[s.Length - 1];
            int h = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (h > 0) h--;
                if (rnk[i] == 0) continue;
                int j = sa[rnk[i] - 1];
                for (; j + h < s.Length && i + h < s.Length; h++)
                {
                    if (!EqualityComparer<T>.Default.Equals(s[j + h], s[i + h])) break;
                }
                lcp[rnk[i] - 1] = h;
            }
            return lcp;
        }

        /// <summary>
        /// 文字列 <paramref name="s"/> の LCP Array として、長さ |<paramref name="s"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>LCP Array とは、i 番目の要素が s[sa[i]..|<paramref name="s"/>|), s[sa[i+1]..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さのもの。</para>
        /// <para>制約: 0≤|<paramref name="s"/>|≤10^8, <paramref name="sa"/> は <paramref name="s"/> の Suffix Array</para>
        /// <para>計算量: O(|<paramref name="s"/>|)</para>
        /// </remarks>
        public static int[] LCPArray(string s, int[] sa) => LCPArray(s.AsSpan(), sa);

        /// <summary>
        /// 数列 <paramref name="s"/> の LCP Array として、長さ |<paramref name="s"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>LCP Array とは、i 番目の要素が s[sa[i]..|<paramref name="s"/>|), s[sa[i+1]..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さのもの。</para>
        /// <para>制約: 0≤|<paramref name="s"/>|≤10^8, <paramref name="sa"/> は <paramref name="s"/> の Suffix Array</para>
        /// <para>計算量: O(|<paramref name="s"/>|)</para>
        /// </remarks>
        public static int[] LCPArray<T>(T[] s, int[] sa) => LCPArray((ReadOnlySpan<T>)s, sa);
    }
}


namespace AtCoder
{
    public static partial class String
    {
        /// <summary>
        /// 列 <paramref name="m"/> の Suffix Array として、長さ |<paramref name="m"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
        /// <para>制約: 0≤|<paramref name="m"/>|&lt;10^8</para>
        /// <para>計算量: 時間O(|<paramref name="m"/>|log|<paramref name="m"/>|), 空間O(|<paramref name="m"/>|)</para>
        /// </remarks>
        private static int[] SuffixArray<T>(ReadOnlyMemory<T> m)
        {
            var s = m.Span;
            var n = m.Length;
            var idx = Enumerable.Range(0, n).ToArray();
            Array.Sort(idx, Compare);
            var s2 = new int[n];
            var now = 0;

            // 座標圧縮
            for (int i = 0; i < idx.Length; i++)
            {
                if (i > 0 && !EqualityComparer<T>.Default.Equals(s[idx[i - 1]], s[idx[i]]))
                {
                    now++;
                }
                s2[idx[i]] = now;
            }

            return Internal.String.SAIS(s2, now);

            int Compare(int l, int r)
            {
                var s = m.Span;
                return Comparer<T>.Default.Compare(s[l], s[r]);
            }
        }

        /// <summary>
        /// 文字列 <paramref name="s"/> の Suffix Array として、長さ |<paramref name="s"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
        /// <para>制約: 0≤|<paramref name="s"/>|&lt;10^8</para>
        /// <para>計算量: O(|<paramref name="s"/>|)</para>
        /// </remarks>
        public static int[] SuffixArray(string s)
        {
            var n = s.Length;
            int[] s2 = s.Select(c => (int)c).ToArray();
            return Internal.String.SAIS(s2, char.MaxValue);
        }


        /// <summary>
        /// 数列 <paramref name="s"/> の Suffix Array として、長さ |<paramref name="s"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
        /// <para>制約: 0≤|<paramref name="s"/>|&lt;10^8</para>
        /// <para>計算量: 時間O(|<paramref name="s"/>|log|<paramref name="s"/>|), 空間O(|<paramref name="s"/>|)</para>
        /// </remarks>
        public static int[] SuffixArray<T>(T[] s) => SuffixArray<T>(s.AsMemory());

        /// <summary>
        /// 数列 <paramref name="s"/> の Suffix Array として、長さ |<paramref name="s"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
        /// <para>制約: 0≤|<paramref name="s"/>|&lt;10^8, <paramref name="s"/> のすべての要素 x について 0≤x≤<paramref name="upper"/></para>
        /// <para>計算量: O(|<paramref name="s"/>|+<paramref name="upper"/>)</para>
        /// </remarks>
        public static int[] SuffixArray(int[] s, int upper)
        {
            Debug.Assert(0 <= upper);
            foreach (var si in s)
            {
                Debug.Assert(unchecked((uint)si) <= upper);
            }
            return Internal.String.SAIS(s, upper);
        }
    }
}


namespace AtCoder
{
    public static partial class String
    {
        /// <summary>
        /// i 番目の要素は s[0..|<paramref name="s"/>|) と s[i..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さであるような、長さ |<paramref name="s"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤|<paramref name="s"/>|≤10^8</para>
        /// <para>計算量: O(|<paramref name="s"/>|)</para>
        /// </remarks>
        public static int[] ZAlgorithm<T>(ReadOnlySpan<T> s)
        {
            int n = s.Length;
            if (n == 0) return new int[] { };
            int[] z = new int[n];
            z[0] = 0;
            for (int i = 1, j = 0; i < n; i++)
            {
                ref int k = ref z[i];
                k = (j + z[j] <= i) ? 0 : System.Math.Min(j + z[j] - i, z[i - j]);
                while (i + k < n && EqualityComparer<T>.Default.Equals(s[k], s[i + k])) k++;
                if (j + z[j] < i + z[i]) j = i;
            }
            z[0] = n;
            return z;
        }

        /// <summary>
        /// i 番目の要素は s[0..|<paramref name="s"/>|) と s[i..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さであるような、長さ |<paramref name="s"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤|<paramref name="s"/>|≤10^8</para>
        /// <para>計算量: O(|<paramref name="s"/>|)</para>
        /// </remarks>
        public static int[] ZAlgorithm(string s) => ZAlgorithm(s.AsSpan());

        /// <summary>
        /// i 番目の要素は s[0..|<paramref name="s"/>|) と s[i..|<paramref name="s"/>|) の LCP(Longest Common Prefix) の長さであるような、長さ |<paramref name="s"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>制約: 0≤|<paramref name="s"/>|≤10^8</para>
        /// <para>計算量: O(|<paramref name="s"/>|)</para>
        /// </remarks>
        public static int[] ZAlgorithm<T>(T[] s) => ZAlgorithm((ReadOnlySpan<T>)s);
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

                var now = StaticModInt<T>.Raw(1);

                // 各ブロックの s 段目
                for (int s = 0; s < w; s++)
                {
                    int offset = s << (h - ph + 1);

                    for (int i = 0; i < p; i++)
                    {
                        var l = a[i + offset];
                        var r = a[i + offset + p] * now;
                        a[i + offset] = l + r;
                        a[i + offset + p] = l - r;
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


namespace AtCoder.Internal
{
    public static class String
    {
        /// <summary>
        /// 数列 <paramref name="sm"/> の Suffix Array をナイーブな文字列比較により求め、長さ |<paramref name="sm"/>| の配列として返す。
        /// </summary>
        /// <remarks>
        /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
        /// <para>制約: 0≤|<paramref name="sm"/>|&lt;10^8</para>
        /// <para>計算量: 時間O(|<paramref name="sm"/>|^2 log|<paramref name="sm"/>|), 空間O(|<paramref name="sm"/>|)</para>
        /// </remarks>
        private static int[] SANaive(ReadOnlyMemory<int> sm)
        {
            var n = sm.Length;
            var sa = Enumerable.Range(0, n).ToArray();
            Array.Sort(sa, Compare);
            return sa;

            int Compare(int l, int r)
            {
                // l == r にはなり得ない
                var s = sm.Span;
                while (l < s.Length && r < s.Length)
                {
                    if (s[l] != s[r])
                    {
                        return s[l] - s[r];
                    }
                    l++;
                    r++;
                }

                return r - l;
            }
        }

        /// <summary>
        /// 数列 <paramref name="sm"/> の Suffix Array をダブリングにより求め、長さ |<paramref name="sm"/>| の配列として返す。
        /// </summary>
        /// <remarks>
        /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
        /// <para>制約: 0≤|<paramref name="sm"/>|&lt;10^8</para>
        /// <para>計算量: 時間O(|<paramref name="sm"/>|(log|<paramref name="sm"/>|)^2), 空間O(|<paramref name="sm"/>|)</para>
        /// </remarks>
        private static int[] SADoubling(ReadOnlyMemory<int> sm)
        {
            var s = sm.Span;
            var n = s.Length;
            var sa = Enumerable.Range(0, n).ToArray();
            var rnk = new int[n];
            var tmp = new int[n];
            s.CopyTo(rnk);

            for (int k = 1; k < n; k <<= 1)
            {
                Array.Sort(sa, Compare);
                tmp[sa[0]] = 0;
                for (int i = 1; i < sa.Length; i++)
                {
                    tmp[sa[i]] = tmp[sa[i - 1]] + (Compare(sa[i - 1], sa[i]) < 0 ? 1 : 0);
                }
                (tmp, rnk) = (rnk, tmp);

                int Compare(int x, int y)
                {
                    if (rnk[x] != rnk[y])
                    {
                        return rnk[x] - rnk[y];
                    }

                    int rx = x + k < n ? rnk[x + k] : -1;
                    int ry = y + k < n ? rnk[y + k] : -1;

                    return rx - ry;
                }
            }

            return sa;
        }

        /// <summary>
        /// 数列 <paramref name="sm"/> の Suffix Array を SA-IS 等により求め、長さ |<paramref name="sm"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
        /// <para>制約: 0≤|<paramref name="sm"/>|&lt;10^8</para>
        /// <para>計算量: O(|<paramref name="sm"/>|)</para>
        /// </remarks>
        public static int[] SAIS(ReadOnlyMemory<int> sm, int upper) => SAIS(sm, upper, 10, 40);

        /// <summary>
        /// 数列 <paramref name="sm"/> の Suffix Array を SA-IS 等により求め、長さ |<paramref name="sm"/>| の配列を返す。
        /// </summary>
        /// <remarks>
        /// <para>Suffix Array sa は (0,1,…,n−1) の順列であって、i=0,1,⋯,n−2 について s[sa[i]..n)&lt;s[sa[i+1]..n) を満たすもの。</para>
        /// <para>制約: 0≤|<paramref name="sm"/>|&lt;10^8</para>
        /// <para>計算量: O(|<paramref name="sm"/>|)</para>
        /// </remarks>
        public static int[] SAIS(ReadOnlyMemory<int> sm, int upper, int thresholdNaive, int thresholdDouling)
        {
            var s = sm.Span;
            var n = s.Length;

            if (n == 0)
            {
                return Array.Empty<int>();
            }
            else if (n == 1)
            {
                return new int[] { 0 };
            }
            else if (n == 2)
            {
                if (s[0] < s[1])
                {
                    return new int[] { 0, 1 };
                }
                else
                {
                    return new int[] { 1, 0 };
                }
            }
            else if (n < thresholdNaive)
            {
                return SANaive(sm);
            }
            else if (n < thresholdDouling)
            {
                return SADoubling(sm);
            }

            var sa = new int[n];
            var ls = new bool[n];

            for (int i = sa.Length - 2; i >= 0; i--)
            {
                // S-typeならtrue、L-typeならfalse
                ls[i] = (s[i] == s[i + 1]) ? ls[i + 1] : (s[i] < s[i + 1]);
            }

            // バケットサイズの累積和（＝開始インデックス）
            var sumL = new int[upper + 1];
            var sumS = new int[upper + 1];

            for (int i = 0; i < s.Length; i++)
            {
                if (!ls[i])
                {
                    sumS[s[i]]++;
                }
                else
                {
                    sumL[s[i] + 1]++;
                }
            }

            for (int i = 0; i < sumL.Length; i++)
            {
                sumS[i] += sumL[i];
                if (i < upper)
                {
                    sumL[i + 1] += sumS[i];
                }
            }

            var lmsMap = GetFilledArray(-1, n + 1);
            int m = 0;
            for (int i = 1; i < ls.Length; i++)
            {
                if (!ls[i - 1] && ls[i])
                {
                    lmsMap[i] = m++;
                }
            }

            var lms = new List<int>(m);
            for (int i = 1; i < ls.Length; i++)
            {
                if (!ls[i - 1] && ls[i])
                {
                    lms.Add(i);
                }
            }

            Induce(lms);

            // LMSを再帰的にソート
            if (m > 0)
            {
                var sortedLms = new List<int>(m);
                foreach (var v in sa)
                {
                    if (lmsMap[v] != -1)
                    {
                        sortedLms.Add(v);
                    }
                }

                var recS = new int[m];
                var recUpper = 0;
                recS[lmsMap[sortedLms[0]]] = 0;

                // 同じLMS同士をまとめていく
                for (int i = 1; i < sortedLms.Count; i++)
                {
                    var l = sortedLms[i - 1];
                    var r = sortedLms[i];
                    var endL = (lmsMap[l] + 1 < m) ? lms[lmsMap[l] + 1] : n;
                    var endR = (lmsMap[r] + 1 < m) ? lms[lmsMap[r] + 1] : n;
                    var same = true;

                    if (endL - l != endR - r)
                    {
                        same = false;
                    }
                    else
                    {
                        while (l < endL)
                        {
                            if (s[l] != s[r])
                            {
                                break;
                            }
                            l++;
                            r++;
                        }

                        if (l == n || s[l] != s[r])
                        {
                            same = false;
                        }
                    }

                    if (!same)
                    {
                        recUpper++;
                    }

                    recS[lmsMap[sortedLms[i]]] = recUpper;
                }

                var recSA = SAIS(recS, recUpper, thresholdNaive, thresholdDouling);

                for (int i = 0; i < sortedLms.Count; i++)
                {
                    sortedLms[i] = lms[recSA[i]];
                }

                Induce(sortedLms);
            }

            return sa;

            void Induce(List<int> lms)
            {
                var s = sm.Span;
                sa.AsSpan().Fill(-1);
                var buf = new int[sumS.Length];

                // LMS
                sumS.AsSpan().CopyTo(buf);
                foreach (var d in lms)
                {
                    if (d == n)
                    {
                        continue;
                    }
                    sa[buf[s[d]]++] = d;
                }

                // L-type
                sumL.AsSpan().CopyTo(buf);
                sa[buf[s[n - 1]]++] = n - 1;
                for (int i = 0; i < sa.Length; i++)
                {
                    int v = sa[i];
                    if (v >= 1 && !ls[v - 1])
                    {
                        sa[buf[s[v - 1]]++] = v - 1;
                    }
                }

                // S-type
                sumL.AsSpan().CopyTo(buf);
                for (int i = sa.Length - 1; i >= 0; i--)
                {
                    int v = sa[i];
                    if (v >= 1 && ls[v - 1])
                    {
                        sa[--buf[s[v - 1] + 1]] = v - 1;
                    }
                }
            }
        }

        /// <summary>
        /// 各要素が <paramref name="value"/> で初期化された長さ <paramref name="length"/> の配列を取得する。
        /// </summary>
        private static T[] GetFilledArray<T>(T value, int length)
        {
            // Enumerable.Repeatより1-2割ほど高速（64bit環境、intの場合）
            // |           Method |     Mean |   Error |  StdDev |
            // |----------------- |---------:|--------:|--------:|
            // | EnumerableRepeat | 212.7 ms | 2.99 ms | 2.80 ms |
            // |         SpanFill | 178.7 ms | 1.29 ms | 1.14 ms |

            // ちなみにEnumerable.Rangeとnew[] + for文とでは有意差は見られない
            // |          Method |     Mean |   Error |  StdDev |
            // |---------------- |---------:|--------:|--------:|
            // | EnumerableRange | 225.6 ms | 4.35 ms | 3.85 ms |
            // |         SpanFor | 223.0 ms | 2.88 ms | 2.69 ms |

            var result = new T[length];
            result.AsSpan().Fill(value);
            return result;
        }
    }
}

#region Base Class

namespace ACLBeginnerContest.Questions
{

    public interface IAtCoderQuestion
    {
        string Solve(string input);
        void Solve(IOManager io);
    }

    public abstract class AtCoderQuestionBase : IAtCoderQuestion
    {
        public string Solve(string input)
        {
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            var outputStream = new MemoryStream();
            using var manager = new IOManager(inputStream, outputStream);

            Solve(manager);
            manager.Flush();

            outputStream.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(outputStream);
            return reader.ReadToEnd();
        }

        public abstract void Solve(IOManager io);
    }

    public class IOManager : IDisposable
    {
        private readonly BinaryReader _reader;
        private readonly StreamWriter _writer;
        private bool _disposedValue;
        private byte[] _buffer = new byte[1024];
        private int _length;
        private int _cursor;
        private bool _eof;

        const char ValidFirstChar = '!';
        const char ValidLastChar = '~';

        public IOManager(Stream input, Stream output)
        {
            _reader = new BinaryReader(input);
            _writer = new StreamWriter(output) { AutoFlush = false };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private char ReadAscii()
        {
            if (_cursor == _length)
            {
                _cursor = 0;
                _length = _reader.Read(_buffer);

                if (_length == 0)
                {
                    if (!_eof)
                    {
                        _eof = true;
                        return char.MinValue;
                    }
                    else
                    {
                        ThrowEndOfStreamException();
                    }
                }
            }

            return (char)_buffer[_cursor++];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public char ReadChar()
        {
            char c;
            while (!IsValidChar(c = ReadAscii())) { }
            return c;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ReadString()
        {
            var builder = new StringBuilder();
            char c;
            while (!IsValidChar(c = ReadAscii())) { }

            do
            {
                builder.Append(c);
            } while (IsValidChar(c = ReadAscii()));

            return builder.ToString();
        }

        public int ReadInt() => (int)ReadLong();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long ReadLong()
        {
            long result = 0;
            bool isPositive = true;
            char c;

            while (!IsNumericChar(c = ReadAscii())) { }

            if (c == '-')
            {
                isPositive = false;
                c = ReadAscii();
            }

            do
            {
                result *= 10;
                result += c - '0';
            } while (IsNumericChar(c = ReadAscii()));

            return isPositive ? result : -result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Span<char> ReadChunk(Span<char> span)
        {
            var i = 0;
            char c;
            while (!IsValidChar(c = ReadAscii())) { }

            do
            {
                span[i++] = c;
            } while (IsValidChar(c = ReadAscii()));

            return span.Slice(0, i);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double ReadDouble() => double.Parse(ReadChunk(stackalloc char[32]));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public decimal ReadDecimal() => decimal.Parse(ReadChunk(stackalloc char[32]));

        public int[] ReadIntArray(int n)
        {
            var a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadInt();
            }
            return a;
        }

        public long[] ReadLongArray(int n)
        {
            var a = new long[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadLong();
            }
            return a;
        }

        public double[] ReadDoubleArray(int n)
        {
            var a = new double[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadDouble();
            }
            return a;
        }

        public decimal[] ReadDecimalArray(int n)
        {
            var a = new decimal[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = ReadDecimal();
            }
            return a;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteLine<T>(T value) => _writer.WriteLine(value.ToString());

        public void WriteLine<T>(IEnumerable<T> values, char separator)
        {
            var e = values.GetEnumerator();
            if (e.MoveNext())
            {
                _writer.Write(e.Current.ToString());

                while (e.MoveNext())
                {
                    _writer.Write(separator);
                    _writer.Write(e.Current.ToString());
                }
            }

            _writer.WriteLine();
        }

        public void WriteLine<T>(Span<T> values, char separator) => WriteLine((ReadOnlySpan<T>)values, separator);

        public void WriteLine<T>(ReadOnlySpan<T> values, char separator)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                _writer.Write(values[i]);
                _writer.Write(separator);
            }

            if (values.Length > 0)
            {
                _writer.Write(values[^1]);
            }

            _writer.WriteLine();
        }

        public void Flush() => _writer.Flush();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsValidChar(char c) => ValidFirstChar <= c && c <= ValidLastChar;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNumericChar(char c) => ('0' <= c && c <= '9') || c == '-';

        private void ThrowEndOfStreamException() => throw new EndOfStreamException();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _reader.Dispose();
                    _writer.Flush();
                    _writer.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

#endregion

#region Algorithm

namespace ACLBeginnerContest.Numerics
{
    public static class NumericalAlgorithms
    {
        public static long Gcd(long a, long b)
        {
            if (a < b)
            {
                (a, b) = (b, a);
            }

            if (b > 0)
            {
                return Gcd(b, a % b);
            }
            else if (b == 0)
            {
                return a;
            }
            else
            {
                throw new ArgumentOutOfRangeException($"{nameof(a)}, {nameof(b)}は0以上の整数である必要があります。");
            }
        }

        public static long Lcm(long a, long b)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(a)}, {nameof(b)}は0以上の整数である必要があります。");
            }

            return a / Gcd(a, b) * b;
        }

        public static long Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), $"{n}は0以上の整数でなければなりません。");
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static long Permutation(int n, int r)
        {
            CheckNR(n, r);
            long result = 1;
            for (int i = 0; i < r; i++)
            {
                result *= n - i;
            }
            return result;
        }

        public static long Combination(int n, int r)
        {
            CheckNR(n, r);
            r = System.Math.Min(r, n - r);

            // See https://stackoverflow.com/questions/1838368/calculating-the-amount-of-combinations
            long result = 1;
            for (int i = 1; i <= r; i++)
            {
                result *= n--;
                result /= i;
            }
            return result;
        }

        public static long CombinationWithRepetition(int n, int r) => Combination(n + r - 1, r);

        public static IEnumerable<(int prime, int count)> PrimeFactorization(int n)
        {
            if (n <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(n), $"{n}は2以上の整数でなければなりません。");
            }

            var dictionary = new Dictionary<int, int>();
            for (int i = 2; i * i <= n; i++)
            {
                while (n % i == 0)
                {
                    if (dictionary.ContainsKey(i))
                    {
                        dictionary[i]++;
                    }
                    else
                    {
                        dictionary[i] = 1;
                    }

                    n /= i;
                }
            }

            if (n > 1)
            {
                dictionary[n] = 1;
            }

            return dictionary.Select(p => (p.Key, p.Value));
        }

        private static void CheckNR(int n, int r)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は正の整数でなければなりません。");
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
            r = System.Math.Min(r, n - r);
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

    public class ModMatrix
    {
        readonly Modular[] _values;
        public int Height { get; }
        public int Width { get; }

        public Span<Modular> this[int row]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => _values.AsSpan(row * Width, Width);
        }

        public Modular this[int row, int column]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (unchecked((uint)row) >= Height)
                    ThrowsArgumentOutOfRangeException(nameof(row));
                else if (unchecked((uint)column) >= Width)
                    ThrowsArgumentOutOfRangeException(nameof(column));
                return _values[row * Width + column];
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (unchecked((uint)row) >= Height)
                    ThrowsArgumentOutOfRangeException(nameof(row));
                else if (unchecked((uint)column) >= Width)
                    ThrowsArgumentOutOfRangeException(nameof(column));
                _values[row * Width + column] = value;
            }
        }

        public ModMatrix(int n) : this(n, n) { }

        public ModMatrix(int height, int width)
        {
            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height));
            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width));
            Height = height;
            Width = width;
            _values = new Modular[height * width];
        }

        public ModMatrix(Modular[][] values) : this(values.Length, values[0].Length)
        {
            for (int row = 0; row < Height; row++)
            {
                if (Width != values[row].Length)
                    throw new ArgumentException($"{nameof(values)}の列数は揃っている必要があります。");
                var span = _values.AsSpan(row * Width, Width);
                values[row].AsSpan().CopyTo(span);
            }
        }

        public ModMatrix(Modular[,] values) : this(values.GetLength(0), values.GetLength(1))
        {
            for (int row = 0; row < Height; row++)
            {
                var span = _values.AsSpan(row * Width, Width);
                for (int column = 0; column < span.Length; column++)
                {
                    span[column] = values[row, column];
                }
            }
        }

        public ModMatrix(ModMatrix matrix)
        {
            Height = matrix.Height;
            Width = matrix.Width;
            _values = new Modular[matrix._values.Length];
            matrix._values.AsSpan().CopyTo(_values);
        }

        public static ModMatrix GetIdentity(int dimension)
        {
            var result = new ModMatrix(dimension);
            for (int i = 0; i < dimension; i++)
            {
                result._values[i * result.Width + i] = 1;
            }
            return result;
        }

        public static ModMatrix operator +(ModMatrix a, ModMatrix b)
        {
            CheckSameShape(a, b);

            var result = new ModMatrix(a.Height, a.Width);
            for (int i = 0; i < result._values.Length; i++)
            {
                result._values[i] = a._values[i] + b._values[i];
            }
            return result;
        }

        public static ModMatrix operator -(ModMatrix a, ModMatrix b)
        {
            CheckSameShape(a, b);

            var result = new ModMatrix(a.Height, a.Width);
            for (int i = 0; i < result._values.Length; i++)
            {
                result._values[i] = a._values[i] - b._values[i];
            }
            return result;
        }

        public static ModMatrix operator *(ModMatrix a, ModMatrix b)
        {
            if (a.Width != b.Height)
                throw new ArgumentException($"{nameof(a)}の列数と{nameof(b)}の行数は等しくなければなりません。");

            var result = new ModMatrix(a.Height, b.Width);
            for (int i = 0; i < result.Height; i++)
            {
                var aSpan = a._values.AsSpan(i * a.Width, a.Width);
                var resultSpan = result._values.AsSpan(i * result.Width, result.Width);
                for (int k = 0; k < aSpan.Length; k++)
                {
                    var bSpan = b._values.AsSpan(k * b.Width, b.Width);
                    for (int j = 0; j < resultSpan.Length; j++)
                    {
                        resultSpan[j] += aSpan[k] * bSpan[j];
                    }
                }
            }
            return result;
        }

        public static ModVector operator *(ModMatrix matrix, ModVector vector)
        {
            if (matrix.Width != vector.Length)
                throw new ArgumentException($"{nameof(matrix)}の列数と{nameof(vector)}の行数は等しくなければなりません。");

            var result = new ModVector(vector.Length);
            for (int i = 0; i < result.Length; i++)
            {
                var matrixSpan = matrix[i];
                for (int k = 0; k < matrixSpan.Length; k++)
                {
                    result[i] += matrixSpan[k] * vector[k];
                }
            }
            return result;
        }

        public ModMatrix Pow(long pow)
        {
            if (Height != Width)
                throw new ArgumentException("累乗を行う行列は正方行列である必要があります。");
            if (pow < 0)
                throw new ArgumentException($"{nameof(pow)}は0以上の整数である必要があります。");

            var powMatrix = new ModMatrix(this);
            var result = GetIdentity(Height);
            while (pow > 0)
            {
                if ((pow & 1) > 0)
                {
                    result *= powMatrix;
                }
                powMatrix *= powMatrix;
                pow >>= 1;
            }
            return result;
        }

        private static void CheckSameShape(ModMatrix a, ModMatrix b)
        {
            if (a.Height != b.Height)
                throw new ArgumentException($"{nameof(a)}の行数と{nameof(b)}の行数は等しくなければなりません。");
            else if (a.Width != b.Width)
                throw new ArgumentException($"{nameof(a)}の列数と{nameof(b)}の列数は等しくなければなりません。");
        }

        private void ThrowsArgumentOutOfRangeException(string paramName) => throw new ArgumentOutOfRangeException(paramName);
        public override string ToString() => $"({Height}x{Width})matrix";
    }

    public class ModVector
    {
        readonly Modular[] _values;
        public int Length => _values.Length;

        public ModVector(int length)
        {
            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length));
            _values = new Modular[length];
        }

        public ModVector(ReadOnlySpan<Modular> vector)
        {
            _values = new Modular[vector.Length];
            vector.CopyTo(_values);
        }

        public ModVector(ModVector vector) : this(vector._values) { }

        public Modular this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }

        public static ModVector operator +(ModVector a, ModVector b)
        {
            if (a.Length != b.Length)
                throw new ArgumentException($"{nameof(a)}と{nameof(b)}の次元は等しくなければなりません。");

            var result = new ModVector(a.Length);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = a[i] + b[i];
            }
            return result;
        }

        public static ModVector operator -(ModVector a, ModVector b)
        {
            if (a.Length != b.Length)
                throw new ArgumentException($"{nameof(a)}と{nameof(b)}の次元は等しくなければなりません。");

            var result = new ModVector(a.Length);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = a[i] - b[i];
            }
            return result;
        }

        public static Modular operator *(ModVector a, ModVector b)
        {
            if (a.Length != b.Length)
                throw new ArgumentException($"{nameof(a)}と{nameof(b)}の次元は等しくなければなりません。");

            var result = Modular.Zero;
            for (int i = 0; i < a.Length; i++)
            {
                result += a[i] * b[i];
            }
            return result;
        }

        public override string ToString() => $"({Length})vector";
    }

    public class Eratosthenes
    {
        /// <summary>
        /// Smallest Prime Factorを保存した配列
        /// </summary>
        readonly int[] _spf;

        public Eratosthenes(int max)
        {
            _spf = Enumerable.Range(0, max + 1).ToArray();
            for (int i = 2; i * i <= max; i++)
            {
                if (_spf[i] == i)
                {
                    for (int mul = i << 1; mul <= max; mul += i)
                    {
                        if (_spf[mul] == mul)
                        {
                            _spf[mul] = i;
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsPrime(int n) => n >= 2 && _spf[n] == n;

        public IEnumerable<PrimeAndCount> PrimeFactorize(int n)
        {
            if (n <= 0 || _spf.Length <= n)
            {
                throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は[0, {_spf.Length})の間でなければなりません");
            }
            else if (n == 1)
            {
                yield break;
            }
            else
            {
                var last = _spf[n];
                var streak = 0;
                while (n > 1)
                {
                    if (_spf[n] == last)
                    {
                        streak++;
                    }
                    else
                    {
                        yield return new PrimeAndCount(last, streak);
                        last = _spf[n];
                        streak = 1;
                    }

                    n /= last;
                }
                yield return new PrimeAndCount(last, streak);
            }
        }

        public IEnumerable<int> GetDivisiors(int n)
        {
            if (n <= 0 || _spf.Length <= n)
            {
                throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)}は[0, {_spf.Length})の間でなければなりません");
            }
            else
            {
                var primes = PrimeFactorize(n).ToArray();
                return GetDivisiors(primes, 0);
            }
        }

        IEnumerable<int> GetDivisiors(PrimeAndCount[] primes, int depth)
        {
            if (depth == primes.Length)
            {
                yield return 1;
            }
            else
            {
                var current = 1;
                var children = GetDivisiors(primes, depth + 1).ToArray();

                foreach (var child in children)
                {
                    yield return child;
                }

                for (int i = 0; i < primes[depth].Count; i++)
                {
                    current *= primes[depth].Prime;
                    foreach (var child in children)
                    {
                        yield return current * child;
                    }
                }
            }
        }
    }

    public static class Divisiors
    {
        public static IEnumerable<long> GetDivisiors(long n)
        {
            var lastHalf = new Stack<long>();
            for (long i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    if (i * i != n)
                    {
                        lastHalf.Push(n / i);
                    }
                }
            }

            while (lastHalf.Count > 0)
            {
                yield return lastHalf.Pop();
            }
        }
    }

    [StructLayout(LayoutKind.Auto)]
    public readonly struct PrimeAndCount
    {
        public int Prime { get; }
        public int Count { get; }

        public PrimeAndCount(int prime, int count)
        {
            Prime = prime;
            Count = count;
        }

        public void Deconstruct(out int prime, out int count) => (prime, count) = (Prime, Count);
        public override string ToString() => $"{nameof(Prime)}: {Prime}, {nameof(Count)}: {Count}";
    }

    public readonly struct Fraction : IEquatable<Fraction>, IComparable<Fraction>
    {
        /// <summary>分子</summary>
        public long Numerator { get; }
        /// <summary>分母</summary>
        public long Denominator { get; }

        public static Fraction Nan => new Fraction(0, 0);
        public static Fraction PositiveInfinity => new Fraction(1, 0);
        public static Fraction NegativeInfinity => new Fraction(-1, 0);
        public bool IsNan => Numerator == 0 && Denominator == 0;
        public bool IsInfinity => Numerator != 0 && Denominator == 0;
        public bool IsPositiveInfinity => Numerator > 0 && Denominator == 0;
        public bool IsNegativeInfinity => Numerator < 0 && Denominator == 0;

        /// <summary>
        /// <c>Fraction</c>クラスの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        public Fraction(long numerator, long denominator)
        {
            if (denominator == 0)
            {
                Numerator = System.Math.Sign(numerator);
                Denominator = 0;
            }
            else if (numerator == 0)
            {
                Numerator = 0;
                Denominator = 1;
            }
            else
            {
                var sign = System.Math.Sign(numerator) * System.Math.Sign(denominator);
                numerator = System.Math.Abs(numerator);
                denominator = System.Math.Abs(denominator);
                var gcd = NumericalAlgorithms.Gcd(numerator, denominator);
                Numerator = sign * numerator / gcd;
                Denominator = denominator / gcd;
            }
        }

        public static Fraction operator +(in Fraction left, in Fraction right)
        {
            if (left.IsNan || right.IsNan)
            {
                return Nan;
            }
            else if (left.IsInfinity || right.IsInfinity)
            {
                if (!right.IsInfinity)
                {
                    return left;
                }
                else if (!left.IsInfinity)
                {
                    return right;
                }
                else
                {
                    return new Fraction(left.Numerator + right.Numerator, 0);
                }
            }
            else
            {
                var lcm = NumericalAlgorithms.Lcm(left.Denominator, right.Denominator);
                return new Fraction(left.Numerator * (lcm / left.Denominator) + right.Numerator * (lcm / right.Denominator), lcm);
            }
        }
        public static Fraction operator -(in Fraction left, in Fraction right) => left + -right;
        public static Fraction operator *(in Fraction left, in Fraction right) => new Fraction(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
        public static Fraction operator /(in Fraction left, in Fraction right) => new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
        public static Fraction operator +(in Fraction right) => right;
        public static Fraction operator -(in Fraction right) => new Fraction(-right.Numerator, right.Denominator);
        public static bool operator ==(in Fraction left, in Fraction right) => left.Equals(right);
        public static bool operator !=(in Fraction left, in Fraction right) => !(left == right);
        public static implicit operator double(in Fraction right)
        {
            if (right.IsNan)
            {
                return double.NaN;
            }
            else if (right.IsPositiveInfinity)
            {
                return double.PositiveInfinity;
            }
            else if (right.IsNegativeInfinity)
            {
                return double.NegativeInfinity;
            }
            else
            {
                return (double)right.Numerator / right.Denominator;
            }
        }

        public override string ToString()
        {
            if (IsNan)
            {
                return "NaN";
            }
            else if (IsPositiveInfinity)
            {
                return "Inf";
            }
            else if (IsNegativeInfinity)
            {
                return "-Inf";
            }
            else
            {
                return $"{Numerator}/{Denominator}";
            }
        }

        public override bool Equals(object obj) => obj is Fraction fraction && Equals(fraction);
        public bool Equals(Fraction other) => Numerator == other.Numerator && Denominator == other.Denominator;
        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);
        public int CompareTo([System.Diagnostics.CodeAnalysis.AllowNull] Fraction other) => ((double)this).CompareTo(other);
    }

    public interface ISemigroup<TSet> where TSet : ISemigroup<TSet>
    {
        public TSet Merge(TSet other);
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
}

namespace ACLBeginnerContest.Algorithms
{
    public static class ZAlgorithm
    {
        public static int[] SearchAll(string s) => SearchAll(s.AsSpan());

        public static int[] SearchAll<T>(ReadOnlySpan<T> s) where T : IEquatable<T>
        {
            var z = new int[s.Length];
            z[0] = s.Length;
            var offset = 1;
            var length = 0;

            while (offset < s.Length)
            {
                while (offset + length < s.Length && s[length].Equals(s[offset + length]))
                {
                    length++;
                }
                z[offset] = length;

                if (length == 0)
                {
                    offset++;
                    continue;
                }

                int copyLength = 1;
                while (copyLength < length && copyLength + z[copyLength] < length)
                {
                    z[offset + copyLength] = z[copyLength];
                    copyLength++;
                }
                offset += copyLength;
                length -= copyLength;
            }

            return z;
        }
    }

    /// <summary>
    /// MP法（文字列検索アルゴリズム）
    /// </summary>
    public class MorrisPratt<T> where T : IEquatable<T>
    {
        readonly T[] _searchSequence;
        readonly int[] _matchLength;

        public ReadOnlySpan<T> SearchSequence => _searchSequence.AsSpan();

        /// <summary>
        /// 検索データ列の前処理を行います。
        /// </summary>
        /// <param name="searchSequence">検索データ列</param>
        public MorrisPratt(ReadOnlySpan<T> searchSequence)
        {
            _searchSequence = searchSequence.ToArray();
            _matchLength = new int[_searchSequence.Length + 1];
            _matchLength[0] = -1;
            int j = -1;
            for (int i = 0; i < _searchSequence.Length; i++)
            {
                while (j != -1 && !_searchSequence[j].Equals(_searchSequence[i]))
                {
                    j = _matchLength[j];
                }
                j++;
                _matchLength[i + 1] = j;
            }
        }

        /// <summary>
        /// 与えられた対象データ列の部分列のうち、検索データ列にマッチする部分列の開始インデックスを取得します。
        /// </summary>
        /// <param name="targetSequence">検索対象データ列</param>
        /// <returns></returns>
        public List<int> SearchAll(ReadOnlySpan<T> targetSequence)
        {
            var results = new List<int>();
            int j = 0;
            for (int i = 0; i < targetSequence.Length; i++)
            {
                while (j != -1 && !_searchSequence[j].Equals(targetSequence[i]))
                {
                    j = _matchLength[j];
                }
                j++;
                if (j == _searchSequence.Length)
                {
                    results.Add(i - j + 1);
                    j = _matchLength[j];
                }
            }
            return results;
        }
    }

    /// <summary>
    /// 参考: https://qiita.com/keymoon/items/11fac5627672a6d6a9f6
    /// ジェネリクスに対応させるにはGetHashCode()を足していく？実装によっては重そうなのでとりあえずパス。
    /// </summary>
    public class RollingHash
    {
        const ulong Mask30 = (1UL << 30) - 1;
        const ulong Mask31 = (1UL << 31) - 1;
        const ulong Mod = (1UL << 61) - 1;
        const ulong Positivizer = Mod * ((1UL << 3) - 1);   // 引き算する前に足すことでmodが負になることを防ぐやつ
        static readonly uint base1;
        static readonly uint base2;
        static readonly List<ulong> pow1;
        static readonly List<ulong> pow2;

        static RollingHash()
        {
            var random = new Random();
            base1 = (uint)random.Next(129, int.MaxValue >> 2);
            base2 = (uint)random.Next(int.MaxValue >> 2, int.MaxValue); // 32bit目は0にしておく
            pow1 = new List<ulong>() { 1 };
            pow2 = new List<ulong>() { 1 };
        }

        ulong[] hash1;
        ulong[] hash2;
        public string RawString { get; }
        public int Length => RawString.Length;

        public RollingHash(string s)
        {
            RawString = s;
            hash1 = new ulong[s.Length + 1];
            hash2 = new ulong[s.Length + 1];

            for (int i = pow1.Count; i < s.Length + 1; i++)
            {
                pow1.Add(CalculateModular(Multiply(pow1[i - 1], base1)));
                pow2.Add(CalculateModular(Multiply(pow2[i - 1], base2)));
            }

            for (int i = 0; i < s.Length; i++)
            {
                hash1[i + 1] = CalculateModular(Multiply(hash1[i], base1) + s[i]);
                hash2[i + 1] = CalculateModular(Multiply(hash2[i], base2) + s[i]);
            }
        }

        public (ulong, ulong) this[Range range]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var (offset, length) = range.GetOffsetAndLength(Length);
                return Slice(offset, length);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (ulong, ulong) Slice(int begin, int length)
        {
            var result1 = CalculateModular(hash1[begin + length] + Positivizer - Multiply(hash1[begin], pow1[length]));
            var result2 = CalculateModular(hash2[begin + length] + Positivizer - Multiply(hash2[begin], pow2[length]));
            return (result1, result2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong Multiply(ulong l, ulong r)
        {
            var lu = l >> 31;
            var ll = l & Mask31;
            var ru = r >> 31;
            var rl = r & Mask31;
            var mid = ll * ru + lu * rl;
            return ((lu * ru) << 1) + ll * rl + ((mid & Mask30) << 31) + (mid >> 30);   // a * 2^61 ≡ a (mod 2^61 - 1)を使う
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong Multiply(ulong l, uint r)
        {
            var lu = l >> 31;
            var mid = lu * r;
            return (l & Mask31) * r + ((mid & Mask30) << 31) + (mid >> 30); // rの32bit目は0としている
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong CalculateModular(ulong value)
        {
            value = (value & Mod) + (value >> 61);
            if (value >= Mod)
            {
                value -= Mod;
            }
            return value;
        }

        public override string ToString() => RawString;
    }

    public class XorShift
    {
        ulong _x;

        public XorShift() : this((ulong)DateTime.Now.Ticks) { }

        public XorShift(ulong seed)
        {
            _x = seed;
        }

        /// <summary>
        /// [0, (2^64)-1)の乱数を生成します。
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong Next()
        {
            _x = _x ^ (_x << 13);
            _x = _x ^ (_x >> 7);
            _x = _x ^ (_x << 17);
            return _x;
        }

        /// <summary>
        /// [0, <c>exclusiveMax</c>)の乱数を生成します。
        /// </summary>
        /// <param name="exclusiveMax"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Next(int exclusiveMax) => (int)(Next() % (uint)exclusiveMax);

        /// <summary>
        /// [0.0, 1.0)の乱数を生成します。
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double NextDouble()
        {
            const ulong max = 1UL << 50;
            const ulong mask = max - 1;
            return (double)(Next() & mask) / max;
        }
    }

    public static class AlgorithmHelpers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateWhenSmall<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) < 0)
            {
                value = other;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateWhenLarge<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) > 0)
            {
                value = other;
            }
        }
    }

    public class CoordinateShrinker<T> : IEnumerable<(int shrinkedIndex, T rawIndex)> where T : IComparable<T>, IEquatable<T>
    {
        Dictionary<T, int> _shrinkMapper;
        T[] _expandMapper;
        public int Count => _expandMapper.Length;

        public CoordinateShrinker(IEnumerable<T> data)
        {
            _expandMapper = data.Distinct().ToArray();
            Array.Sort(_expandMapper);

            _shrinkMapper = new Dictionary<T, int>();
            for (int i = 0; i < _expandMapper.Length; i++)
            {
                _shrinkMapper.Add(_expandMapper[i], i);
            }
        }

        public int Shrink(T rawCoordinate) => _shrinkMapper[rawCoordinate];
        public T Expand(int shrinkedCoordinate) => _expandMapper[shrinkedCoordinate];

        public IEnumerator<(int shrinkedIndex, T rawIndex)> GetEnumerator()
        {
            for (int i = 0; i < _expandMapper.Length; i++)
            {
                yield return (i, _expandMapper[i]);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

#endregion

#region Collections

namespace ACLBeginnerContest.Collections
{
    // See https://kumikomiya.com/competitive-programming-with-c-sharp/
    public class UnionFindTree
    {
        private UnionFindNode[] _nodes;
        public int Count => _nodes.Length;
        public int Groups { get; private set; }

        public UnionFindTree(int count)
        {
            _nodes = Enumerable.Range(0, count).Select(i => new UnionFindNode(i)).ToArray();
            Groups = _nodes.Length;
        }

        public void Unite(int index1, int index2)
        {
            var succeed = _nodes[index1].Unite(_nodes[index2]);
            if (succeed)
            {
                Groups--;
            }
        }

        public bool IsInSameGroup(int index1, int index2) => _nodes[index1].IsInSameGroup(_nodes[index2]);
        public int GetGroupSizeOf(int index) => _nodes[index].GetGroupSize();

        private class UnionFindNode
        {
            private int _height;        // rootのときのみ有効
            private int _groupSize;     // 同上
            private UnionFindNode _parent;
            public int ID { get; }

            public UnionFindNode(int id)
            {
                _height = 0;
                _groupSize = 1;
                _parent = this;
                ID = id;
            }

            public UnionFindNode FindRoot()
            {
                if (_parent != this) // not ref equals
                {
                    var root = _parent.FindRoot();
                    _parent = root;
                }

                return _parent;
            }

            public int GetGroupSize() => FindRoot()._groupSize;

            public bool Unite(UnionFindNode other)
            {
                var thisRoot = this.FindRoot();
                var otherRoot = other.FindRoot();

                if (thisRoot == otherRoot)
                {
                    return false;
                }

                if (thisRoot._height < otherRoot._height)
                {
                    thisRoot._parent = otherRoot;
                    otherRoot._groupSize += thisRoot._groupSize;
                    otherRoot._height = System.Math.Max(thisRoot._height + 1, otherRoot._height);
                    return true;
                }
                else
                {
                    otherRoot._parent = thisRoot;
                    thisRoot._groupSize += otherRoot._groupSize;
                    thisRoot._height = System.Math.Max(otherRoot._height + 1, thisRoot._height);
                    return true;
                }
            }

            public bool IsInSameGroup(UnionFindNode other) => this.FindRoot() == other.FindRoot();

            public override string ToString() => $"{ID} root:{FindRoot().ID}";
        }
    }

    public class Deque<T> : IReadOnlyCollection<T>
    {
        public int Count { get; private set; }
        private T[] _data;
        private int _first;
        private int _mask;

        public Deque() : this(4) { }

        public Deque(int minCapacity)
        {
            if (minCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minCapacity), $"{nameof(minCapacity)}は0より大きい値でなければなりません。");
            }
            var capacity = GetPow2Over(minCapacity);
            _data = new T[capacity];
            _first = 0;
            _mask = capacity - 1;
        }

        public Deque(IEnumerable<T> collection)
        {
            var dataArray = collection.ToArray();
            var capacity = GetPow2Over(dataArray.Length);
            _data = new T[capacity];
            _first = 0;
            _mask = capacity - 1;

            for (int i = 0; i < dataArray.Length; i++)
            {
                _data[i] = dataArray[i];
                Count++;
            }
        }

        public T this[Index index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var offset = index.GetOffset(Count);
                if (unchecked((uint)offset) >= Count)
                {
                    ThrowArgumentOutOfRangeException(nameof(index), $"{nameof(index)}がコレクションの範囲外です。");
                }
                return _data[(_first + offset) & _mask];
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EnqueueFirst(T item)
        {
            if (_data.Length == Count)
            {
                Resize();
            }

            _first = (_first - 1) & _mask;
            _data[_first] = item;
            Count++;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EnqueueLast(T item)
        {
            if (_data.Length == Count)
            {
                Resize();
            }

            _data[(_first + Count++) & _mask] = item;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DequeueFirst()
        {
            if (Count == 0)
            {
                ThrowInvalidOperationException("Queueが空です。");
            }

            var value = _data[_first];
            _data[_first++] = default;
            _first &= _mask;
            Count--;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T DequeueLast()
        {
            if (Count == 0)
            {
                ThrowInvalidOperationException("Queueが空です。");
            }

            var index = (_first + --Count) & _mask;
            var value = _data[index];
            _data[index] = default;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T PeekFirst()
        {
            if (Count == 0)
            {
                ThrowInvalidOperationException("Queueが空です。");
            }

            return _data[_first];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T PeekLast()
        {
            if (Count == 0)
            {
                ThrowInvalidOperationException("Queueが空です。");
            }

            return _data[(_first + Count - 1) & _mask];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Resize()
        {
            var newArray = new T[_data.Length << 1];
            var span = _data.AsSpan();
            var firstHalf = span[_first..];
            var lastHalf = span[.._first];
            firstHalf.CopyTo(newArray);
            lastHalf.CopyTo(newArray.AsSpan(firstHalf.Length));
            _data = newArray;
            _first = 0;
            _mask = _data.Length - 1;
        }

        private void ThrowArgumentOutOfRangeException(string paramName, string message) => throw new ArgumentOutOfRangeException(paramName, message);
        private void ThrowInvalidOperationException(string message) => throw new InvalidOperationException(message);

        private int GetPow2Over(int n)
        {
            n--;
            var result = 1;
            while (n != 0)
            {
                n >>= 1;
                result <<= 1;
            }
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                var offset = (_first + i) & _mask;
                yield return _data[offset];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private List<T> _heap = new List<T>();
        private readonly int _reverseFactor;
        public int Count => _heap.Count;
        public bool IsDescending => _reverseFactor == 1;

        public PriorityQueue(bool descending) : this(descending, null) { }

        public PriorityQueue(bool descending, IEnumerable<T> collection)
        {
            _reverseFactor = descending ? 1 : -1;
            _heap = new List<T>();

            if (collection != null)
            {
                foreach (var item in collection)
                {
                    Enqueue(item);
                }
            }
        }

        public void Enqueue(T item)
        {
            _heap.Add(item);
            UpHeap();
        }

        public T Dequeue()
        {
            var item = _heap[0];
            DownHeap();
            return item;
        }

        public T Peek() => _heap[0];

        private void UpHeap()
        {
            var child = Count - 1;
            while (child > 0)
            {
                int parent = (child - 1) / 2;

                if (Compare(_heap[child], _heap[parent]) > 0)
                {
                    SwapAt(child, parent);
                    child = parent;
                }
                else
                {
                    break;
                }
            }
        }

        private void DownHeap()
        {
            _heap[0] = _heap[Count - 1];
            _heap.RemoveAt(Count - 1);

            var parent = 0;
            while (true)
            {
                var leftChild = 2 * parent + 1;

                if (leftChild > Count - 1)
                {
                    break;
                }

                var target = (leftChild < Count - 1) && (Compare(_heap[leftChild], _heap[leftChild + 1]) < 0) ? leftChild + 1 : leftChild;

                if (Compare(_heap[parent], _heap[target]) < 0)
                {
                    SwapAt(parent, target);
                }
                else
                {
                    break;
                }

                parent = target;
            }
        }

        private int Compare(T a, T b) => _reverseFactor * a.CompareTo(b);

        private void SwapAt(int n, int m) => (_heap[n], _heap[m]) = (_heap[m], _heap[n]);

        public IEnumerator<T> GetEnumerator()
        {
            var copy = new List<T>(_heap);
            try
            {
                while (Count > 0)
                {
                    yield return Dequeue();
                }
            }
            finally
            {
                _heap = copy;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class SegmentTree<TMonoid> : IEnumerable<TMonoid> where TMonoid : IMonoid<TMonoid>, new()
    {
        private readonly TMonoid[] _data;
        private readonly TMonoid _identityElement;

        private readonly int _leafOffset;   // n - 1
        private readonly int _leafLength;   // n (= 2^k)

        public int Length { get; }          // 実データ長
        public ReadOnlySpan<TMonoid> Data => _data.AsSpan(_leafOffset, Length);

        public SegmentTree(ICollection<TMonoid> data)
        {
            Length = data.Count;
            _leafLength = GetMinimumPow2(data.Count);
            _leafOffset = _leafLength - 1;
            _data = new TMonoid[_leafOffset + _leafLength];
            _identityElement = new TMonoid().Identity;

            data.CopyTo(_data, _leafOffset);
            BuildTree();
        }

        public TMonoid this[int index]
        {
            get => Data[index];
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException($"{nameof(index)}がデータの範囲外です。");
                }
                index += _leafOffset;
                _data[index] = value;
                while (index > 0)
                {
                    // 一つ上の親の更新
                    index = (index - 1) / 2;
                    _data[index] = _data[index * 2 + 1].Merge(_data[index * 2 + 2]);
                }
            }
        }

        public TMonoid Query(Range range)
        {
            var (offset, length) = range.GetOffsetAndLength(Length);
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(range), $"{nameof(range)}の長さは0より大きくなければなりません。");
            }
            return Query(offset, offset + length);
        }

        public TMonoid Query(int begin, int end)
        {
            if (begin < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(begin), $"{nameof(begin)}は0以上の数でなければなりません。");
            }
            if (end > Length)
            {
                throw new ArgumentOutOfRangeException(nameof(end), $"{nameof(end)}は{nameof(Length)}以下でなければなりません。");
            }
            if (begin >= end)
            {
                throw new ArgumentException($"{nameof(begin)},{nameof(end)}", $"{nameof(end)}は{nameof(begin)}より大きい数でなければなりません。");
            }
            return Query(begin, end, 0, 0, _leafLength);
        }

        private TMonoid Query(int begin, int end, int index, int left, int right)
        {
            if (right <= begin || end <= left)      // 範囲外
            {
                return _identityElement;
            }
            else if (begin <= left && right <= end) // 全部含まれる
            {
                return _data[index];
            }
            else    // 一部だけ含まれる
            {
                var leftValue = Query(begin, end, index * 2 + 1, left, (left + right) / 2);     // 左の子
                var rightValue = Query(begin, end, index * 2 + 2, (left + right) / 2, right);   // 右の子
                return leftValue.Merge(rightValue);
            }
        }

        private void BuildTree()
        {
            foreach (ref var unusedLeaf in _data.AsSpan()[(_leafOffset + Length)..])
            {
                unusedLeaf = _identityElement;  // 単位元埋め
            }

            for (int i = _leafLength - 2; i >= 0; i--)  // 葉の親から順番に一つずつ上がっていく
            {
                _data[i] = _data[2 * i + 1].Merge(_data[2 * i + 2]); // f(left, right)
            }
        }

        private int GetMinimumPow2(int n)
        {
            var p = 1;
            while (p < n)
            {
                p *= 2;
            }
            return p;
        }

        public IEnumerator<TMonoid> GetEnumerator()
        {
            var upperIndex = _leafOffset + Length;
            for (int i = _leafOffset; i < upperIndex; i++)
            {
                yield return _data[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
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
                _lazy[left] = _lazy[index].Merge(_lazy[left]);
                _lazy[right] = _lazy[index].Merge(_lazy[right]);
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
                _lazy[index] = _lazy[index].Merge(op);
                LazyEvaluate(index);
            }
            else if (begin < right && left < end) // 一部だけ含まれる
            {
                var l = (index << 1) + 1;
                var r = l + 1;
                Update(begin, end, op, l, left, (left + right) / 2);
                Update(begin, end, op, r, (left + right) / 2, right);
                _data[index] = _data[l].Merge(_data[r]);
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
                return leftValue.Merge(rightValue);
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
                _data[i] = _data[left].Merge(_data[right]); // f(left, right)
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

    public class BinaryIndexedTree
    {
        long[] _data;
        public int Length { get; }

        public BinaryIndexedTree(int length)
        {
            _data = new long[length + 1];   // 内部的には1-indexedにする
            Length = length;
        }

        public BinaryIndexedTree(IEnumerable<long> data, int length) : this(length)
        {
            var count = 0;
            foreach (var n in data)
            {
                AddAt(count++, n);
            }
        }

        public BinaryIndexedTree(ICollection<long> collection) : this(collection, collection.Count) { }

        public long this[Index index]
        {
            get => Sum(index..(index.GetOffset(Length) + 1));
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)}は0以上の値である必要があります。");
                }
                AddAt(index, value - this[index]);
            }
        }

        /// <summary>
        /// BITの<c>index</c>番目の要素に<c>n</c>を加算します。
        /// </summary>
        /// <param name="index">加算するインデックス（0-indexed）</param>
        /// <param name="value">加算する数</param>
        public void AddAt(Index index, long value)
        {
            var i = index.GetOffset(Length);
            unchecked
            {
                if ((uint)i >= (uint)Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
            }

            i++;  // 1-indexedにする

            while (i <= Length)
            {
                _data[i] += value;
                i += i & -i;    // LSBの加算
            }
        }

        /// <summary>
        /// [0, <c>end</c>)の部分和を返します。
        /// </summary>
        /// <param name="end">部分和を求める半開区間の終了インデックス</param>
        /// <returns>区間の部分和</returns>
        public long Sum(Index end)
        {
            var i = end.GetOffset(Length);  // 0-indexedの半開区間＝1-indexedの閉区間なので+1は不要
            unchecked
            {
                if ((uint)i >= (uint)_data.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(end));
                }
            }

            long sum = 0;
            while (i > 0)
            {
                sum += _data[i];
                i -= i & -i;    // LSBの減算
            }
            return sum;
        }

        /// <summary>
        /// <c>range</c>の部分和を返します。
        /// </summary>
        /// <param name="range">部分和を求める半開区間</param>
        /// <returns>区間の部分和</returns>
        public long Sum(Range range) => Sum(range.End) - Sum(range.Start);

        /// <summary>
        /// [<c>start</c>, <c>end</c>)の部分和を返します。
        /// </summary>
        /// <param name="start">部分和を求める半開区間の開始インデックス</param>
        /// <param name="end">部分和を求める半開区間の終了インデックス</param>
        /// <returns>区間の部分和</returns>
        public long Sum(int start, int end) => Sum(end) - Sum(start);

        /// <summary>
        /// [0, <c>index</c>)の部分和が<c>sum</c>未満になる最大の<c>index</c>を返します。
        /// BIT上の各要素は0以上の数である必要があります。
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int GetLowerBound(long sum)
        {
            int index = 0;
            for (int offset = GetMostSignificantBitOf(Length); offset > 0; offset >>= 1)
            {
                if (index + offset < _data.Length && _data[index + offset] < sum)
                {
                    index += offset;
                    sum -= _data[index];
                }
            }

            return index;

            int GetMostSignificantBitOf(int n)
            {
                int k = 1;
                while ((k << 1) <= n)
                {
                    k <<= 1;
                };
                return k;
            }
        }
    }

    public class BinaryIndexedTree2D
    {
        long[,] _data;
        public int Height { get; }
        public int Width { get; }

        public BinaryIndexedTree2D(int height, int width)
        {
            Height = height;
            Width = width;
            _data = new long[height + 1, width + 1];
        }

        public long this[Index row, Index column]
        {
            get => Sum(row..(row.GetOffset(Height) + 1), column..(column.GetOffset(Width) + 1));
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(value)}は0以上の値である必要があります。");
                }
                AddAt(row, column, value - this[row, column]);
            }
        }

        /// <summary>
        /// 2次元BITの[<c>row</c>, <c>column</c>]に<c>value</c>を足します。
        /// </summary>
        /// <param name="row">加算する行（0-indexed）</param>
        /// <param name="column">加算する列（0-indexed）</param>
        /// <param name="value">加算する値</param>
        public void AddAt(Index row, Index column, long value)
        {
            var initI = row.GetOffset(Height);
            var initJ = column.GetOffset(Width);
            unchecked
            {
                if ((ulong)initI >= (ulong)Height)
                {
                    throw new ArgumentOutOfRangeException(nameof(row));
                }
                if ((ulong)initJ >= (ulong)Width)
                {
                    throw new ArgumentOutOfRangeException(nameof(column));
                }
            }

            initI++;    // 1-indexed
            initJ++;

            for (int i = initI; i <= Height; i += i & -i)
            {
                for (int j = initJ; j <= Width; j += j & -j)
                {
                    _data[i, j] += value;
                }
            }
        }

        /// <summary>
        /// 指定した半開区間の部分和を返します。
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public long Sum(Index row, Index column)
        {
            long sum = 0;
            var initI = row.GetOffset(Height);
            var initJ = column.GetOffset(Width);
            unchecked
            {
                if ((ulong)initI >= (ulong)(Height + 1))
                {
                    throw new ArgumentOutOfRangeException(nameof(row));
                }
                if ((ulong)initJ >= (ulong)(Width + 1))
                {
                    throw new ArgumentOutOfRangeException(nameof(column));
                }
            }

            for (int i = initI; i > 0; i -= i & -i)
            {
                for (int j = initJ; j > 0; j -= j & -j)
                {
                    sum += _data[i, j];
                }
            }
            return sum;
        }

        /// <summary>
        /// 指定した半開区間の部分和を返します。
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public long Sum(Range rows, Range columns) => Sum(rows.End, columns.End) - Sum(rows.Start, columns.End) - Sum(rows.End, columns.Start) + Sum(rows.Start, columns.Start);

        /// <summary>
        /// 指定した半開区間の部分和を返します。
        /// </summary>
        /// <param name="beginRow"></param>
        /// <param name="endRow"></param>
        /// <param name="beginColumn"></param>
        /// <param name="endColumn"></param>
        /// <returns></returns>
        public long Sum(int beginRow, int endRow, int beginColumn, int endColumn) => Sum(beginRow..endRow, beginColumn..endColumn);
    }

    /// <summary>
    /// <para>Red-Black tree which allows duplicated values (like multiset).</para>
    /// <para>Based on .NET Runtime https://github.com/dotnet/runtime/blob/master/src/libraries/System.Collections/src/System/Collections/Generic/SortedSet.cs </para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    /// .NET Runtime
    ///   Copyright (c) .NET Foundation and Contributors
    ///   Released under the MIT license
    ///   https://github.com/dotnet/runtime/blob/master/LICENSE.TXT
    public class RedBlackTree<T> : ICollection<T>, IReadOnlyCollection<T> where T : IComparable<T>
    {
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        protected Node _root;

        public T this[Index index]
        {
            get
            {
                var i = index.GetOffset(Count);
                if (unchecked((uint)i) >= Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                var current = _root;
                while (true)
                {
                    var leftCount = current.Left?.Count ?? 0;
                    if (leftCount == i)
                    {
                        return current.Item;
                    }
                    else if (leftCount > i)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        i -= leftCount + 1;
                        current = current.Right;
                    }
                }
            }
        }

        /// <summary>
        /// 最小の要素を返します。要素が空の場合、default値を返します。
        /// </summary>
        public T Min
        {
            get
            {
                if (_root == null)
                {
                    return default;
                }
                else
                {
                    var current = _root;
                    while (current.Left != null)
                    {
                        current = current.Left;
                    }
                    return current.Item;
                }
            }
        }

        /// <summary>
        /// 最大の要素を返します。要素が空の場合、default値を返します。
        /// </summary>
        public T Max
        {
            get
            {
                if (_root == null)
                {
                    return default;
                }
                else
                {
                    var current = _root;
                    while (current.Right != null)
                    {
                        current = current.Right;
                    }
                    return current.Item;
                }
            }
        }

        #region ICollection<T> members

        public void Add(T item)
        {
            if (_root == null)
            {
                _root = new Node(item, NodeColor.Black);
                Count = 1;
                return;
            }

            Node current = _root;
            Node parent = null;
            Node grandParent = null;        // 親、祖父はRotateで直接いじる
            Node greatGrandParent = null;   // 曾祖父はRotate後のつなぎ替えで使う（2回Rotateすると曾祖父がcurrentの親になる）

            var order = 0;
            while (current != null)
            {
                current.Count++;    // 部分木サイズ++
                order = item.CompareTo(current.Item);

                if (current.Is4Node)
                {
                    // 4-node (RBR) の場合は2-node x 2 (BRB) に変更
                    current.Split4Node();
                    if (Node.IsNonNullRed(parent))
                    {
                        // Splitの結果親と2連続でRRになったら修正
                        InsertionBalance(current, ref parent, grandParent, greatGrandParent);
                    }
                }

                greatGrandParent = grandParent;
                grandParent = parent;
                parent = current;
                current = order <= 0 ? current.Left : current.Right;
            }

            var newNode = new Node(item, NodeColor.Red);
            if (order <= 0)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }

            if (parent.IsRed)
            {
                // Redの親がRedのときは修正
                InsertionBalance(newNode, ref parent, grandParent, greatGrandParent);
            }

            _root.Color = NodeColor.Black;  // rootは常にBlack（Red->Blackとなったとき木全体の黒高さが1増える）
            Count++;
        }

        public void Clear()
        {
            _root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = _root;
            while (current != null)
            {
                var order = item.CompareTo(current.Item);
                if (order == 0)
                {
                    return true;
                }
                else
                {
                    current = order <= 0 ? current.Left : current.Right;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var value in this)
            {
                array[arrayIndex++] = value;
            }
        }

        public bool Remove(T item)
        {
            // .NET RuntimeのSortedSet<T>はややトリッキーな実装をしている。
            // 値の検索を行う際、検索パスにある全ての2-nodeを3-nodeまたは4-nodeに変更しつつ進んでいくのだが、
            // 各ノードに部分木のサイズを持たせたい場合、実装が難しくなるため、一般的な実装を用いることとする。
            // （削除が失敗した場合はサイズが変わらず、成功した場合のみサイズが変更となるため、パスを保存しておきたいのだが、
            // 　木を回転させながら検索を行うと木の親子関係が変化するため、パスも都度変更となってしまう。）

            var found = false;
            Node current = _root;
            var parents = new Stack<Node>(2 * Log2(Count + 1));  // 親ノードのスタック
            parents.Push(null); // 番兵

            while (current != null)
            {
                parents.Push(current);
                var order = item.CompareTo(current.Item);
                if (order == 0)
                {
                    found = true;
                    break;
                }
                else
                {
                    current = order < 0 ? current.Left : current.Right;
                }
            }

            if (!found)
            {
                // 見付からなければreturn
                return false;
            }

            // 子を2つ持つ場合
            if (current.Left != null && current.Right != null)
            {
                // 右部分木の最小ノードを探す
                parents.Push(current.Right);
                var minNode = GetMinNode(current.Right, parents);

                // この最小値の値だけもらってしまい、あとはこの最小値ノードを削除することを考えればよい
                current.Item = minNode.Item;
                current = minNode;
            }

            // 通ったパス上にある部分木のサイズを全て1だけデクリメント
            parents.Pop();  // これは今から消すので不要
            Count--;
            foreach (var node in parents)
            {
                if (node != null)
                {
                    node.Count--;
                }
            }

            // 切り離した部分をくっつける。子を2つ持つ場合については上で考えたため、子を0or1つ持つ場合を考えればよい
            // 二分木の黒高さが全て等しいという条件より、片方だけ2個以上伸びているということは起こり得ない
            var parent = parents.Peek();
            ReplaceChildOrRoot(parent, current, current.Left ?? current.Right);  // L/Rのどちらかnullでない方。どちらもnullならnullが入る

            // 削除するノードが赤の場合は修正不要
            if (current.IsRed)
            {
                return true;
            }

            // つなぎ替えられた方の子
            current = current.Left ?? current.Right;

            while ((parent = parents.Pop()) != null)
            {
                var toFix = DeleteBalance(current, parent, out var newParent);
                ReplaceChildOrRoot(parents.Peek(), parent, newParent);

                if (!toFix)
                {
                    break;
                }
                current = newParent;
            }

            if (_root != null)
            {
                _root.Color = NodeColor.Black;
            }
            return true;
        }

        private static Node GetMinNode(Node current, Stack<Node> parents)
        {
            while (current.Left != null)
            {
                current = current.Left;
                parents.Push(current);
            }
            return current;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_root != null)
            {
                var stack = new Stack<Node>(2 * Log2(Count + 1));
                PushLeft(stack, _root);

                while (stack.Count > 0)
                {
                    var current = stack.Pop();
                    yield return current.Item;
                    PushLeft(stack, current.Right);
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        /// <summary>
        /// [inclusiveMin, exclusiveMax)を満たす要素を昇順に列挙します。
        /// </summary>
        /// <param name="inclusiveMin">区間の最小値（それ自身を含む）</param>
        /// <param name="exclusiveMax">区間の最大値（それ自身を含まない）</param>
        /// <returns></returns>
        public IEnumerable<T> EnumerateRange(T inclusiveMin, T exclusiveMax)
        {
            if (_root != null)
            {
                var stack = new Stack<Node>(2 * Log2(Count + 1));
                var current = _root;
                while (current != null)
                {
                    var order = current.Item.CompareTo(inclusiveMin);
                    if (order >= 0)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }

                while (stack.Count > 0)
                {
                    current = stack.Pop();
                    var order = current.Item.CompareTo(exclusiveMax);
                    if (order >= 0)
                    {
                        yield break;
                    }
                    else
                    {
                        yield return current.Item;
                        PushLeft(stack, current.Right);
                    }
                }
            }
        }

        private static void PushLeft(Stack<Node> stack, Node node)
        {
            while (node != null)
            {
                stack.Push(node);
                node = node.Left;
            }
        }

        private static int Log2(int n)
        {
            int result = 0;
            while (n > 0)
            {
                result++;
                n >>= 1;
            }
            return result;
        }

        // After calling InsertionBalance, we need to make sure `current` and `parent` are up-to-date.
        // It doesn't matter if we keep `grandParent` and `greatGrandParent` up-to-date, because we won't
        // need to split again in the next node.
        // By the time we need to split again, everything will be correctly set.
        private void InsertionBalance(Node current, ref Node parent, Node grandParent, Node greatGrandParent)
        {
            Debug.Assert(parent != null);
            Debug.Assert(grandParent != null);

            var parentIsOnRight = grandParent.Right == parent;
            var currentIsOnRight = parent.Right == current;

            Node newChildOfGreatGrandParent;
            if (parentIsOnRight == currentIsOnRight)
            {
                // LL or RRなら1回転でOK
                newChildOfGreatGrandParent = currentIsOnRight ? grandParent.RotateLeft() : grandParent.RotateRight();
            }
            else
            {
                // LR or RLなら2回転
                newChildOfGreatGrandParent = currentIsOnRight ? grandParent.RotateLeftRight() : grandParent.RotateRightLeft();
                // 1回転ごとに1つ上に行くため、2回転させると曾祖父が親になる
                // リンク先「挿入操作」を参照 http://wwwa.pikara.ne.jp/okojisan/rb-tree/index.html
                parent = greatGrandParent;
            }

            // 祖父は親の子（1回転）もしくは自分の子（2回転）のいずれかになる
            // この時点で色がRRBもしくはBRRになっているため、BRBに修正
            // リンク先「挿入操作」を参照 http://wwwa.pikara.ne.jp/okojisan/rb-tree/index.html
            grandParent.Color = NodeColor.Red;
            newChildOfGreatGrandParent.Color = NodeColor.Black;

            ReplaceChildOrRoot(greatGrandParent, grandParent, newChildOfGreatGrandParent);
        }

        private bool DeleteBalance(Node current, Node parent, out Node newParent)
        {
            // 削除パターンは大きく分けて4つ
            // See: http://wwwa.pikara.ne.jp/okojisan/rb-tree/index.html

            // currentはもともと黒なので（黒でなければ修正する必要がないため）、兄弟はnullにはなり得ない
            var sibling = parent.GetSibling(current);
            if (sibling.IsBlack)
            {
                if (Node.IsNonNullRed(sibling.Left) || Node.IsNonNullRed(sibling.Right))
                {
                    var parentColor = parent.Color;
                    var siblingRedChild = Node.IsNonNullRed(sibling.Left) ? sibling.Left : sibling.Right;
                    var currentIsOnRight = parent.Right == current;
                    var siblingRedChildIsRight = sibling.Right == siblingRedChild;

                    if (currentIsOnRight != siblingRedChildIsRight)
                    {
                        // 1回転
                        parent.Color = NodeColor.Black;
                        sibling.Color = parentColor;
                        siblingRedChild.Color = NodeColor.Black;
                        newParent = currentIsOnRight ? parent.RotateRight() : parent.RotateLeft();
                    }
                    else
                    {
                        // 2回転
                        parent.Color = NodeColor.Black;
                        siblingRedChild.Color = parentColor;
                        newParent = currentIsOnRight ? parent.RotateLeftRight() : parent.RotateRightLeft();
                    }

                    return false;
                }
                else
                {
                    var needToFix = parent.IsBlack;
                    parent.Color = NodeColor.Black;
                    sibling.Color = NodeColor.Red;
                    newParent = parent;
                    return needToFix;
                }
            }
            else
            {
                if (current == parent.Right)
                {
                    newParent = parent.RotateRight();
                }
                else
                {
                    newParent = parent.RotateLeft();
                }

                parent.Color = NodeColor.Red;
                sibling.Color = NodeColor.Black;
                DeleteBalance(current, parent, out var newChildOfParent);  // 再帰は1回限り
                ReplaceChildOrRoot(newParent, parent, newChildOfParent);
                return false;
            }
        }

        /// <summary>
        /// 親ノードの子を新しいものに差し替える。ただし親がいなければrootとする。
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="child"></param>
        /// <param name="newChild"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ReplaceChildOrRoot(Node parent, Node child, Node newChild)
        {
            if (parent != null)
            {
                parent.ReplaceChild(child, newChild);
            }
            else
            {
                _root = newChild;
            }
        }

        #region Debugging

        [Conditional("DEBUG")]
        internal void PrintTree() => PrintTree(_root, 0);

        [Conditional("DEBUG")]
        private void PrintTree(Node node, int depth)
        {
            const int Space = 6;
            if (node != null)
            {
                PrintTree(node.Right, depth + 1);
                if (node.IsRed)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(string.Concat(Enumerable.Repeat(' ', Space * depth)));
                    Console.WriteLine($"{node.Item} ({node.Count})");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(string.Concat(Enumerable.Repeat(' ', Space * depth)));
                    Console.WriteLine($"{node.Item} ({node.Count})");
                }
                PrintTree(node.Left, depth + 1);
            }
        }

        [Conditional("DEBUG")]
        internal void AssertCorrectRedBrackTree() => AssertCorrectRedBrackTree(_root);

        private int AssertCorrectRedBrackTree(Node node)
        {
            if (node != null)
            {
                // Redが2つ繋がっていないか？
                Debug.Assert(!(node.IsRed && Node.IsNonNullRed(node.Left)));
                Debug.Assert(!(node.IsRed && Node.IsNonNullRed(node.Right)));

                // 左右の黒高さは等しいか？
                var left = AssertCorrectRedBrackTree(node.Left);
                var right = AssertCorrectRedBrackTree(node.Right);
                Debug.Assert(left == right);
                if (node.IsBlack)
                {
                    left++;
                }
                return left;
            }
            else
            {
                return 0;
            }
        }

        #endregion

        protected enum NodeColor : byte
        {
            Black,
            Red
        }

        [DebuggerDisplay("Item = {Item}, Size = {Count}")]
        protected sealed class Node
        {
            public T Item { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public NodeColor Color { get; set; }
            /// <summary>部分木のサイズ</summary>
            public int Count { get; set; }

            public bool IsBlack => Color == NodeColor.Black;
            public bool IsRed => Color == NodeColor.Red;
            public bool Is2Node => IsBlack && IsNullOrBlack(Left) && IsNullOrBlack(Right);
            public bool Is4Node => IsNonNullRed(Left) && IsNonNullRed(Right);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private void UpdateCount() => Count = GetCountOrDefault(Left) + GetCountOrDefault(Right) + 1;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool IsNonNullBlack(Node node) => node != null && node.IsBlack;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool IsNonNullRed(Node node) => node != null && node.IsRed;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool IsNullOrBlack(Node node) => node == null || node.IsBlack;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static int GetCountOrDefault(Node node) => node?.Count ?? 0;    // C# 6.0 or later

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Node(T item, NodeColor color)
            {
                Item = item;
                Color = color;
                Count = 1;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Split4Node()
            {
                Color = NodeColor.Red;
                Left.Color = NodeColor.Black;
                Right.Color = NodeColor.Black;
            }

            // 各種Rotateでは位置関係だけ修正する。色までは修正しない。
            // 親になったノード（部分木の根）を返り値とする。
            // childとかgrandChildとかは祖父（Rotate前の3世代中一番上）目線での呼び方
            public Node RotateLeft()
            {
                // 右の子が自分の親になる
                var child = Right;
                Right = child.Left;
                child.Left = this;
                UpdateCount();
                child.UpdateCount();
                return child;
            }

            public Node RotateRight()
            {
                // 左の子が自分の親になる
                var child = Left;
                Left = child.Right;
                child.Right = this;
                UpdateCount();
                child.UpdateCount();
                return child;
            }

            public Node RotateLeftRight()
            {
                var child = Left;
                var grandChild = child.Right;

                Left = grandChild.Right;
                grandChild.Right = this;
                child.Right = grandChild.Left;
                grandChild.Left = child;
                UpdateCount();
                child.UpdateCount();
                grandChild.UpdateCount();
                return grandChild;
            }

            public Node RotateRightLeft()
            {
                var child = Right;
                var grandChild = child.Left;

                Right = grandChild.Left;
                grandChild.Left = this;
                child.Left = grandChild.Right;
                grandChild.Right = child;
                UpdateCount();
                child.UpdateCount();
                grandChild.UpdateCount();
                return grandChild;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void ReplaceChild(Node child, Node newChild)
            {
                if (Left == child)
                {
                    Left = newChild;
                }
                else
                {
                    Right = newChild;
                }
            }

            /// <summary>
            /// 兄弟を取得する。
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Node GetSibling(Node node) => node == Left ? Right : Left;

            /// <summary>
            /// 左右の2-nodeを4-nodeにマージする。
            /// </summary>
            public void Merge2Nodes()
            {
                Color = NodeColor.Black;
                Left.Color = NodeColor.Red;
                Right.Color = NodeColor.Red;
            }
        }
    }

    public class Counter<T> : IEnumerable<(T key, long count)> where T : IEquatable<T>
    {
        private Dictionary<T, long> _innerDictionary;

        public Counter()
        {
            _innerDictionary = new Dictionary<T, long>();
        }

        public IEnumerator<(T key, long count)> GetEnumerator()
        {
            foreach (var pair in _innerDictionary)
            {
                yield return (key: pair.Key, count: pair.Value);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        public long this[T key]
        {
            get
            {
                _innerDictionary.TryGetValue(key, out var count);
                return count;
            }
            set
            {
                _innerDictionary[key] = value;
            }
        }
    }

    public readonly struct BitSet : IEquatable<BitSet>
    {
        readonly uint _value;

        public BitSet(uint value)
        {
            _value = value;
        }
        public bool this[int digit]
        {
            get => ((_value >> digit) & 1) > 0;
        }
        public bool Any => _value > 0;
        public bool None => _value == 0;
        public BitSet SetAt(int digit, bool value) => value ? new BitSet(_value | (1u << digit)) : new BitSet(_value & ~(1u << digit));
        public BitSet Lsb() { unchecked { return new BitSet(_value & (uint)-(int)_value); } }
        public BitSet Reverse()
        {
            unchecked
            {
                uint v = _value;
                v = (v & 0x55555555) << 1 | (v >> 1 & 0x55555555);
                v = (v & 0x33333333) << 2 | (v >> 2 & 0x33333333);
                v = (v & 0x0f0f0f0f) << 4 | (v >> 4 & 0x0f0f0f0f);
                v = (v & 0x00ff00ff) << 8 | (v >> 8 & 0x00ff00ff);
                v = (v & 0x0000ffff) << 16 | (v >> 16 & 0x0000ffff);
                return new BitSet(v);
            }
        }
        public int Count()
        {
            unchecked
            {
                // Hardware Intrinsics未使用
                uint v = _value;
                v = (v & 0x55555555) + (v >> 1 & 0x55555555);
                v = (v & 0x33333333) + (v >> 2 & 0x33333333);
                v = (v & 0x0f0f0f0f) + (v >> 4 & 0x0f0f0f0f);
                v = (v & 0x00ff00ff) + (v >> 8 & 0x00ff00ff);
                v = (v & 0x0000ffff) + (v >> 16 & 0x0000ffff);
                return (int)v;
            }
        }

        public static BitSet Zero => new BitSet(0);
        public static BitSet One => new BitSet(1);
        public static BitSet All => new BitSet(~0u);
        public static BitSet At(int digit) => new BitSet(1u << digit);
        public static BitSet CreateMask(int digit) => new BitSet((1u << digit) - 1);
        public static BitSet operator ++(BitSet bitSet) => new BitSet(bitSet._value + 1);
        public static BitSet operator --(BitSet bitSet) => new BitSet(bitSet._value - 1);
        public static BitSet operator ~(BitSet bitSet) => new BitSet(~bitSet._value);
        public static BitSet operator &(BitSet left, BitSet right) => new BitSet(left._value & right._value);
        public static BitSet operator |(BitSet left, BitSet right) => new BitSet(left._value | right._value);
        public static BitSet operator ^(BitSet left, BitSet right) => new BitSet(left._value ^ right._value);
        public static BitSet operator <<(BitSet bitSet, int n) => new BitSet(bitSet._value << n);
        public static BitSet operator >>(BitSet bitSet, int n) => new BitSet(bitSet._value >> n);
        public static bool operator <(BitSet left, BitSet right) => left._value < right._value;
        public static bool operator <=(BitSet left, BitSet right) => left._value <= right._value;
        public static bool operator >(BitSet left, BitSet right) => left._value > right._value;
        public static bool operator >=(BitSet left, BitSet right) => left._value >= right._value;
        public static bool operator ==(BitSet left, BitSet right) => left.Equals(right);
        public static bool operator !=(BitSet left, BitSet right) => !(left == right);
        public static implicit operator uint(BitSet bitSet) => bitSet._value;

        public override bool Equals(object obj) => obj is BitSet set && Equals(set);
        public bool Equals(BitSet other) => _value == other._value;
        public override string ToString() => Convert.ToString(_value, 2);
        public override int GetHashCode() => _value.GetHashCode();
    }

    public class ExpandableArray<T>
    {
        const int DefaultCapacity = 4;
        private T[] _data;
        public Span<T> Span => _data.AsSpan(0, Count);

        public int Count { get; private set; }

        public ExpandableArray() => Allocate(DefaultCapacity);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ExpandableArray(int capacity)
        {
            capacity = System.Math.Max(capacity, DefaultCapacity);
            Allocate(capacity);
        }

        public ExpandableArray(IEnumerable<T> collection)
        {
            if (collection is ICollection<T> c)
            {
                Allocate(c.Count);
                c.CopyTo(_data, 0);
                Count = c.Count;
            }
            else
            {
                Allocate(DefaultCapacity);
                foreach (var item in collection)
                {
                    Add(item);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Allocate(int minCapacity)
        {
            var length = 1 << System.Numerics.BitOperations.Log2((uint)(minCapacity - 1)) + 1;
            _data = new T[length];
        }

        public T this[Index index]
        {
            get => Span[index];
            set => Span[index] = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(T item)
        {
            if (Count == _data.Length)
            {
                Expand();
            }

            _data[Count++] = item;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemoveLast()
        {
            if (Count == 0)
            {
                ThrowInvalidOperationException("要素が空です。");
            }

            _data[Count--] = default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Expand()
        {
            var length = _data.Length << 1;
            var newData = new T[length];
            Span.CopyTo(newData);
            _data = newData;
        }

        private static void ThrowInvalidOperationException(string message) => throw new InvalidOperationException(message);
        public override string ToString() => $"{nameof(T)}[{Count}]";
        public static implicit operator Span<T>(ExpandableArray<T> array) => array.Span;
        public static implicit operator ReadOnlySpan<T>(ExpandableArray<T> array) => array.Span;
    }

    public static class SearchExtensions
    {
        class LowerBoundComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y) => 0 <= x.CompareTo(y) ? 1 : -1;
        }

        class UpperBoundComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y) => 0 < x.CompareTo(y) ? 1 : -1;
        }

        // https://trsing.hatenablog.com/entry/2019/08/27/211038
        public static int GetGreaterEqualIndex<T>(this ReadOnlySpan<T> span, T inclusiveMin) where T : IComparable<T> => ~span.BinarySearch(inclusiveMin, new UpperBoundComparer<T>());
        public static int GetGreaterThanIndex<T>(this ReadOnlySpan<T> span, T exclusiveMin) where T : IComparable<T> => ~span.BinarySearch(exclusiveMin, new LowerBoundComparer<T>());
        public static int GetLessEqualIndex<T>(this ReadOnlySpan<T> span, T inclusiveMax) where T : IComparable<T> => ~span.BinarySearch(inclusiveMax, new LowerBoundComparer<T>()) - 1;
        public static int GetLessThanIndex<T>(this ReadOnlySpan<T> span, T exclusiveMax) where T : IComparable<T> => ~span.BinarySearch(exclusiveMax, new UpperBoundComparer<T>()) - 1;
        public static int GetGreaterEqualIndex<T>(this Span<T> span, T inclusiveMin) where T : IComparable<T> => ((ReadOnlySpan<T>)span).GetGreaterEqualIndex(inclusiveMin);
        public static int GetGreaterThanIndex<T>(this Span<T> span, T exclusiveMin) where T : IComparable<T> => ((ReadOnlySpan<T>)span).GetGreaterThanIndex(exclusiveMin);
        public static int GetLessEqualIndex<T>(this Span<T> span, T inclusiveMax) where T : IComparable<T> => ((ReadOnlySpan<T>)span).GetLessEqualIndex(inclusiveMax);
        public static int GetLessThanIndex<T>(this Span<T> span, T exclusiveMax) where T : IComparable<T> => ((ReadOnlySpan<T>)span).GetLessThanIndex(exclusiveMax);

        public static int BoundaryBinarySearch(Predicate<int> predicate, int ok, int ng)
        {
            // めぐる式二分探索
            while (System.Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;
                if (predicate(mid))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
        }

        public static long BoundaryBinarySearch(Predicate<long> predicate, long ok, long ng)
        {
            while (System.Math.Abs(ok - ng) > 1)
            {
                long mid = (ok + ng) / 2;
                if (predicate(mid))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }
            return ok;
        }

        public static double Bisection(Func<double, double> f, double a, double b, double eps = 1e-9)
        {
            if (f(a) * f(b) >= 0)
            {
                throw new ArgumentException("f(a)とf(b)は異符号である必要があります。");
            }

            const int maxLoop = 100;
            double mid = (a + b) / 2;

            for (int i = 0; i < maxLoop; i++)
            {
                if (f(a) * f(mid) < 0)
                {
                    b = mid;
                }
                else
                {
                    a = mid;
                }
                mid = (a + b) / 2;
                if (System.Math.Abs(b - a) < eps)
                {
                    break;
                }
            }
            return mid;
        }
    }

    public static class PermutationAlgorithms
    {
        public static IEnumerable<ReadOnlyMemory<T>> GetPermutations<T>(IEnumerable<T> collection) where T : IComparable<T> => GetPermutations(collection, false);

        public static IEnumerable<ReadOnlyMemory<T>> GetPermutations<T>(IEnumerable<T> collection, bool isSorted) where T : IComparable<T>
        {
            var a = collection.ToArray();

            if (!isSorted && a.Length > 1)
            {
                Array.Sort(a);
            }

            yield return a; // ソート済み初期配列

            if (a.Length <= 2)
            {
                if (a.Length == 2 && a[0].CompareTo(a[1]) != 0)
                {
                    (a[0], a[1]) = (a[1], a[0]);
                    yield return a;
                    yield break;
                }

                yield break;
            }

            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = a.Length - 2; i >= 0; i--)
                {
                    // iよりi+1の方が大きい（昇順）なら
                    if (a[i].CompareTo(a[i + 1]) < 0)
                    {
                        // 後ろから見ていってi<jとなるところを探して
                        int j;
                        for (j = a.Length - 1; a[i].CompareTo(a[j]) >= 0; j--) { }

                        // iとjを入れ替えて
                        (a[i], a[j]) = (a[j], a[i]);

                        // i+1以降を反転
                        if (i < a.Length - 2)
                        {
                            var sliced = a.AsSpan().Slice(i + 1);
                            sliced.Reverse();
                        }

                        flag = true;
                        yield return a;
                        break;
                    }
                }
            }
        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<(T1 v1, T2 v2)> Zip<T1, T2>(this (IEnumerable<T1> First, IEnumerable<T2> Second) t)
            => t.First.Zip(t.Second, (v1, v2) => (v1, v2));

        public static IEnumerable<(T1 v1, T2 v2, T3 v3)> Zip<T1, T2, T3>(this (IEnumerable<T1> First, IEnumerable<T2> Second, IEnumerable<T3> Third) t)
            => (t.First, t.Second).Zip().Zip(t.Third, (v12, v3) => (v12.v1, v12.v2, v3));

        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source) => source.Select((item, index) => (item, index));
    }

    public static class ArrayExtensions
    {
        public static T[,] Fill<T>(this T[,] array, T value)
        {
            var length0 = array.GetLength(0);
            var length1 = array.GetLength(1);
            for (int i = 0; i < length0; i++)
                for (int j = 0; j < length1; j++)
                    array[i, j] = value;
            return array;
        }

        public static T[,,] Fill<T>(this T[,,] array, T value)
        {
            var length0 = array.GetLength(0);
            var length1 = array.GetLength(1);
            var length2 = array.GetLength(2);
            for (int i = 0; i < length0; i++)
                for (int j = 0; j < length1; j++)
                    for (int k = 0; k < length2; k++)
                        array[i, j, k] = value;
            return array;
        }

        public static T[,,,] Fill<T>(this T[,,,] array, T value)
        {
            var length0 = array.GetLength(0);
            var length1 = array.GetLength(1);
            var length2 = array.GetLength(2);
            var length3 = array.GetLength(3);
            for (int i = 0; i < length0; i++)
                for (int j = 0; j < length1; j++)
                    for (int k = 0; k < length2; k++)
                        for (int l = 0; l < length3; l++)
                            array[i, j, k, l] = value;
            return array;
        }
    }
}

#endregion

#region Graphs

namespace ACLBeginnerContest.Graphs
{
    public interface IEdge
    {
        int To { get; }
    }

    public interface IWeightedEdge : IEdge
    {
        long Weight { get; }
    }

    public interface IGraph<TEdge> where TEdge : IEdge
    {
        ReadOnlySpan<TEdge> this[int node] { get; }
        int NodeCount { get; }
    }

    public interface IWeightedGraph<TEdge> : IGraph<TEdge> where TEdge : IWeightedEdge { }

    public readonly struct BasicEdge : IEdge
    {
        public int To { get; }

        public BasicEdge(int to)
        {
            To = to;
        }

        public override string ToString() => To.ToString();
        public static implicit operator BasicEdge(int edge) => new BasicEdge(edge);
        public static implicit operator int(BasicEdge edge) => edge.To;
    }

    [StructLayout(LayoutKind.Auto)]
    public readonly struct WeightedEdge : IWeightedEdge
    {
        public int To { get; }
        public long Weight { get; }

        public WeightedEdge(int to) : this(to, 1) { }

        public WeightedEdge(int to, long weight)
        {
            To = to;
            Weight = weight;
        }

        public override string ToString() => $"[{Weight}]-->{To}";
        public void Deconstruct(out int to, out long weight) => (to, weight) = (To, Weight);
    }

    public class BasicGraph : IGraph<BasicEdge>
    {
        private readonly ExpandableArray<ExpandableArray<BasicEdge>> _edges;
        public ReadOnlySpan<BasicEdge> this[int node] => _edges[node].Span;
        public int NodeCount => _edges.Count;

        public BasicGraph(int nodeCount)
        {
            _edges = new ExpandableArray<ExpandableArray<BasicEdge>>(nodeCount);
            for (int i = 0; i < nodeCount; i++)
            {
                _edges.Add(new ExpandableArray<BasicEdge>());
            }
        }

        public void AddEdge(int from, int to) => _edges[from].Add(to);
        public void AddNode() => _edges.Add(new ExpandableArray<BasicEdge>());
    }

    public class WeightedGraph : IGraph<WeightedEdge>
    {
        private readonly ExpandableArray<ExpandableArray<WeightedEdge>> _edges;
        public ReadOnlySpan<WeightedEdge> this[int node] => _edges[node].Span;
        public int NodeCount => _edges.Count;

        public WeightedGraph(int nodeCount)
        {
            _edges = new ExpandableArray<ExpandableArray<WeightedEdge>>(nodeCount);
            for (int i = 0; i < nodeCount; i++)
            {
                _edges.Add(new ExpandableArray<WeightedEdge>());
            }
        }

        public void AddEdge(int from, int to, long weight) => _edges[from].Add(new WeightedEdge(to, weight));
        public void AddNode() => _edges.Add(new ExpandableArray<WeightedEdge>());
    }

    namespace Algorithms
    {
        public class Dijkstra
        {
            private readonly WeightedGraph _graph;

            public Dijkstra(WeightedGraph graph)
            {
                _graph = graph;
            }

            public long[] GetDistancesFrom(int startNode)
            {
                const long Inf = 1L << 60;
                var distances = Enumerable.Repeat(Inf, _graph.NodeCount).ToArray();
                distances[startNode] = 0;
                var todo = new PriorityQueue<State>(false);
                todo.Enqueue(new State(startNode, 0));

                while (todo.Count > 0)
                {
                    var current = todo.Dequeue();
                    if (current.Distance > distances[current.Node])
                    {
                        continue;
                    }

                    foreach (var edge in _graph[current.Node])
                    {
                        var nextDistance = current.Distance + edge.Weight;
                        if (distances[edge.To] > nextDistance)
                        {
                            distances[edge.To] = nextDistance;
                            todo.Enqueue(new State(edge.To, nextDistance));
                        }
                    }
                }

                return distances;
            }

            private readonly struct State : IComparable<State>
            {
                public int Node { get; }
                public long Distance { get; }

                public State(int node, long distance)
                {
                    Node = node;
                    Distance = distance;
                }

                public int CompareTo(State other) => Distance.CompareTo(other.Distance);
                public void Deconstruct(out int node, out long distance) => (node, distance) = (Node, Distance);
            }
        }

        public class BellmanFord
        {
            private readonly ExpandableArray<Edge> _edges = new ExpandableArray<Edge>();
            protected readonly int _nodeCount;

            public BellmanFord(int nodeCount)
            {
                _nodeCount = nodeCount;
            }

            public BellmanFord(WeightedGraph graph)
            {
                _nodeCount = graph.NodeCount;

                for (int from = 0; from < graph.NodeCount; from++)
                {
                    foreach (var edge in graph[from])
                    {
                        AddEdge(from, edge.To, edge.Weight);
                    }
                }
            }


            public void AddEdge(int from, int to, long weight) => _edges.Add(new Edge(from, to, weight));

            public (long[] distances, bool[] isNegativeCycle) GetDistancesFrom(int startNode)
            {
                const long Inf = long.MaxValue >> 1;
                var distances = new long[_nodeCount];
                distances.AsSpan().Fill(Inf);
                var isNegativeCycle = new bool[_nodeCount];
                distances[startNode] = 0;

                for (int i = 1; i <= 2 * _nodeCount; i++)
                {
                    foreach (var edge in _edges.Span)
                    {
                        // そもそも出発点に未到達なら無視
                        if (distances[edge.From] < Inf)
                        {
                            if (i <= _nodeCount)
                            {
                                var newCost = distances[edge.From] + edge.Weight;
                                if (distances[edge.To] > newCost)
                                {
                                    distances[edge.To] = newCost;
                                    // N回目に更新されたやつにチェックを付けて、追加でN回伝播させる
                                    if (i == _nodeCount)
                                    {
                                        isNegativeCycle[edge.To] = true;
                                    }
                                }
                            }
                            else if (isNegativeCycle[edge.From])
                            {
                                isNegativeCycle[edge.To] = true;
                            }
                        }
                    }
                }

                // 一応キレイにしておく
                for (int i = 0; i < _nodeCount; i++)
                {
                    if (isNegativeCycle[i])
                    {
                        distances[i] = long.MinValue;
                    }
                    else if (distances[i] >= Inf)
                    {
                        distances[i] = long.MaxValue;
                    }
                }

                return (distances, isNegativeCycle);
            }

            [StructLayout(LayoutKind.Auto)]
            readonly struct Edge
            {
                public int From { get; }
                public int To { get; }
                public long Weight { get; }

                public Edge(int from, int to, long cost)
                {
                    From = from;
                    To = to;
                    Weight = cost;
                }

                public void Deconstruct(out int from, out int to, out long cost) => (from, to, cost) = (From, To, Weight);
                public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}, {nameof(Weight)}: {Weight}";
            }
        }

        public interface ITreeDpState<TSet> : IMonoid<TSet> where TSet : ITreeDpState<TSet>, new()
        {
            public TSet AddRoot();
        }

        public class Rerooting<TEdge, TDp> where TEdge : IEdge where TDp : unmanaged, ITreeDpState<TDp>
        {
            readonly IGraph<TEdge> _graph;
            readonly TDp _identity;
            readonly TDp[][] _dp;
            readonly TDp[] _result;

            public Rerooting(IGraph<TEdge> graph)
            {
                _graph = graph;
                _identity = new TDp().Identity;
                _dp = new TDp[graph.NodeCount][];
                _result = new TDp[_graph.NodeCount];
                _result.AsSpan().Fill(_identity);
            }

            public TDp[] Solve()
            {
                DepthFirstSearch(0, -1);
                Reroot(0, -1, _identity);
                return _result;
            }

            private TDp DepthFirstSearch(int current, int parent)
            {
                var sum = _identity;
                _dp[current] = new TDp[_graph[current].Length];

                var edges = _graph[current];

                for (int i = 0; i < edges.Length; i++)
                {
                    var next = edges[i].To;
                    if (next == parent)
                        continue;
                    _dp[current][i] = DepthFirstSearch(next, current);
                    sum = sum.Merge(_dp[current][i]);
                }

                return sum.AddRoot();
            }

            private void Reroot(int current, int parent, TDp toAdd)
            {
                var edges = _graph[current];
                for (int i = 0; i < edges.Length; i++)
                {
                    if (edges[i].To == parent)
                    {
                        _dp[current][i] = toAdd;
                        break;
                    }
                }

                var dp = GetPrefixSum(current, edges);

                for (int i = 0; i < edges.Length; i++)
                {
                    var next = edges[i].To;
                    if (next == parent)
                        continue;
                    Reroot(next, current, dp[i].AddRoot());
                }
            }

            private TDp[] GetPrefixSum(int root, ReadOnlySpan<TEdge> edges)
            {
                const int StackallocLimit = 512;

                // 左右からの累積和
                int sumSize = edges.Length + 1;
                Span<TDp> sumLeft = sumSize <= StackallocLimit ? stackalloc TDp[sumSize] : new TDp[sumSize];
                Span<TDp> sumRight = sumSize <= StackallocLimit ? stackalloc TDp[sumSize] : new TDp[sumSize];

                sumLeft[0] = _identity;
                for (int i = 0; i < edges.Length; i++)
                {
                    sumLeft[i + 1] = sumLeft[i].Merge(_dp[root][i]);
                }

                sumRight[^1] = _identity;
                for (int i = edges.Length - 1; i >= 0; i--)
                {
                    sumRight[i] = sumRight[i + 1].Merge(_dp[root][i]);
                }

                // 頂点vの答え
                _result[root] = sumLeft[^1].AddRoot();

                // 頂点iを除いた累積
                var dp = new TDp[edges.Length];
                for (int i = 0; i < dp.Length; i++)
                {
                    dp[i] = sumLeft[i].Merge(sumRight[i + 1]);
                }

                return dp;
            }
        }
    }
}

#endregion
