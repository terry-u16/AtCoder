using AtCoderBeginnerContest132.Questions;
using AtCoderBeginnerContest132.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest132.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            var edges = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();

            for (int i = 0; i < m; i++)
            {
                var uv = inputStream.ReadIntArray();
                var u = uv[0] - 1;
                var v = uv[1] - 1;
                edges[u].Add(v);
            }

            var st = inputStream.ReadIntArray();
            var start = st[0] - 1;
            var terminal = st[1] - 1;

            yield return Search(edges, start, terminal);
        }

        public int Search(List<int>[] edges, int start, int terminal)
        {
            var todo = new Queue<NodeDistancePair>();
            var seen = new bool[edges.Length, 3];

            todo.Enqueue(new NodeDistancePair(start, 0));
            seen[start, 0] = true;

            while (todo.Any())
            {
                var current = todo.Dequeue();
                var nextDistance = current.Distance + 1;
                foreach (var edge in edges[current.Node])
                {
                    if (edge == terminal && nextDistance % 3 == 0)
                    {
                        return nextDistance / 3;    // けんけんぱは3歩で1回
                    }
                    else if (!seen[edge, nextDistance % 3])
                    {
                        seen[edge, nextDistance % 3] = true;
                        todo.Enqueue(new NodeDistancePair(edge, nextDistance));
                    }
                }
            }

            return -1;
        }

        struct NodeDistancePair
        {
            public int Node { get; }
            public int Distance { get; }

            public NodeDistancePair(int node, int distance)
            {
                Node = node;
                Distance = distance;
            }

            public override string ToString() => $"Node:{Node}, Distance:{Distance}";
        }
    }
}
