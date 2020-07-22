using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu038.Algorithms;
using Kujikatsu038.Collections;
using Kujikatsu038.Extensions;
using Kujikatsu038.Numerics;
using Kujikatsu038.Questions;
using Kujikatsu038.Graphs;

namespace Kujikatsu038.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc090/tasks/arc090_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();
            var (takahashiStart, aokiStart) = inputStream.ReadValue<int, int>();
            takahashiStart--;
            aokiStart--;

            var graph = new WeightedGraph(nodeCount);
            for (int i = 0; i < edgeCount; i++)
            {
                var (from, to, distance) = inputStream.ReadValue<int, int, int>();
                from--;
                to--;
                graph.AddEdge(new WeightedEdge(from, to, distance));
                graph.AddEdge(new WeightedEdge(to, from, distance));
            }

            var (takahashiDistances, takahashiCounts) = GetDistancesFrom(graph, new BasicNode(takahashiStart));
            var (aokiDistances, aokiCounts) = GetDistancesFrom(graph, new BasicNode(aokiStart));

            long minDistance = takahashiDistances[aokiStart];
            var count = takahashiCounts[aokiStart] * takahashiCounts[aokiStart];

            // 頂点上で出会う
            foreach (var node in graph.Nodes)
            {
                var takDis = takahashiDistances[node.Index];
                var aoDis = aokiDistances[node.Index];
                if (takDis == aoDis && takDis + aoDis == minDistance)
                {
                    var routes = takahashiCounts[node.Index] * aokiCounts[node.Index];
                    count -= routes * routes;
                }
            }

            // 辺上で出会う
            foreach (var edge in graph.Edges)
            {
                var takDis = takahashiDistances[edge.From.Index];
                var aoDis = aokiDistances[edge.To.Index];

                if (takDis < minDistance / 2.0 - 0.1 && aoDis < minDistance / 2.0 - 0.1 && takDis + edge.Weight + aoDis == minDistance)
                {
                    var routes = takahashiCounts[edge.From.Index] * aokiCounts[edge.To.Index];
                    count -= routes * routes;
                }
            }

            yield return count;
        }

        (long[] distances, Modular[] counts) GetDistancesFrom(WeightedGraph graph, BasicNode startNode)
        {
            const long Inf = 1L << 60;
            var distances = Enumerable.Repeat(Inf, graph.NodeCount).ToArray();
            var counts = new Modular[graph.NodeCount];
            distances[startNode.Index] = 0;
            counts[startNode.Index] = 1;
            var todo = new PriorityQueue<State>(false);
            todo.Enqueue(new State(startNode, 0));

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                if (current.Distance > distances[current.Node.Index])
                {
                    continue;
                }

                foreach (var edge in graph[current.Node])
                {
                    var nextDistance = current.Distance + edge.Weight;

                    if (distances[edge.To.Index] > nextDistance)
                    {
                        distances[edge.To.Index] = nextDistance;
                        todo.Enqueue(new State(edge.To, nextDistance));
                        counts[edge.To.Index] = counts[edge.From.Index];
                    }
                    else if (distances[edge.To.Index] == nextDistance)
                    {
                        counts[edge.To.Index] += counts[edge.From.Index];
                    }
                }
            }

            return (distances, counts);
        }

        private readonly struct State : IComparable<State>
        {
            public BasicNode Node { get; }
            public long Distance { get; }

            public State(BasicNode node, long distance)
            {
                Node = node;
                Distance = distance;
            }

            public int CompareTo(State other) => Distance.CompareTo(other.Distance);
        }

    }
}
