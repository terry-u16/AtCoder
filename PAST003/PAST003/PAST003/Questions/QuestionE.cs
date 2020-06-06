using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PAST003.Algorithms;
using PAST003.Collections;
using PAST003.Extensions;
using PAST003.Numerics;
using PAST003.Questions;

namespace PAST003.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (nodesCount, edgesCount, queriesCount) = inputStream.ReadValue<int, int, int>();
            var graph = Enumerable.Repeat(0, nodesCount).Select(_ => new List<int>()).ToArray();

            for (int i = 0; i < edgesCount; i++)
            {
                var (u, v) = inputStream.ReadValue<int, int>();
                u--;
                v--;
                graph[u].Add(v);
                graph[v].Add(u);
            }

            var colors = inputStream.ReadIntArray();

            for (int query = 0; query < queriesCount; query++)
            {
                var input = inputStream.ReadIntArray();
                var selectedNode = input[1] - 1;
                yield return colors[selectedNode];
                
                if (input[0] == 1)
                {
                    Paint(graph, colors, selectedNode);
                }
                else
                {
                    var color = input[2];
                    colors[selectedNode] = color;
                }
            }
        }

        void Paint(List<int>[] graph, int[] colors, int node)
        {
            foreach (var nextNode in graph[node])
            {
                colors[nextNode] = colors[node];
            }
        }
    }
}
