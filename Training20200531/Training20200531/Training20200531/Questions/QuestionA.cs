using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderTemplateForNetCore.Graphs;
using AtCoderTemplateForNetCore.Graphs.Algorithms;
using Training20200531.Algorithms;
using Training20200531.Collections;
using Training20200531.Extensions;
using Training20200531.Numerics;
using Training20200531.Questions;

namespace Training20200531.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (citiesCount, roadsCount, tankCapacity) = inputStream.ReadValue<int, int, int>();
            var roadGraph = new WeightedGraph(citiesCount);
            for (int i = 0; i < roadsCount; i++)
            {
                var (a, b, fuel) = inputStream.ReadValue<int, int, int>();
                a--;
                b--;
                roadGraph.AddEdge(new WeightedEdge(a, b, fuel));
                roadGraph.AddEdge(new WeightedEdge(b, a, fuel));
            }

            var distanceWarshallFloyd = new WarshallFloyd<BasicNode, WeightedEdge>(roadGraph);
            var distances = distanceWarshallFloyd.GetDistances();

            // こっちの初期化手法はあまり使わないか……
            var refuelEdges = Enumerable.Range(0, citiesCount)
                                        .SelectMany(from => Enumerable.Range(0, citiesCount)
                                                                      .Select(to => new { from, to })
                                                                      .Where(pair => distances[pair.from, pair.to] <= tankCapacity)
                                                                      .Select(pair => new WeightedEdge(pair.from, pair.to)));
            var refuelGraph = new WeightedGraph(citiesCount, refuelEdges);
            var refuelWarshallFloyd = new WarshallFloyd<BasicNode, WeightedEdge>(refuelGraph);
            var refuelCounts = refuelWarshallFloyd.GetDistances();

            var queries = inputStream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                var (from, to) = inputStream.ReadValue<int, int>();
                from--;
                to--;
                var refuelCount = refuelCounts[from, to];
                var output = refuelCount < long.MaxValue ? (refuelCount - 1).ToString() : (-1).ToString();
            }
            yield return string.Empty;
        }
    }
}
