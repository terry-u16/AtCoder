using Yorukatsu056.Questions;
using Yorukatsu056.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu056.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc080/tasks/abc080_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nc = inputStream.ReadIntArray();
            var programCount = nc[0];
            var channels = nc[1];

            var programs = Enumerable.Repeat(0, channels).Select(_ => new List<TVProgram>()).ToArray();

            for (int i = 0; i < programCount; i++)
            {
                var stc = inputStream.ReadIntArray();
                var program = new TVProgram(stc[0], stc[1]);
                var channel = stc[2] - 1;
                programs[channel].Add(program);
            }

            var usedDecks = new int[100001];

            for (int channel = 0; channel < programs.Length; channel++)
            {
                var channelPrograms = programs[channel];
                channelPrograms.Sort();
                for (int prog = 0; prog < channelPrograms.Count; prog++)
                {
                    var hasPrevious = prog > 0 && channelPrograms[prog - 1].EndTime == channelPrograms[prog].StartTime;
                    if (hasPrevious)
                    {
                        usedDecks[channelPrograms[prog].StartTime]++;
                    }
                    else
                    {
                        usedDecks[channelPrograms[prog].StartTime - 1]++;
                    }

                    usedDecks[channelPrograms[prog].EndTime]--;
                }
            }

            for (int time = 0; time + 1 < usedDecks.Length; time++)
            {
                usedDecks[time + 1] += usedDecks[time];
            }

            yield return usedDecks.Max();
        }

        struct TVProgram : IComparable<TVProgram>
        {
            public int StartTime { get; }
            public int EndTime { get; }

            public TVProgram(int startTime, int endTime)
            {
                StartTime = startTime;
                EndTime = endTime;
            }

            public int CompareTo(TVProgram other) => StartTime.CompareTo(other.StartTime);
        }
    }
}
