using EducationalDPContest.Questions;
using EducationalDPContest.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EducationalDPContest.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            int n = inputStream.ReadInt();
            var dp = new int[n, 3];
            Clear(dp);

            var abc = inputStream.ReadIntArray();
            for (int i = 0; i < 3; i++)
            {
                dp[0, i] = abc[i];
            }

            for (int i = 1; i < n; i++)
            {
                abc = inputStream.ReadIntArray();
                dp[i, 0] = Math.Max(dp[i - 1, 1], dp[i - 1, 2]) + abc[0];   // 前日にBかC、当日にA
                dp[i, 1] = Math.Max(dp[i - 1, 0], dp[i - 1, 2]) + abc[1];   // 前日にAかC、当日にB
                dp[i, 2] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]) + abc[2];   // 前日にAかB、当日にC
            }

            yield return Math.Max(dp[n - 1, 0], Math.Max(dp[n - 1, 1], dp[n - 1, 2]));
        }

        void Clear(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = int.MinValue;
                }
            }
        }
    }
}
