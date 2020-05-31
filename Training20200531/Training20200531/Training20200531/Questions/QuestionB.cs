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
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (rooms, paths) = inputStream.ReadValue<int, int>();
            var dungeon = new BasicGraph(rooms);
            for (int i = 0; i < paths; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                dungeon.AddEdge(new BasicEdge(a, b));
                dungeon.AddEdge(new BasicEdge(b, a));
            }

            var solver = new BfsSolver(dungeon);
            var previous = solver.Search(new BasicNode(0));

            yield return "Yes";

            for (int i = 1; i < previous.Length; i++)
            {
                yield return previous[i] + 1;
            }
        }

        class BfsSolver : BfsBase<BasicGraph, BasicNode, BasicEdge, int[]>
        {
            readonly int[] _previous;

            public BfsSolver(BasicGraph graph) : base(graph)
            {
                _previous = new int[graph.NodeCount];
            }

            protected override int[] GetResult()
            {
                return _previous;
            }

            protected override void Initialize(BasicNode startNode)
            {
            }

            protected override void OnPreordering(BasicNode current, BasicNode previous, bool isFirstNode)
            {
                if (!isFirstNode)
                {
                    _previous[current.Index] = previous.Index;
                }
            }
        }
    }
}
