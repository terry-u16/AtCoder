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
using CodeforcesRound606Div2.Questions;

namespace CodeforcesRound606Div2.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                var n = io.ReadInt();
                var m = io.ReadInt();
                var a = io.ReadInt() - 1;
                var b = io.ReadInt() - 1;

                var graph = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();

                for (int i = 0; i < m; i++)
                {
                    var u = io.ReadInt() - 1;
                    var v = io.ReadInt() - 1;

                    graph[u].Add(v);
                    graph[v].Add(u);
                }

                const int A = 0;
                const int B = 1;
                var reachable = new bool[2, n];
                var seen = new bool[n];

                DfsA(a, -1);
                seen.AsSpan().Clear();
                DfsB(b, -1);

                reachable[A, b] = true;
                reachable[B, a] = true;

                long onlyA = 0;
                long onlyB = 0;

                for (int i = 0; i < n; i++)
                {
                    if (reachable[A, i] && !reachable[B, i])
                    {
                        onlyA++;
                    }
                    else if (reachable[B, i] && !reachable[A, i])
                    {
                        onlyB++;
                    }
                }

                io.WriteLine(onlyA * onlyB);

                void DfsA(int current, int parent)
                {
                    seen[current] = true;
                    reachable[A, current] = true;

                    foreach (var next in graph[current])
                    {
                        if (next != parent && next != b && !seen[next])
                        {
                            DfsA(next, current);
                        }
                    }
                }

                void DfsB(int current, int parent)
                {
                    seen[current] = true;
                    reachable[B, current] = true;

                    foreach (var next in graph[current])
                    {
                        if (next != parent && next != a && !seen[next])
                        {
                            DfsB(next, current);
                        }
                    }
                }
            }
        }
    }
}
