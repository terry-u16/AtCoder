using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200723.Algorithms;
using Training20200723.Collections;
using Training20200723.Extensions;
using Training20200723.Numerics;
using Training20200723.Questions;
using Training20200723.Graphs;
using Training20200723.Graphs.Algorithms;

namespace Training20200723.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc035/tasks/abc035_d
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (townCount, pathCount, timeLimit) = inputStream.ReadValue<int, int, int>();
            var gainRates = inputStream.ReadLongArray();
            var goingGraph = new WeightedGraph(townCount);
            var backingGraph = new WeightedGraph(townCount);

            for (int i = 0; i < pathCount; i++)
            {
                var (from, to, distance) = inputStream.ReadValue<int, int, int>();
                from--;
                to--;
                goingGraph.AddEdge(new WeightedEdge(from, to, distance));
                backingGraph.AddEdge(new WeightedEdge(to, from, distance));
            }

            var goingDijkstra = new Dijkstra<BasicNode, WeightedEdge>(goingGraph);
            var backingDijkstra = new Dijkstra<BasicNode, WeightedEdge>(backingGraph);
            var goingDistances = goingDijkstra.GetDistancesFrom(new BasicNode(0));
            var backingDistances = backingDijkstra.GetDistancesFrom(new BasicNode(0));

            const long inf = 1L << 50;
            long max = 0;
            for (int i = 0; i < townCount; i++)
            {
                if (goingDistances[i] > inf || backingDistances[i] > inf)
                {
                    continue;
                }
                var earned = gainRates[i] * (timeLimit - goingDistances[i] - backingDistances[i]);
                max = Math.Max(max, earned);
            }

            yield return max;
        }
    }
}
