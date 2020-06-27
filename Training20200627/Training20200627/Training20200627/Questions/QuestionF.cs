using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200627.Algorithms;
using Training20200627.Collections;
using Training20200627.Extensions;
using Training20200627.Numerics;
using Training20200627.Questions;
using Training20200627.Graphs;
using Training20200627.Graphs.Algorithms;

namespace Training20200627.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc014/tasks/abc014_4
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        BasicGraph tree;
        List<DepthAndIndex> depthAndIndices;
        int[] depthes;
        int[] firstIndices;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            tree = new BasicGraph(n);
            for (int i = 0; i < n - 1; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                x--;
                y--;
                tree.AddEdge(new BasicEdge(x, y));
                tree.AddEdge(new BasicEdge(y, x));
            }

            depthAndIndices = new List<DepthAndIndex>();
            firstIndices = new int[n];
            depthes = new int[n];

            EularTour(new BasicNode(0), new BasicNode(-1), 0);
            var segTree = new SegmentTree<DepthAndIndex>(depthAndIndices);

            var queries = inputStream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;

                var indexA = firstIndices[a];
                var indexB = firstIndices[b];
                if (indexA > indexB)
                {
                    (indexA, indexB) = (indexB, indexA);
                }
                var lca = segTree.Query(indexA, indexB + 1).Index;
                yield return depthes[a] + depthes[b] - 2 * depthes[lca] + 1;
            }
        }

        void EularTour(BasicNode current, BasicNode before, int depth)
        {
            firstIndices[current.Index] = depthAndIndices.Count;
            depthAndIndices.Add(new DepthAndIndex(depth, current.Index));
            depthes[current.Index] = depth;

            foreach (var edges in tree[current.Index])
            {
                if (edges.To == before)
                {
                    continue;
                }

                EularTour(edges.To, current, depth + 1);
                depthAndIndices.Add(new DepthAndIndex(depth, current.Index));
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct DepthAndIndex : IMonoid<DepthAndIndex>
        {
            public int Depth { get; }
            public int Index { get; }

            public DepthAndIndex Identity => new DepthAndIndex(int.MaxValue, -1);

            public DepthAndIndex(int depth, int index)
            {
                Depth = depth;
                Index = index;
            }

            public void Deconstruct(out int depth, out int index) => (depth, index) = (Depth, Index);
            public override string ToString() => $"{nameof(Depth)}: {Depth}, {nameof(Index)}: {Index}";

            public DepthAndIndex Multiply(DepthAndIndex other)
            {
                if (Depth <= other.Depth)
                {
                    return this;
                }
                else
                {
                    return other;
                }
            }
        }
    }
}
