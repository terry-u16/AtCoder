using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu058.Algorithms;
using Kujikatsu058.Collections;
using Kujikatsu058.Extensions;
using Kujikatsu058.Numerics;
using Kujikatsu058.Questions;
using Kujikatsu058.Graphs.Algorithms;
using Kujikatsu058.Graphs;

namespace Kujikatsu058.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc160/tasks/abc160_f
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.InitializeCombinationTable();
            var nodeCount = inputStream.ReadInt();
            var graph = new BasicGraph(nodeCount);

            for (int i = 0; i < nodeCount - 1; i++)
            {
                var (u, v) = inputStream.ReadValue<int, int>();
                u--;
                v--;
                graph.AddEdge(new BasicEdge(u, v));
                graph.AddEdge(new BasicEdge(v, u));
            }

            var rerooting = new Rerooting<BasicNode, BasicEdge, CountAndWay>(graph);
            var results = rerooting.Solve();

            foreach (var result in results)
            {
                yield return result.Way;
            }
        }

        [StructLayout(LayoutKind.Auto)]
        readonly struct CountAndWay : ITreeDpState<CountAndWay>
        {
            public int Count { get; }
            public Modular Way { get; }

            public CountAndWay Identity => new CountAndWay(0, 1);

            public CountAndWay(int count, Modular way)
            {
                Count = count;
                Way = way;
            }

            public void Deconstruct(out int count, out Modular arg2) => (count, arg2) = (Count, Way);
            public override string ToString() => $"{nameof(Count)}: {Count}, {nameof(Way)}: {Way}";

            public CountAndWay AddRoot() => new CountAndWay(Count + 1, Way);

            public CountAndWay Multiply(CountAndWay other)
            {
                var sum = Count + other.Count;
                var way = Modular.Combination(sum, Count) * Way * other.Way;
                return new CountAndWay(sum, way);
            }
        }
    }
}
