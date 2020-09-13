using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using WUPC2020.Extensions;
using WUPC2020.Questions;
using System.Diagnostics;

namespace WUPC2020.Questions
{
    public class QuestionJ : AtCoderQuestionBase
    {
        List<int>[] graph;
        bool[] visited;

        public override IEnumerable<object> Solve(TextReader stream)
        {
            var input = stream.ReadIntArray();
            var nodeCount = input[0];
            var edgeCount = input[1];
            graph = Enumerable.Repeat(0, nodeCount).Select(_ => new List<int>()).ToArray();

            for (int i = 0; i < edgeCount; i++)
            {
                input = stream.ReadIntArray();
                var from = input[0] - 1;
                var to = input[1] - 1;
                graph[to].Add(from);
            }

            visited = new bool[nodeCount];
            Dfs(0);

            var queries = stream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                input = stream.ReadIntArray();
                var kind = input[0];
                var value = input[1] - 1;

                if (kind == 1)
                {
                    if (!visited[value])
                    {
                        Dfs(value);
                    }
                }
                else
                {
                    yield return visited[value] ? "YES" : "NO";
                }
            }
        }

        void Dfs(int current)
        {
            visited[current] = true;
            foreach (var next in graph[current])
            {
                if (!visited[next])
                {
                    Dfs(next);
                }
            }
        }
    }
}
