using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest161.Extensions;

namespace AtCoderBeginnerContest161.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<string> Solve(TextReader inputStream)
        {
            var nkc = inputStream.ReadIntArray();
            var n = nkc[0];
            var k = nkc[1];
            var c = nkc[2];
            var s = inputStream.ReadLine();
            var holidays = s.Select((ch, i) => new { Ch = ch, Index = i })
                .Where(t => t.Ch == 'x')
                .Select(t => t.Index)
                .ToArray();

            var flags = new bool[n];
            for (int i = 0; i < n; i++)
            {
                flags[i] = true;
            }

            for (int i = 0; i < holidays.Length; i++)
            {
                for (int j = (c - 1); j < c - 1; j++)
                {
                    int index = holidays[i] + j;
                    if (index >= 0 && index < flags.Length)
                    {
                        flags[index] = false;
                    }
                }
            }

            var workdays = flags.Select((b, i) => new { Works = b, Index = i })
                .Where(t => t.Works)
                .Select(t => t.Index + 1);

            return workdays.Select(i => i.ToString());
        }
    }
}
