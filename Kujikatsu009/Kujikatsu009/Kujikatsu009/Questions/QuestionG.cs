using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu009.Algorithms;
using Kujikatsu009.Collections;
using Kujikatsu009.Extensions;
using Kujikatsu009.Numerics;
using Kujikatsu009.Questions;
using Kujikatsu009.Graphs;
using System.Collections.Immutable;

namespace Kujikatsu009.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc133/tasks/abc133_f
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        ColoredGraph tree;
        int[,] parents;
        int[] depthes;
        long[] distances;
        ImmutableList<ColorInfo>[] colorInfo;
        const int logV = 20;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodes, queries) = inputStream.ReadValue<int, int>();
            tree = new ColoredGraph(nodes);

            for (int i = 0; i < nodes - 1; i++)
            {
                var (a, b, c, d) = inputStream.ReadValue<int, int, int, int>();
                a--;
                b--;
                tree.AddEdge(new ColoredEdge(a, b, d, c));
                tree.AddEdge(new ColoredEdge(b, a, d, c));
            }

            parents = new int[logV, nodes].SetAll((i, j) => -1);
            depthes = new int[nodes];
            distances = new long[nodes];
            colorInfo = new ImmutableList<ColorInfo>[nodes];
            colorInfo[0] = ImmutableList.Create(Enumerable.Repeat(new ColorInfo(0, 0), nodes).ToArray());
            Dfs(0, -1, 0, 0);
            Doubling();

            for (int q = 0; q < queries; q++)
            {
                var (color, afterLength, from, to) = inputStream.ReadValue<int, int, int, int>();
                from--;
                to--;

                var lca = GetLca(from, to);
                var distance = distances[from] + distances[to] - 2 * distances[lca];

                var fromColor = colorInfo[from][color];
                var toColor = colorInfo[to][color];
                var lcaColor = colorInfo[lca][color];

                var diff = (fromColor.Count * afterLength - fromColor.TotalDistance) + (toColor.Count * afterLength - toColor.TotalDistance) 
                    - 2 * (lcaColor.Count * afterLength - lcaColor.TotalDistance);

                yield return distance + diff;
            }
        }

        void Dfs(int current, int parent, int depth, long distance)
        {
            parents[0, current] = parent;
            depthes[current] = depth;
            distances[current] = distance;

            foreach (var edge in tree[current])
            {
                if (edge.To.Index == parent)
                {
                    continue;
                }

                var beforeColor = colorInfo[current][edge.Color];
                colorInfo[edge.To.Index] = colorInfo[current].SetItem(edge.Color, new ColorInfo(beforeColor.TotalDistance + edge.Weight, beforeColor.Count + 1));
                Dfs(edge.To.Index, current, depth + 1, distance + edge.Weight);
            }
        }

        void Doubling()
        {
            var length0 = parents.GetLength(0);
            var length1 = parents.GetLength(1);
            for (int d = 0; d + 1 < length0; d++)
            {
                for (int node = 0; node < length1; node++)
                {
                    if (parents[d, node] < 0)
                    {
                        parents[d + 1, node] = -1;
                    }
                    else
                    {
                        parents[d + 1, node] = parents[d, parents[d, node]];
                    }
                }
            }
        }

        int GetLca(int u, int v)
        {
            if (depthes[u] > depthes[v])
            {
                Swap(ref u, ref v);
            }

            for (int i = 0; i < logV; i++)
            {
                if ((((depthes[v] - depthes[u]) >> i) & 1) > 0)
                {
                    v = parents[i, v];
                }
            }

            if (u == v)
            {
                return u;
            }

            for (int i = logV - 1; i >= 0; i--)
            {
                if (parents[i, u] != parents[i, v])
                {
                    u = parents[i, u];
                    v = parents[i, v];
                }
            }

            return parents[0, u];
        }

        void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        [StructLayout(LayoutKind.Auto)]
        public readonly struct ColoredEdge : IWeightedEdge<BasicNode>
        {
            public BasicNode From { get; }
            public BasicNode To { get; }
            public long Weight { get; }
            public int Color { get; }

            public ColoredEdge(int from, int to, long weight, int color)
            {
                From = from;
                To = to;
                Weight = weight;
                Color = color;
            }

            public override string ToString() => $"{From}--[{Weight}]-->{To}";
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct ColorInfo
        {
            public long TotalDistance { get; }
            public int Count { get; }

            public ColorInfo(long distance, int count)
            {
                TotalDistance = distance;
                Count = count;
            }

            public override string ToString() => $"{nameof(TotalDistance)}: {TotalDistance}, {nameof(Count)}: {Count}";
        }

        public class ColoredGraph : IGraph<BasicNode, ColoredEdge>
        {
            private readonly List<ColoredEdge>[] _edges;
            public IEnumerable<ColoredEdge> this[BasicNode node] => _edges[node.Index];
            public IEnumerable<ColoredEdge> Edges => Nodes.SelectMany(node => this[node]);
            public IEnumerable<BasicNode> Nodes => Enumerable.Range(0, NodeCount).Select(i => new BasicNode(i));
            public int NodeCount { get; }

            public ColoredGraph(int nodeCount) : this(nodeCount, Enumerable.Empty<ColoredEdge>()) { }

            public ColoredGraph(int nodeCount, IEnumerable<ColoredEdge> edges)
            {
                _edges = Enumerable.Repeat(0, nodeCount).Select(_ => new List<ColoredEdge>()).ToArray();
                NodeCount = nodeCount;
                foreach (var edge in edges)
                {
                    AddEdge(edge);
                }
            }

            public void AddEdge(ColoredEdge edge) => _edges[edge.From.Index].Add(edge);
        }

    }
}
