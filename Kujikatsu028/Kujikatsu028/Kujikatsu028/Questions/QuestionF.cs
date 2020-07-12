using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu028.Algorithms;
using Kujikatsu028.Collections;
using Kujikatsu028.Extensions;
using Kujikatsu028.Numerics;
using Kujikatsu028.Questions;
using Kujikatsu028.Graphs;

namespace Kujikatsu028.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc009/tasks/agc009_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        BasicGraph graph;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            graph = new BasicGraph(n);

            for (int me = 1; me < n; me++)
            {
                var hostile = inputStream.ReadInt();
                hostile--;
                graph.AddEdge(new BasicEdge(hostile, me));
            }

            yield return Dfs(0);
        }

        int Dfs(int me)
        {
            var battles = new List<int>();
            foreach (var edge in graph[me])
            {
                var hostile = edge.To;
                battles.Add(Dfs(hostile.Index));
            }

            var count = 0;
            battles.Sort((a, b) => b - a);
            for (int i = 0; i < battles.Count; i++)
            {
                count = Math.Max(count, battles[i] + i + 1);
            }
            return count;
        }
    }
}
