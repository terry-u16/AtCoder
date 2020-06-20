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
    /// https://atcoder.jp/contests/soundhound2018-summer-qual/tasks/soundhound2018_summer_qual_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const long startYen = 1_000_000_000_000_000;
            var (citiesCount, trainsCount, start, terminal) = inputStream.ReadValue<int, int, int, int>();
            start--;
            terminal--;

            var yenGraph = new WeightedGraph(citiesCount);
            var snuukGraph = new WeightedGraph(citiesCount);

            for (int i = 0; i < trainsCount; i++)
            {
                var (from, to, yen, snuuk) = inputStream.ReadValue<int, int, long, long>();
                from--;
                to--;
                yenGraph.AddEdge(new WeightedEdge(from, to, yen));
                yenGraph.AddEdge(new WeightedEdge(to, from, yen));
                snuukGraph.AddEdge(new WeightedEdge(from, to, snuuk));
                snuukGraph.AddEdge(new WeightedEdge(to, from, snuuk));
            }

            var yenFares = new Dijkstra<BasicNode, WeightedEdge>(yenGraph).GetDistancesFrom(new BasicNode(start));
            var snuukFares = new Dijkstra<BasicNode, WeightedEdge>(snuukGraph).GetDistancesFrom(new BasicNode(terminal));

            var remainedSnuuks = new Stack<long>(citiesCount);

            for (int exchange = citiesCount - 1; exchange >= 0; exchange--)
            {
                var best = remainedSnuuks.Count > 0 ? remainedSnuuks.Peek() : int.MinValue;
                var next = startYen - (yenFares[exchange] + snuukFares[exchange]);
                remainedSnuuks.Push(Math.Max(best, next));
            }

            foreach (var remainedSnuuk in remainedSnuuks)
            {
                yield return remainedSnuuk;
            }
        }
    }
}
