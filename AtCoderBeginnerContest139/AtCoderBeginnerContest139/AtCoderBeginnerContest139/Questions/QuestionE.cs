using AtCoderBeginnerContest139.Questions;
using AtCoderBeginnerContest139.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest139.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var opponents = new Queue<int>[n];

            for (int i = 0; i < n; i++)
            {
                opponents[i] = new Queue<int>(inputStream.ReadIntArray().Select(j => j - 1));
            }

            var day = 0;
            while (opponents.Any(q => q.Any()))
            {
                day++;
                var todaysMatches = new Queue<int>();

                for (int player = 0; player < n; player++)
                {
                    if (opponents[player].Any())
                    {
                        var opponent = opponents[player].Peek();
                        if (opponents[opponent].Peek() == player) // 相手と対戦可能なら
                        {
                            todaysMatches.Enqueue(player);
                        }
                    }
                }

                if (todaysMatches.Any())
                {
                    foreach (var match in todaysMatches)
                    {
                        opponents[match].Dequeue();
                    }
                }
                else
                {
                    yield return -1;
                    yield break;
                }
            }

            yield return day;
        }
    }
}
