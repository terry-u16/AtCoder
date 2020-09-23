using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu101.Algorithms;
using Kujikatsu101.Collections;
using Kujikatsu101.Numerics;
using Kujikatsu101.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Kujikatsu101.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc051/tasks/abc051_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            const int Inf = 1 << 28;
            var nodes = io.ReadInt();
            var edgeCount = io.ReadInt();
            var graph = new int[nodes, nodes];

            for (int i = 0; i < nodes; i++)
            {
                for (int j = 0; j < nodes; j++)
                {
                    if (i == j)
                    {
                        graph[i, j] = 0;
                    }
                    else
                    {
                        graph[i, j] = Inf;
                    }
                }
            }

            var edges = new Edge[edgeCount];

            for (int i = 0; i < edges.Length; i++)
            {
                var a = io.ReadInt() - 1;
                var b = io.ReadInt() - 1;
                var c = io.ReadInt();

                graph[a, b] = c;
                graph[b, a] = c;
                edges[i] = new Edge(a, b, c);
            }

            for (int k = 0; k < nodes; k++)
            {
                for (int i = 0; i < nodes; i++)
                {
                    for (int j = 0; j < nodes; j++)
                    {
                        ChangeMax(ref graph[i, j], graph[i, k] + graph[k, j]);
                    }
                }
            }

            var count = 0;

            foreach (var edge in edges)
            {
                var used = false;
                for (int from = 0; from < nodes; from++)
                {
                    if (graph[from, edge.From] + edge.Cost == graph[from, edge.To])
                    {
                        used = true;
                        break;
                    }
                }

                if (!used)
                {
                    count++;
                }
            }

            io.WriteLine(count);
        }

        void ChangeMax(ref int a, int b)
        {
            if (a > b)
            {
                a = b;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Edge
        {
            public int From { get; }
            public int To { get; }
            public int Cost { get; }

            public Edge(int from, int to, int cost)
            {
                From = from;
                To = to;
                Cost = cost;
            }

            public override string ToString() => $"{nameof(From)}: {From}, {nameof(To)}: {To}";
        }
    }
}
