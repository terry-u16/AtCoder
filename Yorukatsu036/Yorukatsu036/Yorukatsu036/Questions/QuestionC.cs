using Yorukatsu036.Questions;
using Yorukatsu036.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu036.Questions
{
    /// <summary>
    /// ABC068 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        List<int>[] ships;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var islandsCount = nm[0];
            var shipsCount = nm[1];

            ships = Enumerable.Repeat(0, islandsCount).Select(_ => new List<int>()).ToArray();

            for (int i = 0; i < shipsCount; i++)
            {
                var ab = inputStream.ReadIntArray().Select(j => j - 1).ToArray();
                ships[ab[0]].Add(ab[1]);
                ships[ab[1]].Add(ab[0]);
            }

            var distances = GetDistancesFrom(0);

            yield return distances[islandsCount - 1] <= 2 ? "POSSIBLE" : "IMPOSSIBLE";
        }

        int[] GetDistancesFrom(int start)
        {
            var toGo = new Queue<int>();
            toGo.Enqueue(start);
            var distances = Enumerable.Repeat(1 << 28, ships.Length).ToArray();
            distances[0] = 0;

            while (toGo.Any())
            {
                var current = toGo.Dequeue();
                if (distances[current] <= 2)
                {
                    foreach (var island in ships[current])
                    {
                        if (distances[island] > distances[current])
                        {
                            distances[island] = distances[current] + 1;
                            toGo.Enqueue(island);
                        }
                    }
                }
            }

            return distances;
        }
    }
}
