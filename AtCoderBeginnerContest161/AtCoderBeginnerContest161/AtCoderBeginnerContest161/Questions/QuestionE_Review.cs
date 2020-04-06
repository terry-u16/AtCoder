using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest161.Extensions;

namespace AtCoderBeginnerContest161.Questions
{
    public class QuestionE_Review : AtCoderQuestionBase
    {
        public override IEnumerable<string> Solve(TextReader inputStream)
        {
            var nkc = inputStream.ReadIntArray();
            var n = nkc[0];
            var k = nkc[1];
            var c = nkc[2];
            var s = inputStream.ReadLine();
            var isHolyday = s.Select(ch => ch == 'x').ToArray();

            var early = new int[k];
            var late = new int[k];

            int workdayCount = 0;
            int previous = -(c + 1);
            for (int day = 0; day < n; day++)
            {
                if (!isHolyday[day] && day - previous > c)
                {
                    early[workdayCount++] = day;
                    previous = day;
                }

                if (workdayCount >= k)
                {
                    break;
                }
            }

            workdayCount = k - 1;
            previous = n + c;

            for (int day = n - 1; day >= 0; day--)
            {
                if (!isHolyday[day] && previous - day > c)
                {
                    late[workdayCount--] = day;
                    previous = day;
                }

                if (workdayCount < 0)
                {
                    break;
                }
            }

            for (int workDay = 0; workDay < early.Length; workDay++)
            {
                if (early[workDay] == late[workDay])
                {
                    yield return (early[workDay] + 1).ToString();
                }
            }
        }
    }
}
