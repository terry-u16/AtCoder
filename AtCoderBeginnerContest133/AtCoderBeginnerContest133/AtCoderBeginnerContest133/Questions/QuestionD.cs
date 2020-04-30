using AtCoderBeginnerContest133.Questions;
using AtCoderBeginnerContest133.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest133.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            var rains = new long[n];

            for (int i = 0; i < n; i++)
            {
                rains[0] += a[i] * (i % 2 == 0 ? 1 : -1);
            }

            for (int i = 1; i < n; i++)
            {
                rains[i] = 2 * a[i - 1] - rains[i - 1];
            }

            yield return string.Join(" ", rains);
        }
    }
}
