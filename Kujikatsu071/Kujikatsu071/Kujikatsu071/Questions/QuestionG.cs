using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu071.Algorithms;
using Kujikatsu071.Collections;
using Kujikatsu071.Extensions;
using Kujikatsu071.Numerics;
using Kujikatsu071.Questions;
using Kujikatsu071.Graphs;

namespace Kujikatsu071.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/hitachi2020/tasks/hitachi2020_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nodeCount = inputStream.ReadInt();
            var graph = new BasicGraph(nodeCount);
            for (int i = 0; i < nodeCount - 1; i++)
            {
                var (u, v) = inputStream.ReadValue<int, int>();
                u--;
                v--;
                graph.AddEdge(new BasicEdge(u, v));
                graph.AddEdge(new BasicEdge(v, u));
            }

            var colors = new int[nodeCount];
            const int Black = 0;
            const int White = 1;

            void Paint(int current, int parent, int color)
            {
                colors[current] = color;

                foreach (var edge in graph[current])
                {
                    var next = edge.To.Index;
                    if (next != parent)
                    {
                        Paint(next, current, color ^ White);
                    }
                }
            }

            Paint(0, -1, Black);

            var blacks = new Queue<int>();
            var whites = new Queue<int>();

            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == Black)
                {
                    blacks.Enqueue(i);
                }
                else
                {
                    whites.Enqueue(i);
                }
            }

            if (blacks.Count > whites.Count)
            {
                (blacks, whites) = (whites, blacks);
            }

            var ones = new Queue<int>(Enumerable.Range(1, nodeCount).Where(i => i % 3 == 1));
            var twos = new Queue<int>(Enumerable.Range(1, nodeCount).Where(i => i % 3 == 2));
            var threes = new Queue<int>(Enumerable.Range(1, nodeCount).Where(i => i % 3 == 0));

            var result = new int[nodeCount];

            if (blacks.Count <= threes.Count)
            {
                while (blacks.Count > 0)
                {
                    result[blacks.Dequeue()] = threes.Dequeue();
                }

                while (threes.Count > 0)
                {
                    result[whites.Dequeue()] = threes.Dequeue();
                }

                while (ones.Count > 0)
                {
                    result[whites.Dequeue()] = ones.Dequeue();
                }

                while (twos.Count > 0)
                {
                    result[whites.Dequeue()] = twos.Dequeue();
                }
            }
            else
            {
                while (ones.Count > 0)
                {
                    result[whites.Dequeue()] = ones.Dequeue();
                }

                while (twos.Count > 0)
                {
                    result[blacks.Dequeue()] = twos.Dequeue();
                }

                while (blacks.Count > 0)
                {
                    result[blacks.Dequeue()] = threes.Dequeue();
                }

                while (whites.Count > 0)
                {
                    result[whites.Dequeue()] = threes.Dequeue();
                }
            }

            yield return result.Join(' ');
        }
    }
}
