using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu102.Algorithms;
using Kujikatsu102.Collections;
using Kujikatsu102.Numerics;
using Kujikatsu102.Questions;
using Kujikatsu102.Graphs;

namespace Kujikatsu102.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/apc001/tasks/apc001_e
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var graph = new BasicGraph(n);

            var degrees = new int[n];

            for (int i = 0; i < n - 1; i++)
            {
                var a = io.ReadInt();
                var b = io.ReadInt();
                graph.AddEdge(new BasicEdge(a, b));
                graph.AddEdge(new BasicEdge(b, a));
                degrees[a]++;
                degrees[b]++;
            }

            for (int i = 0; i < degrees.Length; i++)
            {
                if (degrees[i] > 2)
                {
                    var result = Dfs(i, -1);
                    io.WriteLine(result);
                    return;
                }
            }

            io.WriteLine(1);

            int Dfs(int current, int parent)
            {
                var children = 0;
                var antennas = 0;
                var antennaBranches = 0;

                foreach (var edge in graph[current])
                {
                    var next = edge.To.Index;
                    if (next == parent)
                    {
                        continue;
                    }

                    children++;
                    var an = Dfs(next, current);
                    antennas += an;

                    if (an > 0)
                    {
                        antennaBranches++;
                    }
                }

                if (children > antennaBranches + 1)
                {
                    antennas += children - (antennaBranches + 1);
                }

                return antennas;
            }
        }
    }
}
