using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200711.Algorithms;
using Training20200711.Collections;
using Training20200711.Extensions;
using Training20200711.Numerics;
using Training20200711.Questions;
using Training20200711.Graphs;
using Training20200711.Graphs.Algorithms;

namespace Training20200711.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc160/tasks/abc160_f
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        BasicGraph graph;
        DPState[] dpStates;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.InitializeCombinationTable();
            var nodesCount = inputStream.ReadInt();
            graph = new BasicGraph(nodesCount);

            for (int i = 0; i < nodesCount - 1; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                graph.AddEdge(new BasicEdge(a, b));
                graph.AddEdge(new BasicEdge(b, a));
            }

            dpStates = new DPState[nodesCount];

            for (int i = 0; i < dpStates.Length; i++)
            {
                dpStates[i] = new DPState(new Modular(1), 0);
            }

            var rerooting = new Rerooting<BasicNode, BasicEdge, DPState>(graph);
            var results = rerooting.Solve().Select(r => r.Count.Value);

            foreach (var result in results)
            {
                yield return result;
            }

        }

        struct DPState : ITreeDpState<DPState>
        {
            public Modular Count { get; }
            public int Size { get; }

            public DPState Identity => new DPState(new Modular(1), 0);

            public DPState(Modular count, int size)
            {
                Count = count;
                Size = size;
            }

            public DPState AddRoot() => new DPState(Count, Size + 1);

            public DPState Multiply(DPState other)
            {
                var size = Size + other.Size;
                var count = Modular.Combination(size, Size) * Count * other.Count;
                return new DPState(count, size);
            }
        }
    }
}
