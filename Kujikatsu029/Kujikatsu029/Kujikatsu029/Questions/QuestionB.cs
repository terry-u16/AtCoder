using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu029.Algorithms;
using Kujikatsu029.Collections;
using Kujikatsu029.Extensions;
using Kujikatsu029.Numerics;
using Kujikatsu029.Questions;
using Kujikatsu029.Graphs;

namespace Kujikatsu029.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc166/tasks/abc166_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<int, int>();
            var heights = inputStream.ReadIntArray();
            var graph = new BasicGraph(n);

            for (int i = 0; i < m; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                graph.AddEdge(new BasicEdge(a, b));
                graph.AddEdge(new BasicEdge(b, a));
            }

            var count = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                var ok = true;
                foreach (var edge in graph[i])
                {
                    var to = edge.To.Index;
                    if (heights[i] <= heights[to])
                    {
                        ok = false;
                    }
                }
                if (ok)
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
