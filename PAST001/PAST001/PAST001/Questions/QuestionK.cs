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
using PAST001.Algorithms;
using PAST001.Collections;
using PAST001.Numerics;
using PAST001.Questions;
using PAST001.Graphs;

namespace PAST001.Questions
{
    public class QuestionK : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var tree = new BasicGraph(n);
            var root = -1;

            for (int i = 0; i < n; i++)
            {
                var p = io.ReadInt();

                if (p == -1)
                {
                    root = i;
                }
                else
                {
                    p--;
                    tree.AddEdge(p, i);
                }
            }

            var lca = new LowestCommonAncester(tree, root);

            var queries = io.ReadInt();

            for (int q = 0; q < queries; q++)
            {
                var staff = io.ReadInt() - 1;
                var boss = io.ReadInt() - 1;

                if (lca.GetLcaNode(staff, boss) == boss)
                {
                    io.WriteLine("Yes");
                }
                else
                {
                    io.WriteLine("No");
                }
            }
        }

        /// <summary>
        /// LCAを求めるクラス。
        /// </summary>
        public class LowestCommonAncester
        {
            readonly int[,] _parents;
            readonly int[] _depths;
            readonly int _ceilLog2;

            public ReadOnlySpan<int> Depths => _depths;

            public LowestCommonAncester(BasicGraph graph, int root = 0)
            {
                if (graph.NodeCount == 0)
                {
                    throw new ArgumentException();
                }

                _ceilLog2 = BitOperations.Log2((uint)(graph.NodeCount - 1)) + 1;
                _parents = new int[_ceilLog2, graph.NodeCount];
                for (int i = 0; i < _ceilLog2; i++)
                {
                    for (int j = 0; j < graph.NodeCount; j++)
                    {
                        _parents[i, j] = -1;
                    }
                }
                _depths = new int[graph.NodeCount];
                _depths.AsSpan().Fill(-1);

                Dfs(root, -1, 0);
                Initialize();

                void Dfs(int current, int parent, int depth)
                {
                    _parents[0, current] = parent;
                    _depths[current] = depth;

                    foreach (var next in graph[current])
                    {
                        if (next != parent)
                        {
                            Dfs(next, current, depth + 1);
                        }
                    }
                }

                void Initialize()
                {
                    for (int pow = 0; pow + 1 < _ceilLog2; pow++)
                    {
                        for (int v = 0; v < _depths.Length; v++)
                        {
                            if (_parents[pow, v] < 0)
                            {
                                _parents[pow + 1, v] = -1;
                            }
                            else
                            {
                                _parents[pow + 1, v] = _parents[pow, _parents[pow, v]];
                            }
                        }
                    }
                }
            }

            public int GetLcaNode(int u, int v)
            {
                if (unchecked((uint)u >= (uint)_depths.Length || (uint)v >= (uint)_depths.Length))
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (_depths[u] < _depths[v])
                {
                    (u, v) = (v, u);
                }

                for (int pow = 0; pow < _ceilLog2; pow++)
                {
                    var depthDiff = _depths[u] - _depths[v];
                    if (((depthDiff >> pow) & 1) > 0)
                    {
                        u = _parents[pow, u];
                    }
                }

                if (u == v)
                {
                    return u;
                }
                else
                {
                    for (int pow = _ceilLog2 - 1; pow >= 0; pow--)
                    {
                        if (_parents[pow, u] != _parents[pow, v])
                        {
                            u = _parents[pow, u];
                            v = _parents[pow, v];
                        }
                    }

                    return _parents[0, u];
                }
            }
        }
    }
}
