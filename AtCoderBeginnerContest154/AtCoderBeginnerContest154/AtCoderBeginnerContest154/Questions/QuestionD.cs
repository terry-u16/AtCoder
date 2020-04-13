using AtCoderBeginnerContest154.Questions;
using AtCoderBeginnerContest154.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest154.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];
            var p = inputStream.ReadIntArray();
            var expected = p.Select(i => (double)(i + 1) / 2).ToArray();

            double sum = 0;

            for (int i = 0; i < k; i++)
            {
                sum += expected[i];
            }

            var max = sum;

            for (int i = 1; i + k - 1 < n; i++)
            {
                sum -= expected[i - 1];
                sum += expected[i + k - 1];
                max = Math.Max(max, sum);
            }

            yield return max;
        }
    }
}
