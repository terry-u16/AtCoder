using Yorukatsu018.Questions;
using Yorukatsu018.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu018.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        int n;
        int m;
        List<int?>[] nodes;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            n = nm[0];
            m = nm[1];

            nodes = Enumerable.Range(0, n).Select(_ => new List<int?>()).ToArray();
            var inputs = new int[m][];

            for (int i = 0; i < m; i++)
            {
                var ab = inputStream.ReadIntArray().Select(x => x - 1).ToArray();
                inputs[i] = ab;
                var a = ab[0];
                var b = ab[1];
                nodes[a].Add(b);
                nodes[b].Add(a);
            }

            var bridgesCount = 0;
            foreach (var input in inputs)
            {
                var a = input[0];
                var b = input[1];

                var indexA = nodes[a].IndexOf(b);
                var indexB = nodes[b].IndexOf(a);
                nodes[a][indexA] = null;
                nodes[b][indexB] = null;
                if (!GraphIsConnected())
                {
                    bridgesCount++;
                }
                nodes[a][indexA] = b;
                nodes[b][indexB] = a;
            }

            yield return bridgesCount;
        }

        private bool GraphIsConnected()
        {
            var seen = new bool[n];
            seen[0] = true;
            var todo = new Queue<int>();
            todo.Enqueue(0);

            while (todo.Any())
            {
                var current = todo.Dequeue();
                foreach (var nextNode in nodes[current].Where(i => i.HasValue && !seen[i.Value]).Select(i => i.Value))
                {
                    seen[nextNode] = true;
                    todo.Enqueue(nextNode);
                }
            }

            return seen.All(b => b);
        }
    }
}
