using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using Training20201026.Algorithms;
using Training20201026.Collections;
using Training20201026.Numerics;
using Training20201026.Questions;
using Training20201026.Graphs;

namespace Training20201026.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            const string Inf = "zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz";
            var n = io.ReadInt();
            var edgeCount = io.ReadInt();
            var length = io.ReadInt();
            var originalCharList = new char[n];

            for (int i = 0; i < originalCharList.Length; i++)
            {
                originalCharList[i] = io.ReadChar();
            }

            var originalGraph = new Internal.SCCGraph(n);
            var edges = new Edge[edgeCount];

            for (int i = 0; i < edges.Length; i++)
            {
                var a = io.ReadInt();
                var b = io.ReadInt();
                a--;
                b--;
                edges[i] = new Edge(a, b);
                originalGraph.AddEdge(a, b);
            }

            var (groupCount, ids) = originalGraph.SCCIDs();
            var graph = new BasicGraph(groupCount + 1);

            foreach (var (from, to) in edges)
            {
                if (ids[from] != ids[to])
                {
                    var contains = false;

                    foreach (var next in graph[ids[from] + 1])
                    {
                        contains |= next == ids[to] + 1;
                    }

                    if (!contains)
                    {
                        graph.AddEdge(ids[from] + 1, ids[to] + 1);
                    }
                }
            }

            for (int i = 1; i < graph.NodeCount; i++)
            {
                graph.AddEdge(0, i);
            }

            var dp = new string[graph.NodeCount, length + 1];
            dp.Fill(Inf);
            dp[0, 0] = "";

            var charList = Enumerable.Repeat(0, graph.NodeCount).Select(_ => new List<char>()).ToArray();

            for (int i = 0; i < originalCharList.Length; i++)
            {
                charList[ids[i] + 1].Add(originalCharList[i]);
            }

            foreach (var c in charList)
            {
                c.Sort();
            }

            for (int i = 0; i < graph.NodeCount; i++)
            {
                for (int l = 0; l <= length; l++)
                {
                    foreach (var next in graph[i])
                    {
                        var newString = dp[i, l];

                        if (newString == Inf)
                        {
                            continue;
                        }

                        ChangeMin(ref dp[next, l], newString);

                        for (int append = 0; append < charList[next].Count; append++)
                        {
                            newString += charList[next][append];

                            if (newString.Length <= length)
                            {
                                ChangeMin(ref dp[next, newString.Length], newString);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            var result = Inf;

            for (int i = 0; i < graph.NodeCount; i++)
            {
                ChangeMin(ref result, dp[i, length]);
            }

            if (result != Inf)
            {
                io.WriteLine(result);
            }
            else
            {
                io.WriteLine(-1);
            }
        }

        void ChangeMin(ref string a, string b)
        {
            if (string.CompareOrdinal(a, b) > 0)
            {
                a = b;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Edge
        {
            public readonly int From;
            public readonly int To;

            public Edge(int from, int to)
            {
                From = from;
                To = to;
            }

            public void Deconstruct(out int from, out int to) => (from, to) = (From, To);
            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}";
        }
    }

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

    namespace Internal
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
}
