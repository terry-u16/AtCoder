using EducationalDPContest.Questions;
using EducationalDPContest.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalDPContest.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            int n = nk[0];
            int k = nk[1];
            var h = inputStream.ReadIntArray();
            var dp = Enumerable.Repeat(int.MaxValue, n).ToArray();

            dp[0] = 0;

            for (int i = 1; i < n; i++)
            {
                for (int j = Math.Max(0, i - k); j < i; j++)
                {
                    dp[i] = Math.Min(dp[i], dp[j] + Math.Abs(h[i] - h[j]));
                }
            }

            yield return dp[n - 1];
        }
    }
}
