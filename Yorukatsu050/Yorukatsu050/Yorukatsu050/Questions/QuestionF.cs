using Yorukatsu050.Questions;
using Yorukatsu050.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu050.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc161/tasks/abc161_e
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nkc = inputStream.ReadIntArray();
            var totalDaysCount = nkc[0];
            var workDaysCount = nkc[1];
            var interval = nkc[2];
            var plan = inputStream.ReadLine();

            var earliestWorkdays = GetEarliestWorkdays(plan, workDaysCount, interval);
            var latestWorkdays = GetLatestWorkdays(plan, workDaysCount, interval);

            var outputLines = 0;
            for (int workCount = 0; workCount < earliestWorkdays.Length; workCount++)
            {
                if (earliestWorkdays[workCount] == latestWorkdays[workCount])
                {
                    yield return earliestWorkdays[workCount] + 1;
                    outputLines++;
                }
            }
            if (outputLines == 0)
            {
                yield return string.Empty;
            }
        }

        int[] GetEarliestWorkdays(string plan, int workDaysCount, int requiredInterval)
        {
            var earliestWorkDays = new int[workDaysCount];
            var day = 0;
            var interval = 1 << 25;
            for (int workDay = 0; workDay < earliestWorkDays.Length; workDay++)
            {
                while (plan[day] == 'x' || interval <= requiredInterval)
                {
                    day++;
                    interval++;
                }
                earliestWorkDays[workDay] = day++;
                interval = 1;
            }
            return earliestWorkDays;
        }

        int[] GetLatestWorkdays(string plan, int workDaysCount, int requiredInterval)
        {
            var latestWorkDays = new int[workDaysCount];
            var day = plan.Length - 1;
            var interval = 1 << 25;
            for (int workDay = latestWorkDays.Length - 1; workDay >= 0; workDay--)
            {
                while (plan[day] == 'x' || interval <= requiredInterval)
                {
                    day--;
                    interval++;
                }
                latestWorkDays[workDay] = day--;
                interval = 1;
            }
            return latestWorkDays;
        }

    }
}
