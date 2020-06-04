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
    /// https://atcoder.jp/contests/abc084/tasks/abc084_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var schedules = new TrainSchedule[n - 1];

            for (int i = 0; i < schedules.Length; i++)
            {
                var csf = inputStream.ReadIntArray();
                schedules[i] = new TrainSchedule(csf[0], csf[1], csf[2]);
            }

            for (int startStation = 0; startStation < schedules.Length; startStation++)
            {
                var currentTime = 0;
                foreach (var schedule in schedules.Skip(startStation))
                {
                    currentTime = schedule.GetNextDepartureTime(currentTime) + schedule.Take;
                }

                yield return currentTime;
            }

            yield return 0;
        }

        struct TrainSchedule
        {
            public int Take { get; }
            public int Since { get; set; }
            public int Cycle { get; }

            public TrainSchedule(int take, int since, int cycle)
            {
                Take = take;
                Since = since;
                Cycle = cycle;
            }

            public int GetNextDepartureTime(int currentTime) => Math.Max(Since, (currentTime + Cycle - 1) / Cycle * Cycle);
        }
    }
}
