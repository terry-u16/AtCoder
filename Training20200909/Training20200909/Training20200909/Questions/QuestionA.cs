using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200909.Algorithms;
using Training20200909.Collections;
using Training20200909.Extensions;
using Training20200909.Numerics;
using Training20200909.Questions;
using System.Diagnostics;
using AtCoder;

namespace Training20200909.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/practice2/tasks/practice2_g
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();
            var graph = new SCCGraph(nodeCount);
            for (int i = 0; i < edgeCount; i++)
            {
                var (u, v) = inputStream.ReadValue<int, int>();
                graph.AddEdge(u, v);
            }

            var sccs = graph.SCC();

            yield return sccs.Count;

            foreach (var scc in sccs)
            {
                yield return $"{scc.Count} {scc.Join(' ')}";
            }
        }
    }
}
