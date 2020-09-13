using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200909.Algorithms;
using Training20200909.Collections;
using Training20200909.Extensions;
using Training20200909.Numerics;
using Training20200909.Questions;
using System.Diagnostics;
using AtCoder;

namespace Training20200909.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/practice2/tasks/practice2_h
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, d) = inputStream.ReadValue<int, int>();
            var flags = new Flag[n];
            var twoSat = new TwoSat(n);

            for (int i = 0; i < flags.Length; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                flags[i] = new Flag(x, y);
            }

            for (int i = 0; i < flags.Length; i++)
            {
                for (int j = i + 1; j < flags.Length; j++)
                {
                    if (Math.Abs(flags[i].X - flags[j].X) < d)
                    {
                        twoSat.AddClause(i, false, j, false);
                    }
                    if (Math.Abs(flags[i].X - flags[j].Y) < d)
                    {
                        twoSat.AddClause(i, false, j, true);
                    }
                    if (Math.Abs(flags[i].Y - flags[j].X) < d)
                    {
                        twoSat.AddClause(i, true, j, false);
                    }
                    if (Math.Abs(flags[i].Y - flags[j].Y) < d)
                    {
                        twoSat.AddClause(i, true, j, true);
                    }
                }
            }

            var canPlace = twoSat.Satisfiable();

            if (canPlace)
            {
                yield return "Yes";
                var results = twoSat.Answer();
                for (int i = 0; i < results.Length; i++)
                {
                    yield return results[i] ? flags[i].X : flags[i].Y;
                }
            }
            else
            {
                yield return "No";
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Flag
        {
            public int X { get; }
            public int Y { get; }

            public Flag(int x, int y)
            {
                X = x;
                Y = y;
            }

            public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);
            public override string ToString() => $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
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
