using AtCoderBeginnerContest151.Questions;
using AtCoderBeginnerContest151.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest151.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        bool[,] canEnter;
        int h;
        int w;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hw = inputStream.ReadIntArray();
            h = hw[0];
            w = hw[1];

            canEnter = new bool[h + 2, w + 2];

            for (int i = 0; i < h; i++)
            {
                var s = inputStream.ReadLine().Select(c => c == '.').ToArray();

                for (int j = 0; j < s.Length; j++)
                {
                    canEnter[i + 1, j + 1] = s[j];
                }
            }

            var max = int.MinValue;
            for (int i = 1; i <= h; i++)
            {
                for (int j = 1; j <= w; j++)
                {
                    if (canEnter[i, j])
                    {
                        max = Math.Max(max, GetMaxDistance(i, j));
                    }
                }
            }

            yield return max;
        }

        private int GetMaxDistance(int startH, int startW)
        {
            var seen = new bool[h + 2, w + 2];
            var distances = new int[h + 2, w + 2];
            var todo = new Queue<Coordinate>();

            todo.Enqueue(new Coordinate(startH, startW));
            seen[startH, startW] = true;

            while (todo.Any())
            {
                var current = todo.Dequeue();
                var currentDistance = distances[current.H, current.W];

                CheckCanGoAndQueue(current.H + 1, current.W, currentDistance, seen, todo, distances);
                CheckCanGoAndQueue(current.H - 1, current.W, currentDistance, seen, todo, distances);
                CheckCanGoAndQueue(current.H, current.W + 1, currentDistance, seen, todo, distances);
                CheckCanGoAndQueue(current.H, current.W - 1, currentDistance, seen, todo, distances);
            }

            var max = 0;

            for (int i = 1; i <= h; i++)
            {
                for (int j = 1; j <= w; j++)
                {
                    max = Math.Max(max, distances[i, j]);
                }
            }

            return max;
        }

        private void CheckCanGoAndQueue(int nextH, int nextW, int currentDistance, bool[,] seen, Queue<Coordinate> todo, int[,] distances)
        {
            if (canEnter[nextH, nextW] && !seen[nextH, nextW])
            {
                todo.Enqueue(new Coordinate(nextH, nextW));
                seen[nextH, nextW] = true;
                distances[nextH, nextW] = currentDistance + 1;
            }
        }

    }

    struct Coordinate
    {
        public int H { get; }
        public int W { get; }

        public Coordinate(int h, int w)
        {
            H = h;
            W = w;
        }
    }
}
