using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using Training20201023.Algorithms;
using Training20201023.Collections;
using Training20201023.Numerics;
using Training20201023.Questions;
using Training20201023.Graphs;

namespace Training20201023.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var x = io.ReadInt() - 1;
            var tree = new BasicGraph(n);
            var jewels = io.ReadIntArray(n).Select(b => b == 1).ToArray();

            for (int i = 0; i < n - 1; i++)
            {
                var a = io.ReadInt();
                var b = io.ReadInt();
                a--;
                b--;
                tree.AddEdge(a, b);
                tree.AddEdge(b, a);
            }

            Dfs(x, -1);

            io.WriteLine(Math.Max((jewels.Count(b => b) - 1) * 2, 0));

            bool Dfs(int current, int parent)
            {
                var hasJewel = jewels[current];

                foreach (var next in tree[current])
                {
                    if (parent != next)
                    {
                        hasJewel |= Dfs(next, current);
                    }
                }

                return jewels[current] = hasJewel;
            }
        }
    }
}
