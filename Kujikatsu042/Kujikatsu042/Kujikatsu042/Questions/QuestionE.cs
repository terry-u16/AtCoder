using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu042.Algorithms;
using Kujikatsu042.Collections;
using Kujikatsu042.Extensions;
using Kujikatsu042.Numerics;
using Kujikatsu042.Questions;
using Kujikatsu042.Graphs;
using System.Drawing;

namespace Kujikatsu042.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/m-solutions2019/tasks/m_solutions2019_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        BasicGraph tree;
        int[] counts;
        int[] results;
        Queue<int> points;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nodeCount = inputStream.ReadInt();
            tree = new BasicGraph(nodeCount);
            counts = new int[nodeCount];
            results = new int[nodeCount];

            for (int i = 0; i < nodeCount - 1; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                counts[a]++;
                counts[b]++;
                tree.AddEdge(new BasicEdge(a, b));
                tree.AddEdge(new BasicEdge(b, a));
            }

            points = new Queue<int>(inputStream.ReadIntArray().OrderBy(i => i));
            var total = points.Take(points.Count - 1).Sum();
            Bfs();

            yield return total;
            yield return results.Join(' ');
        }

        void Bfs()
        {
            var todo = new Queue<int>();

            for (int i = 0; i < counts.Length; i++)
            {
                if (counts[i] == 1)
                {
                    todo.Enqueue(i);
                }
            }

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                counts[current]--;
                results[current] = points.Dequeue();

                foreach (var edge in tree[new BasicNode(current)])
                {
                    var next = edge.To.Index;
                    if (results[next] == 0)
                    {
                        counts[next]--;
                        if (counts[next] == 1)
                        {
                            todo.Enqueue(next);
                        }
                    }
                }
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct MinIntAndIndex : IMonoid<MinIntAndIndex>
        {
            public int Value { get; }
            public int Index { get; }

            public MinIntAndIndex Identity => new MinIntAndIndex(int.MaxValue, -1);

            public MinIntAndIndex(int value, int index)
            {
                Value = value;
                Index = index;
            }

            public void Deconstruct(out int value, out int index) => (value, index) = (Value, Index);
            public override string ToString() => $"{nameof(Value)}: {Value}, {nameof(Index)}: {Index}";

            public MinIntAndIndex Multiply(MinIntAndIndex other) => Value <= other.Value ? this : other;
        }
    }
}
