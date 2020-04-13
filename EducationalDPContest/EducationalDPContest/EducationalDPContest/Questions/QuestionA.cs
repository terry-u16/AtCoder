using EducationalDPContest.Questions;
using EducationalDPContest.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalDPContest.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            int n = inputStream.ReadInt();
            var h = inputStream.ReadIntArray();
            var dp = Enumerable.Repeat(int.MaxValue, n).ToArray();

            dp[0] = 0;

            for (int i = 1; i < n; i++)
            {
                dp[i] = Math.Min(dp[i], dp[i - 1] + Math.Abs(h[i] - h[i - 1]));
                if (i > 1)
                {
                    dp[i] = Math.Min(dp[i], dp[i - 2] + Math.Abs(h[i] - h[i - 2]));
                }
            }

            yield return dp[n - 1];
        }
    }
}
