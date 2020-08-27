using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu074.Algorithms;
using Kujikatsu074.Collections;
using Kujikatsu074.Extensions;
using Kujikatsu074.Numerics;
using Kujikatsu074.Questions;
using Kujikatsu074.Graphs;

namespace Kujikatsu074.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc012/tasks/agc012_b
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();
            var graph = new BasicGraph(nodeCount);

            for (int i = 0; i < edgeCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                graph.AddEdge(new BasicEdge(a, b));
                graph.AddEdge(new BasicEdge(b, a));
            }

            var queryCount = inputStream.ReadInt();
            var queries = new Stack<Query>(queryCount);

            for (int i = 0; i < queryCount; i++)
            {
                var (v, d, c) = inputStream.ReadValue<int, int, int>();
                v--;
                queries.Push(new Query(v, d, c));
            }

            var distances = new int[nodeCount];
            var colors = new int[nodeCount];

            foreach (var query in queries)
            {
                var todo = new Queue<int>();
                if (distances[query.Node] < query.Distance)
                {
                    distances[query.Node] = query.Distance;
                    todo.Enqueue(query.Node);
                }

                if (colors[query.Node] == 0)
                {
                    colors[query.Node] = query.Color;
                }

                while (todo.Count > 0)
                {
                    var current = todo.Dequeue();
                    var nextDistance = distances[current] - 1;

                    foreach (var edge in graph[current])
                    {
                        var next = edge.To.Index;
                        if (distances[next] < nextDistance)
                        {
                            distances[next] = nextDistance;
                            todo.Enqueue(next);
                        }

                        if (colors[next] == 0)
                        {
                            colors[next] = query.Color;
                        }
                    }
                }
            }

            foreach (var color in colors)
            {
                yield return color;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct Query
        {
            public int Node { get; }
            public int Distance { get; }
            public int Color { get; }

            public Query(int node, int distance, int color)
            {
                Node = node;
                Distance = distance;
                Color = color;
            }

            public override string ToString() => $"{nameof(Node)}: {Node}, {nameof(Distance)}: {Distance}";
        }
    }
}
