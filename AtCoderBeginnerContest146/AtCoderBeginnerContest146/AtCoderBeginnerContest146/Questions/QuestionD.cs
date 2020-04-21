using AtCoderBeginnerContest146.Questions;
using AtCoderBeginnerContest146.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest146.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        Edge[] edges;
        List<int>[] nodes;
        Dictionary<Edge, int> edgeColors;
        int[] parentColors; // 各ノードの親と接続されている辺の色


        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            edges = new Edge[n - 1];
            nodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
            edgeColors = new Dictionary<Edge, int>();
            parentColors = new int[n];

            for (int i = 0; i < n - 1; i++)
            {
                var ab = inputStream.ReadIntArray().Select(x => x - 1).ToArray();
                var a = ab[0];
                var b = ab[1];
                edges[i] = new Edge(a, b);
                edgeColors.Add(edges[i], 0);
                nodes[a].Add(b);
                nodes[b].Add(a);
            }

            Paint();

            yield return edgeColors.Max(p => p.Value);

            foreach (var edge in edges)
            {
                if (edgeColors.ContainsKey(edge))
                {
                    yield return edgeColors[edge];
                }
                else
                {
                    yield return edgeColors[new Edge(edge.NodeB, edge.NodeA)];
                }
            }
        }

        private void Paint()
        {
            var toDo = new Queue<int>();
            toDo.Enqueue(0);
            var seen = new bool[nodes.Length];
            seen[0] = true;

            while (toDo.Any())
            {
                var currentNode = toDo.Dequeue();
                var parentColor = parentColors[currentNode];
                var color = 1;
                foreach (var nextNode in nodes[currentNode].Where(n => !seen[n]))
                {
                    if (color == parentColor)
                    {
                        color++;
                    }

                    seen[nextNode] = true;
                    edgeColors[new Edge(currentNode, nextNode)] = color;
                    parentColors[nextNode] = color;
                    toDo.Enqueue(nextNode);
                    color++;
                }
            }
        }
    }

    public class Node
    {
        private List<Node> _connectedNodes = new List<Node>();

        public IReadOnlyList<Node> ConnectedNodes => _connectedNodes;

        public void Connect(Node node) => _connectedNodes.Add(node);

        public void Disconnect(Node node) => _connectedNodes.Remove(node);
    }

    public class Edge : IEquatable<Edge>
    {
        public int NodeA { get; }
        public int NodeB { get; }

        public Edge(int nodeA, int nodeB)
        {
            NodeA = nodeA;
            NodeB = nodeB;
        }

        public bool Equals(Edge other) => NodeA == other?.NodeA && NodeB == other?.NodeB;

        public override bool Equals(object obj) => Equals(obj as Edge);

        public override string ToString() => $"NodeA:{NodeA}, NodeB:{NodeB}";

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 105289569;
                hashCode = hashCode * -1521134295 + NodeA.GetHashCode();
                hashCode = hashCode * -1521134295 + NodeB.GetHashCode();
                return hashCode;
            }
        }
    }
}
