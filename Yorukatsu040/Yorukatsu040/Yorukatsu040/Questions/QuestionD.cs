using Yorukatsu040.Questions;
using Yorukatsu040.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu040.Questions
{
    /// <summary>
    /// ABC146 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        List<int>[] graph;
        Edge[] edges;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            graph = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
            edges = new Edge[n - 1];

            for (int i = 0; i < n - 1; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
                edges[i] = new Edge(a, b);
            }

            var colors = Paint();
            yield return colors.Max(p => p.Value);
            foreach (var edge in edges)
            {
                yield return colors[edge];
            }
        }

        Dictionary<Edge, int> Paint()
        {
            var colors = new Dictionary<Edge, int>();
            Paint(0, -1, colors);
            return colors;
        }

        void Paint(int current, int parent, Dictionary<Edge, int> colors)
        {
            var color = 1;
            var parentColor = parent != -1 ? colors[new Edge(current, parent)] : 0;

            foreach (var next in graph[current])
            {
                if (next != parent)
                {
                    if (color == parentColor)
                    {
                        color++;
                    }
                    colors[new Edge(current, next)] = color++;
                    Paint(next, current, colors);
                }
            }
        }

        struct Edge : IEquatable<Edge>
        {
            public int Node1 { get; }
            public int Node2 { get; }

            public Edge(int node1, int node2)
            {
                Node1 = Math.Min(node1, node2);
                Node2 = Math.Max(node1, node2);
            }

            public override bool Equals(object obj)
            {
                return obj is Edge && Equals((Edge)obj);
            }

            public bool Equals(Edge other)
            {
                return Node1 == other.Node1 &&
                       Node2 == other.Node2;
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = 1001471489;
                    hashCode = hashCode * -1521134295 + Node1.GetHashCode();
                    hashCode = hashCode * -1521134295 + Node2.GetHashCode();
                    return hashCode;
                }
            }

            public static bool operator ==(Edge left, Edge right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(Edge left, Edge right)
            {
                return !(left == right);
            }
        }
    }
}
