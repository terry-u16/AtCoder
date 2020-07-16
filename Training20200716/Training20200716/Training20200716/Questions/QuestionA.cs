using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200716.Algorithms;
using Training20200716.Collections;
using Training20200716.Extensions;
using Training20200716.Numerics;
using Training20200716.Questions;
using Training20200716.Graphs;
using Training20200716.Graphs.Algorithms;

namespace Training20200716.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m) = inputStream.ReadValue<int, int>();
            var edges = new List<WeightedEdge>();
            const long Inf = 1L << 60;


            var startAndDistances = new List<StartAndDistance>();

            for (int i = 0; i < m; i++)
            {
                var (u, v, l) = inputStream.ReadValue<int, int, int>();
                u--;
                v--;
                edges.Add(new WeightedEdge(u, v, l));
                edges.Add(new WeightedEdge(v, u, l));

                if (u == 0)
                {
                    startAndDistances.Add(new StartAndDistance(v, l));
                }
            }

            long min = Inf;

            for (int startIndex = 0; startIndex < startAndDistances.Count; startIndex++)
            {
                var (start, startDistance) = startAndDistances[startIndex];

                var graph = new WeightedGraph(n);

                foreach (var edge in edges)
                {
                    if (!(edge.From == 0 && edge.To == start) && !(edge.From == start && edge.To == 0))
                    {
                        graph.AddEdge(edge);
                    }
                }

                var dijkstra = new Dijkstra<BasicNode, WeightedEdge>(graph);

                min = Math.Min(min, startDistance + dijkstra.GetDistancesFrom(new BasicNode(start))[0]);
            }

            if (min == Inf)
            {
                yield return -1;
            }
            else
            {
                yield return min;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct StartAndDistance
        {
            public int Start { get; }
            public long Distance { get; }

            public StartAndDistance(int start, long distance)
            {
                Start = start;
                Distance = distance;
            }

            public void Deconstruct(out int start, out long distance) => (start, distance) = (Start, Distance);
            public override string ToString() => $"{nameof(Start)}: {Start}, {nameof(Distance)}: {Distance}";
        }
    }
}
