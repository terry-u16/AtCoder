using AtCoderBeginnerContest167.Algorithms;
using AtCoderBeginnerContest167.Collections;
using AtCoderBeginnerContest167.Questions;
using AtCoderBeginnerContest167.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest167.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (towns, teleportCount) = inputStream.ReadValue<int, long>();
            var teleportDestinations = inputStream.ReadIntArray().Select(i => i - 1).ToArray();
            var visited = Enumerable.Repeat(-1, towns).ToArray();
            var visitedNumbers = new List<int>();

            int current = 0;
            visited[current] = 0;
            visitedNumbers.Add(current);

            for (int teleportation = 1; true; teleportation++)
            {
                var next = teleportDestinations[current];
                if (visited[next] >= 0)
                {
                    var firstVisit = visited[next];
                    var loop = teleportation - firstVisit;
                    yield return visitedNumbers[(int)((teleportCount - firstVisit) % loop) + firstVisit] + 1;
                    break;
                }
                else if (teleportation == teleportCount)
                {
                    yield return next + 1;
                    yield break;
                }
                visited[next] = teleportation;
                visitedNumbers.Add(next);
                current = next;
            }
        }
    }
}
