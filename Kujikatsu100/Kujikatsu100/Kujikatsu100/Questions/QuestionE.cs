using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu100.Algorithms;
using Kujikatsu100.Collections;
using Kujikatsu100.Numerics;
using Kujikatsu100.Questions;
using Kujikatsu100.Graphs;

namespace Kujikatsu100.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var nodes = io.ReadInt();
            var graph = new BasicGraph(nodes);

            for (int i = 0; i < nodes - 1; i++)
            {
                var a = io.ReadInt() - 1;
                var b = io.ReadInt() - 1;
                graph.AddEdge(new BasicEdge(a, b));
                graph.AddEdge(new BasicEdge(b, a));
            }

            var costs = io.ReadIntArray(nodes);
            Array.Sort(costs, (a, b) => b - a);

            var queue = new Queue<int>(costs);
            var results = new int[nodes];

            Dfs(0, -1);

            io.WriteLine(costs.Sum() - costs.Max());
            io.WriteLine(results, ' ');

            void Dfs(int current, int parent)
            {
                results[current] = queue.Dequeue();
                foreach (var edge in graph[current])
                {
                    var next = edge.To.Index;
                    if (next != parent)
                    {
                        Dfs(next, current);
                    }
                }
            }
        }
    }
}
