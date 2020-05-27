using Training20200527.Questions;
using Training20200527.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Training20200527.Questions
{
    /// <summary>
    /// ABC067 D
    /// https://atcoder.jp/contests/abc067/tasks/arc078_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        List<int>[] _edges;
        Color[] _colors;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            _edges = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();

            for (int i = 0; i < n - 1; i++)
            {
                var ab = inputStream.ReadIntArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                _edges[a].Add(b);
                _edges[b].Add(a);
            }

            _colors = new Color[n];

            Paint();
            var blacks = Count(0, Color.Black);
            var whites = Count(n - 1, Color.White);

            if (blacks > whites)
            {
                yield return "Fennec";
            }
            else
            {
                yield return "Snuke";
            }
        }

        int Count(int start, Color color)
        {
            var todo = new Queue<int>();
            var seen = new bool[_edges.Length];
            todo.Enqueue(start);
            seen[start] = true;
            var count = 1;

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                foreach (var next in _edges[current])
                {
                    if (seen[next] || !(_colors[next] == Color.None || _colors[next] == color))
                    {
                        continue;
                    }
                    count++;
                    seen[next] = true;
                    todo.Enqueue(next);
                }
            }

            return count;
        }

        void Paint()
        {
            var shortestPath = GetShotestPath(0, _edges.Length - 1);
            for (int i = 0; i < shortestPath.Count; i++)
            {
                if (!Paint(shortestPath[i], Color.Black) || !Paint(shortestPath[shortestPath.Count - i - 1], Color.White))
                {
                    break;
                }
            }
        }

        bool Paint(int node, Color color)
        {
            if (_colors[node] == Color.None)
            {
                _colors[node] = color;
                return true;
            }
            else
            {
                return false;
            }
        }

        IList<int> GetShotestPath(int from, int to)
        {
            var todo = new Queue<int>();
            var distance = new int[_edges.Length];
            var seen = new bool[_edges.Length];
            todo.Enqueue(to);
            seen[to] = true;

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                foreach (var next in _edges[current])
                {
                    if (seen[next])
                    {
                        continue;
                    }

                    distance[next] = distance[current] + 1;
                    seen[next] = true;
                    todo.Enqueue(next);
                }
            }

            var path = new List<int>(distance[from]);
            path.Add(from);
            todo.Enqueue(from);

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                foreach (var next in _edges[current])
                {
                    if (distance[next] >= distance[current])
                    {
                        continue;
                    }

                    path.Add(next);
                    todo.Enqueue(next);
                }
            }

            return path;
        }


        enum Color
        {
            None = 0,
            Black,
            White
        }
    }
}
