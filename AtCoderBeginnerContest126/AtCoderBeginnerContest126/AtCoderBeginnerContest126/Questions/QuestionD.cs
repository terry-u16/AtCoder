using AtCoderBeginnerContest126.Questions;
using AtCoderBeginnerContest126.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest126.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        List<Edge>[] edges;
        int[] nodeColors;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nodeCount = inputStream.ReadInt();
            edges = Enumerable.Repeat(1, nodeCount).Select(_ => new List<Edge>()).ToArray();
            nodeColors = new int[nodeCount];

            for (int i = 0; i < nodeCount - 1; i++)
            {
                var uvw = inputStream.ReadIntArray();
                var u = uvw[0] - 1;
                var v = uvw[1] - 1;
                var w = uvw[2];
                edges[u].Add(new Edge(v, w));
                edges[v].Add(new Edge(u, w));
            }

            Paint(0, -1, 0);

            foreach (var color in nodeColors)
            {
                yield return color;
            }
        }

        void Paint(int node, int parent, int color)
        {
            nodeColors[node] = color;
            foreach (var edge in edges[node])
            {
                if (edge.OpponentNodeIndex != parent)
                {
                    Paint(edge.OpponentNodeIndex, node, (color + edge.Distance) % 2);
                }
            }
        }

        struct Edge
        {
            public int OpponentNodeIndex { get; }
            public int Distance { get; set; }

            public Edge(int opponentNodeIndex, int distance)
            {
                OpponentNodeIndex = opponentNodeIndex;
                Distance = distance;
            }
        }
    }
}
