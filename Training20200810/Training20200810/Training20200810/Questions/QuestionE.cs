using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200810.Algorithms;
using Training20200810.Collections;
using Training20200810.Extensions;
using Training20200810.Numerics;
using Training20200810.Questions;
using Training20200810.Graphs;

namespace Training20200810.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/apc001/tasks/apc001_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();

            if (nodeCount - 1 == edgeCount)
            {
                yield return 0;
                yield break;
            }

            var graph = new BasicGraph(nodeCount);

            for (int i = 0; i < edgeCount; i++)
            {
                var (x, y) = inputStream.ReadValue<int, int>();
                graph.AddEdge(new BasicEdge(x, y));
                graph.AddEdge(new BasicEdge(y, x));
            }

            var groups = Enumerable.Repeat(-1, nodeCount).ToArray();

            void Dfs(int current, int parent, int groupNumber)
            {
                groups[current] = groupNumber;
                foreach (var edge in graph[current])
                {
                    var next = edge.To.Index;
                    if (next == parent || groups[next] != -1)
                    {
                        continue;
                    }

                    Dfs(next, current, groupNumber);
                }
            }

            var groupCount = 0;
            for (int i = 0; i < nodeCount; i++)
            {
                if (groups[i] == -1)
                {
                    Dfs(i, -1, groupCount++);
                }
            }

            for (int i = 0; i < nodeCount; i++)
            {

            }
        }
    }
}
