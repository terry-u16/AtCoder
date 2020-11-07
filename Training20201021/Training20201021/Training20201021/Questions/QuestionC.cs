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
using Training20201021.Algorithms;
using Training20201021.Collections;
using Training20201021.Numerics;
using Training20201021.Questions;
using Training20201021.Graphs;

namespace Training20201021.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var nodeCount = io.ReadInt();
            var edgeCount = io.ReadInt();

            var graph = new BasicGraph(nodeCount);
            var indegrees = new int[graph.NodeCount];

            for (int i = 0; i < edgeCount; i++)
            {
                var s = io.ReadInt();
                var t = io.ReadInt();
                s--;
                t--;

                graph.AddEdge(s, t);
                indegrees[t]++;
            }

            var result = double.MaxValue;

            for (int block = 0; block < graph.NodeCount; block++)
            {
                result.ChangeMin(GetExpectation(block));
            }

            io.WriteLine(result);

            double GetExpectation(int block)
            {
                Span<double> dp = stackalloc double[graph.NodeCount];
                dp[^1] = 0;

                for (int u = dp.Length - 2; u >= 0; u--)
                {
                    var sum = 0.0;
                    var max = 0.0;

                    foreach (var to in graph[u])
                    {
                        sum += dp[to];
                        max.ChangeMax(dp[to]);
                    }

                    var paths = graph[u].Length;

                    if (u == block && graph[u].Length > 1)
                    {
                        paths--;
                        sum -= max;
                    }

                    dp[u] = sum / paths + 1;
                }

                return dp[0];
            }
        }
    }
}
