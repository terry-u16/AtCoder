using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Training20200620.Algorithms;
using Training20200620.Collections;
using Training20200620.Extensions;
using Training20200620.Graphs;
using Training20200620.Graphs.Algorithms;
using Training20200620.Numerics;
using Training20200620.Questions;

namespace Training20200620.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc142/tasks/abc142_f
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        const int Inf = 1 << 28;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodeCount, edgeCount) = inputStream.ReadValue<int, int>();
            var edges = new BasicEdge[edgeCount];
            for (int i = 0; i < edgeCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                edges[i] = new BasicEdge(a, b);
            }

            var graph = new BasicGraph(nodeCount, edges);

            List<int> minCycle = null;

            for (int startIndex = 0; startIndex < nodeCount; startIndex++)
            {
                var cycle = Bfs(new BasicNode(startIndex), graph);
                if (cycle != null && (minCycle == null || minCycle.Count > cycle.Count))
                {
                    minCycle = cycle;
                }
            }

            if (minCycle != null)
            {
                yield return minCycle.Count;
                foreach (var node in minCycle)
                {
                    yield return node + 1;
                }
            }
            else
            {
                yield return -1;
            }
        }

        List<int> Bfs(BasicNode startNode, BasicGraph graph)
        {
            var _minCycle = Inf;
            var _distances = Enumerable.Repeat(Inf, graph.NodeCount).ToArray();
            var _previous = Enumerable.Repeat(-1, graph.NodeCount).ToArray();
            _distances[startNode.Index] = 0;
            var todo = new Queue<BasicNode>();
            todo.Enqueue(startNode);
            var completed = false;

            while (todo.Count > 0 && !completed)
            {
                var current = todo.Dequeue();

                foreach (var edge in graph[current])
                {
                    var next = edge.To;
                    var nextDistance = _distances[current.Index] + 1;
                    if (_distances[next.Index] == 0)
                    {
                        _previous[next.Index] = current.Index;
                        _minCycle = nextDistance;
                        completed = true;
                    }
                    else if (_distances[next.Index] == Inf)
                    {
                        _previous[next.Index] = current.Index;
                        _distances[next.Index] = nextDistance;
                        todo.Enqueue(next);
                    }
                }
            }

            if (_minCycle != Inf)
            {
                var nodes = new List<int>();
                var node = startNode;
                for (int i = 0; i < _minCycle; i++)
                {
                    var previous = new BasicNode(_previous[node.Index]);
                    nodes.Add(previous.Index);
                    node = previous;
                }
                return nodes;
            }
            else
            {
                return null;
            }
        }
    }
}
