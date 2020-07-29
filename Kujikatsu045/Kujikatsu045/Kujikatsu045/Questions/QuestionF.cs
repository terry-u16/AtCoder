using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu045.Algorithms;
using Kujikatsu045.Collections;
using Kujikatsu045.Extensions;
using Kujikatsu045.Numerics;
using Kujikatsu045.Questions;
using Kujikatsu045.Graphs;

namespace Kujikatsu045.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2017-qualb/tasks/code_festival_2017_qualb_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        BasicGraph graph;
        Color[] colors;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();
            graph = new BasicGraph(nodeCount);
            colors = new Color[nodeCount];

            for (int i = 0; i < edgeCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                graph.AddEdge(new BasicEdge(a, b));
                graph.AddEdge(new BasicEdge(b, a));
            }

            if (Paint())
            {
                yield return (long)colors.Count(c => c == Color.Black) * colors.Count(c => c == Color.White) - edgeCount;
            }
            else
            {
                yield return (long)nodeCount * (nodeCount - 1) / 2 - edgeCount;
            }
        }

        bool Paint()
        {
            var todo = new Queue<int>();
            todo.Enqueue(0);
            colors[0] = Color.Black;

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                foreach (var edge in graph[current])
                {
                    var next = edge.To.Index;

                    if (colors[next] == Color.None)
                    {
                        todo.Enqueue(next);
                        colors[next] = colors[current] == Color.Black ? Color.White : Color.Black;
                    }
                    else if (colors[current] == colors[next])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        enum Color
        {
            None,
            Black,
            White
        }
    }
}
