using AtcoderBeginnerContest160.Questions;
using AtcoderBeginnerContest160.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtcoderBeginnerContest160.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        int[] minDistanceCount = null;
        int[] distances = null;
        readonly Queue<int> todo = new Queue<int>();
        int n;
        int x;
        int y;


        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nxy = inputStream.ReadIntArray();
            n = nxy[0];
            x = nxy[1];
            y = nxy[2];

            minDistanceCount = new int[n];
            distances = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                Search(i);
            }

            for (int i = 1; i < n; i++)
            {
                yield return minDistanceCount[i] / 2;
            }
        }

        void Search(int startIndex)
        {
            todo.Clear();
            todo.Enqueue(startIndex);

            InitializeDistance();
            distances[startIndex] = 0;

            while (todo.Count > 0)
            {
                var current = todo.Dequeue();
                var nextDistance = distances[current] + 1;

                if (current > 1 && distances[current - 1] < 0)
                {
                    distances[current - 1] = nextDistance;
                    minDistanceCount[nextDistance] += 1;
                    todo.Enqueue(current - 1);
                }
                if (current < n && distances[current + 1] < 0)
                {
                    distances[current + 1] = nextDistance;
                    minDistanceCount[nextDistance] += 1;
                    todo.Enqueue(current + 1);
                }
                if (current == x && distances[y] < 0)
                {
                    distances[y] = nextDistance;
                    minDistanceCount[nextDistance] += 1;
                    todo.Enqueue(y);
                }
                if (current == y && distances[x] < 0)
                {
                    distances[x] = nextDistance;
                    minDistanceCount[nextDistance] += 1;
                    todo.Enqueue(x);
                }
            }
        }

        void InitializeDistance()
        {
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = -1;
            }
        }
    }
}
