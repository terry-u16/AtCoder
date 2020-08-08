using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200808.Algorithms;
using Training20200808.Collections;
using Training20200808.Extensions;
using Training20200808.Numerics;
using Training20200808.Questions;
using Training20200808.Graphs;
using System.Collections.Immutable;

namespace Training20200808.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nodeCount = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var graph = new BasicGraph(nodeCount);
            for (int i = 0; i < nodeCount - 1; i++)
            {
                var (u, v) = inputStream.ReadValue<int, int>();
                u--;
                v--;
                graph.AddEdge(new BasicEdge(u, v));
                graph.AddEdge(new BasicEdge(v, u));
            }

            var dp = Enumerable.Repeat(int.MaxValue, nodeCount).ToArray();
            var results = new int[nodeCount];

            void Dfs(int current, int parent)
            {
                var index = SearchExtensions.GetGreaterEqualIndex(dp, a[current]);
                var last = dp[index];
                dp[index] = a[current];
                results[current] = SearchExtensions.GetLessThanIndex(dp, int.MaxValue);

                foreach (var edge in graph[current])
                {
                    var next = edge.To.Index;
                    if (next != parent)
                    {
                        Dfs(next, current);
                    }
                }

                dp[index] = last;
            }

            Dfs(0, -1);

            for (int i = 0; i < results.Length; i++)
            {
                yield return results[i] + 1;
            }
        }
    }
}
