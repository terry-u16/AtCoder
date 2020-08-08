using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200808.Algorithms;
using Training20200808.Collections;
using Training20200808.Extensions;
using Training20200808.Numerics;
using Training20200808.Questions;
using Training20200808.Graphs;
using Training20200808.Graphs.Algorithms;

namespace Training20200808.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc164/tasks/abc164_e
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (cityCount, railwayCount, initialSilver) = inputStream.ReadValue<int, int, int>();
            const int extended = 2500;
            var graph = new WeightedGraph(cityCount * (extended + 1));

            for (int i = 0; i < railwayCount; i++)
            {
                var (u, v, a, b) = inputStream.ReadValue<int, int, int, int>();
                u--;
                v--;

                for (int shift = 0; shift + a <= extended; shift++)
                {
                    graph.AddEdge(new WeightedEdge(ToGraphNodeIndex(cityCount, u, shift + a), ToGraphNodeIndex(cityCount, v, shift), b));
                    graph.AddEdge(new WeightedEdge(ToGraphNodeIndex(cityCount, v, shift + a), ToGraphNodeIndex(cityCount, u, shift), b));
                }
            }

            for (int city = 0; city < cityCount; city++)
            {
                var (c, d) = inputStream.ReadValue<int, int>();
                for (int shift = 0; shift < extended; shift++)
                {
                    graph.AddEdge(new WeightedEdge(ToGraphNodeIndex(cityCount, city, shift), ToGraphNodeIndex(cityCount, city, Math.Min(shift + c, extended)), d));
                }
            }

            var dijkstra = new Dijkstra<BasicNode, WeightedEdge>(graph);
            var distances = dijkstra.GetDistancesFrom(ToGraphNodeIndex(cityCount, 0, Math.Min(initialSilver, extended)));

            for (int city = 1; city < cityCount; city++)
            {
                var min = long.MaxValue;
                for (int silver = 0; silver <= extended; silver++)
                {
                    min = Math.Min(min, distances[ToGraphNodeIndex(cityCount, city, silver)]);
                }
                yield return min;
            }
        }

        int ToGraphNodeIndex(int cityCount, int city, int silvers) => city + silvers * cityCount;
    }
}
