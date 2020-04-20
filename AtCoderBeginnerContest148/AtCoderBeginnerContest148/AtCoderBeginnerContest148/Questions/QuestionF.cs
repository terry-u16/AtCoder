using AtCoderBeginnerContest148.Questions;
using AtCoderBeginnerContest148.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest148.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        List<int>[] nodes;
        int[] takahashiDistances;
        int[] aokiDistances;
        bool[] takahashiCanGo;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nuv = inputStream.ReadIntArray();
            var nodeCount = nuv[0];
            var takahashiPosition = nuv[1] - 1;
            var aokiPosition = nuv[2] - 1;

            nodes = Enumerable.Range(0, nodeCount).Select(_ => new List<int>()).ToArray();
            takahashiDistances = new int[nodeCount];
            aokiDistances = new int[nodeCount];
            takahashiCanGo = Enumerable.Range(0, nodeCount).Select(i => i == takahashiPosition).ToArray();
            for (int i = 0; i < nodeCount - 1; i++)
            {
                var ab = inputStream.ReadIntArray().Select(j => j - 1).ToArray();
                var a = ab[0];
                var b = ab[1];
                nodes[a].Add(b);
                nodes[b].Add(a);
            }

            Search(aokiPosition, false);
            Search(takahashiPosition, true);

            var max = 0;
            for (int i = 0; i < aokiDistances.Length; i++)
            {
                if (takahashiCanGo[i])
                {
                    max = Math.Max(max, aokiDistances[i] - 1);
                }
            }

            yield return max;

            
        }

        void Search(int initialNode, bool isTakahashi)
        {
            var seen = Enumerable.Range(0, nodes.Length).Select(i => i == initialNode).ToArray();
            var toDo = new Queue<int>();
            toDo.Enqueue(initialNode);

            while (toDo.Any())
            {
                var currentNode = toDo.Dequeue();

                foreach (var nextNode in nodes[currentNode].Where(n => !seen[n]))
                {
                    seen[nextNode] = true;

                    if (isTakahashi)
                    {
                        takahashiDistances[nextNode] = takahashiDistances[currentNode] + 1;
                        takahashiCanGo[nextNode] = takahashiDistances[nextNode] <= aokiDistances[nextNode];
                    }
                    else
                    {
                        aokiDistances[nextNode] = aokiDistances[currentNode] + 1;
                    }

                    toDo.Enqueue(nextNode);
                }
            }
        }
    }
}
