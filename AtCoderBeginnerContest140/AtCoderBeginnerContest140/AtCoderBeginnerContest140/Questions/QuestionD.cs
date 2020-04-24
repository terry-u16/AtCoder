using AtCoderBeginnerContest140.Questions;
using AtCoderBeginnerContest140.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest140.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];
            var s = "_" + inputStream.ReadLine() + "_";

            var happyCount = 0;

            for (int i = 1; i <= n; i++)
            {
                if ((s[i] == 'L' && s[i - 1] == 'L') || (s[i] == 'R' && s[i + 1] == 'R'))
                {
                    happyCount++;
                }
            }

            yield return Math.Min(happyCount + 2 * k, n - 1);
        }
    }
}
