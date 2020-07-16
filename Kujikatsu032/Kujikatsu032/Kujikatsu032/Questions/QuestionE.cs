using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu032.Algorithms;
using Kujikatsu032.Collections;
using Kujikatsu032.Extensions;
using Kujikatsu032.Numerics;
using Kujikatsu032.Questions;
using Kujikatsu032.Graphs;

namespace Kujikatsu032.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/nikkei2019-qual/tasks/nikkei2019_qual_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<int, int>();
            var edges = new BasicEdge[n - 1 + m];
            var graph = new BasicGraph(n);
            var inDegrees = new int[n];
            var invertedGraph = new BasicGraph(n);

            for (int i = 0; i < edges.Length; i++)
            {
                var (from, to) = inputStream.ReadValue<int, int>();
                from--;
                to--;
                var edge = new BasicEdge(from, to);
                edges[i] = edge;
                inDegrees[to]++;
                graph.AddEdge(edge);
                invertedGraph.AddEdge(new BasicEdge(to, from));
            }

            var sortedNodes = TopologicalSort(graph, inDegrees);
            var sortedNodesPositions = new int[n];

            for (int i = 0; i < sortedNodesPositions.Length; i++)
            {
                var node = sortedNodes[i];
                sortedNodesPositions[node] = i;
            }

            for (int i = 0; i < n; i++)
            {
                var parents = invertedGraph[i].ToArray();
                var answer = -1;
                var answerPosition = -1;

                foreach (var parent in parents)
                {
                    var position = sortedNodesPositions[parent.To.Index];
                    if (answerPosition < position)
                    {
                        answerPosition = position;
                        answer = parent.To.Index;
                    }
                }

                yield return answer + 1;
            }
        }

        List<int> TopologicalSort(BasicGraph graph, int[] inDegrees)
        {
            var sorted = new List<int>();
            var queue = new Queue<int>();

            for (int i = 0; i < inDegrees.Length; i++)
            {
                if (inDegrees[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                sorted.Add(current);

                foreach (var edge in graph[current])
                {
                    inDegrees[edge.To.Index]--;
                    if (inDegrees[edge.To.Index] == 0)
                    {
                        queue.Enqueue(edge.To.Index);
                    }
                }
            }

            return sorted;
        }
    }
}
