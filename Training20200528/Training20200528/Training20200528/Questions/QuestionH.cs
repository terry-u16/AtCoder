using Training20200528.Questions;
using Training20200528.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200528.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc039/tasks/agc039_b
    /// </summary>
    public class QuestionH : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var graph = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
            var graphMatrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var edges = inputStream.ReadLine();
                graphMatrix[i] = edges.Select(c => c - '0').ToArray();
                for (int j = 0; j < n; j++)
                {
                    if (edges[j] == '1')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            if (IsBipartite(graph))
            {
                yield return GetDiameterOf(graphMatrix) + 1;
            }
            else
            {
                yield return -1;
            }
        }

        bool IsBipartite(List<int>[] graph)
        {
            var color = new bool?[graph.Length];
            var todo = new Queue<int>();
            todo.Enqueue(0);
            color[0] = true;

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                foreach (var next in graph[current])
                {
                    if (color[next] == null)
                    {
                        color[next] = !color[current];
                        todo.Enqueue(next);
                    }
                    else if (!(color[current].Value ^ color[next].Value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        int GetDiameterOf(int[][] graph)
        {
            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph.Length; j++)
                {
                    if (i != j && graph[i][j] == 0)
                    {
                        graph[i][j] = 1 << 28;
                    }
                }
            }

            for (int k = 0; k < graph.Length; k++)
            {
                for (int i = 0; i < graph.Length; i++)
                {
                    for (int j = 0; j < graph.Length; j++)
                    {
                        graph[i][j] = Math.Min(graph[i][j], graph[i][k] + graph[k][j]);
                    }
                }
            }

            return graph.Max(row => row.Max());
        }
    }
}
