using Training20200606.Questions;
using Training20200606.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200606.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc054/tasks/abc054_c
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        List<int>[] _edges;
        int _count;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var nodeCount = nm[0];
            var edgeCount = nm[1];

            _edges = Enumerable.Repeat(0, nodeCount).Select(_ => new List<int>()).ToArray();

            for (int i = 0; i < edgeCount; i++)
            {
                var ab = inputStream.ReadIntArray().Select(n => n - 1).ToArray();
                var a = ab[0];
                var b = ab[1];
                _edges[a].Add(b);
                _edges[b].Add(a);
            }
            var seen = new Stack<int>();
            seen.Push(0);
            Search(seen, 0, 1);

            yield return _count;
        }

        void Search(Stack<int> seen, int current, int depth)
        {
            var nodeCount = _edges.Length;
            if (depth == nodeCount)
            {
                _count++;
                return;
            }

            foreach (var next in _edges[current])
            {
                if (seen.Contains(next))
                {
                    continue;
                }

                seen.Push(next);
                Search(seen, next, depth + 1);
                seen.Pop();
            }
        }
    }
}
