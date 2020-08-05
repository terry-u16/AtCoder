using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200805.Algorithms;
using Training20200805.Collections;
using Training20200805.Extensions;
using Training20200805.Numerics;
using Training20200805.Questions;
using Training20200805.Graphs;
using static Training20200805.Algorithms.AlgorithmHelpers;

namespace Training20200805.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc139/tasks/abc139_e
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var graph = new BasicGraph(n * n);
            var indegrees = new int[graph.NodeCount];

            for (int me = 0; me < n; me++)
            {
                var enemies = inputStream.ReadIntArray().Select(i => i - 1);
                var last = -1;
                foreach (var enemy in enemies)
                {
                    if (last != -1)
                    {
                        var from = GetIndex(me, last, n);
                        var to = GetIndex(me, enemy, n);
                        graph.AddEdge(new BasicEdge(from, to));
                        indegrees[to]++;
                    }
                    last = enemy;
                }
            }

            var sorted = TopologicalSort(graph, indegrees);

            if (sorted == null)
            {
                yield return -1;
            }
            else
            {
                var dp = new int[sorted.Count];
                foreach (var currentNode in sorted)
                {
                    foreach (var next in graph[currentNode])
                    {
                        UpdateWhenLarge(ref dp[next.To.Index], dp[currentNode] + 1);
                    }
                }
                var max = dp.Max() + 1;
                yield return max;
            }
        }

        List<int> TopologicalSort(BasicGraph graph, int[] indegrees)
        {
            var result = new List<int>(graph.NodeCount);

            var queue = new Queue<int>();
            for (int i = 0; i < indegrees.Length; i++)
            {
                if (indegrees[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current);
                foreach (var edge in graph[current])
                {
                    var to = edge.To.Index;
                    indegrees[to]--;
                    if (indegrees[to] == 0)
                    {
                        queue.Enqueue(to);
                    }
                }
            }

            if (graph.NodeCount == result.Count)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        int GetIndex(int me, int other, int people)
        {
            if (me < other)
            {
                return me * people + other;
            }
            else
            {
                return other * people + me;
            }
        }
    }
}
