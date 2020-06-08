using Yorukatsu058.Questions;
using Yorukatsu058.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu058.Questions
{
    public class QuestionF : AtCoderQuestionBase
    {
        List<int>[] _edges;
        bool[] _seen;
        const int limit = 100000;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            _edges = Enumerable.Repeat(0, limit * 2).Select(_ => new List<int>()).ToArray();
            _seen = new bool[limit * 2];

            for (int i = 0; i < n; i++)
            {
                var xy = inputStream.ReadIntArray();
                var x = xy[0] - 1;
                var y = xy[1] - 1 + limit;
                _edges[x].Add(y);
                _edges[y].Add(x);
            }

            var count = Enumerable.Range(0, 2 * limit).Where(i => !_seen[i]).Sum(i => CountEdges(i).GetPairCount());

            yield return count - n;
        }

        Pair CountEdges(int current)
        {
            _seen[current] = true;
            var isX = current < limit;
            var pair = new Pair(isX ? 1 : 0, isX ? 0 : 1);

            foreach (var next in _edges[current])
            {
                if (_seen[next])
                {
                    continue;
                }

                pair += CountEdges(next);
            }

            return pair;
        }

        struct Pair
        {
            public int X { get; }
            public int Y { get; }

            public Pair(int x, int y)
            {
                X = x;
                Y = y;
            }

            public static Pair operator +(Pair a, Pair b) => new Pair(a.X + b.X, a.Y + b.Y);

            public long GetPairCount() => (long)X * Y;
        }
    }
}
