using AtCoderBeginnerContest168.Algorithms;
using AtCoderBeginnerContest168.Collections;
using AtCoderBeginnerContest168.Questions;
using AtCoderBeginnerContest168.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest168.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (roomsCount, pathwaysCount) = inputStream.ReadValue<int, int>();
            var pathways = Enumerable.Repeat(0, roomsCount).Select(_ => new List<int>()).ToArray();

            for (int i = 0; i < pathwaysCount; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                a--;
                b--;
                pathways[a].Add(b);
                pathways[b].Add(a);
            }

            var guideposts = new int[roomsCount];

            var toDo = new Queue<int>();
            var seen = new bool[roomsCount];
            toDo.Enqueue(0);
            seen[0] = true;

            while (toDo.Count > 0)
            {
                var current = toDo.Dequeue();
                foreach (var next in pathways[current])
                {
                    if (!seen[next])
                    {
                        toDo.Enqueue(next);
                        seen[next] = true;
                        guideposts[next] = current;
                    }
                }
            }

            yield return "Yes";

            foreach (var guidepost in guideposts.Skip(1))
            {
                yield return guidepost + 1;
            }
        }
    }
}
