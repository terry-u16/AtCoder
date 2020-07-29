using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200727.Algorithms;
using Training20200727.Collections;
using Training20200727.Extensions;
using Training20200727.Numerics;
using Training20200727.Questions;
using Training20200727.Graphs;

namespace Training20200727.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dp/tasks/dp_p
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        BasicGraph tree;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            tree = new BasicGraph(n);
            for (int i = 0; i < n - 1; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                x--;
                y--;
                tree.AddEdge(new BasicEdge(x, y));
                tree.AddEdge(new BasicEdge(y, x));
            }

            var (whites, blacks) = Dfs(0, -1);

            yield return whites + blacks;
        }

        (Modular whites, Modular blacks) Dfs(int current, int parent)
        {
            Modular whites = 1;
            Modular blacks = 1;
            foreach (var edge in tree[current])
            {
                if (edge.To.Index == parent)
                {
                    continue;
                }

                var (w, b) = Dfs(edge.To.Index, current);
                whites *= w + b;
                blacks *= w;
            }
            return (whites, blacks);
        }
    }
}
