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
using System.Drawing;

namespace Training20200627.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc036/tasks/abc036_d
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        BasicGraph graph;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            graph = new BasicGraph(n);
            for (int i = 0; i < n - 1; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                graph.AddEdge(new BasicEdge(a, b));
                graph.AddEdge(new BasicEdge(b, a));
            }

            var painter = new Painter(graph);
            var count = painter.Search(new BasicNode(0));
            yield return (count[0, 0] + count[0, 1]).Value;
        }

        class Painter : DfsBase<BasicGraph, BasicNode, BasicEdge, Modular[,]>
        {
            Modular[,] colorCount;
            const int Black = 0;
            const int White = 1;

            public Painter(BasicGraph graph) : base(graph)
            {
            }

            protected override Modular[,] GetResult() => colorCount;

            protected override void Initialize(BasicNode startNode)
            {
                colorCount = new Modular[_graph.NodeCount, 2];
            }

            protected override void OnPostordering(BasicNode current, BasicNode previous, bool isFirstNode)
            {
                if (_graph[current.Index].Take(2).Count() == 1 && !isFirstNode)
                {
                    colorCount[current.Index, Black] = 1;
                    colorCount[current.Index, White] = 1;
                }
                else
                {
                    var black = Modular.One;
                    var white = Modular.One;

                    foreach (var edge in _graph[current.Index])
                    {
                        if (edge.To == previous)
                        {
                            continue;
                        }

                        black *= colorCount[edge.To.Index, White];
                        white *= colorCount[edge.To.Index, Black] + colorCount[edge.To.Index, White];
                    }

                    colorCount[current.Index, Black] = black;
                    colorCount[current.Index, White] = white;
                }
            }

            protected override void OnPreordering(BasicNode current, BasicNode previous, bool isFirstNode)
            {
            }
        }
    }
}
