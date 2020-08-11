using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu058.Algorithms;
using Kujikatsu058.Collections;
using Kujikatsu058.Extensions;
using Kujikatsu058.Numerics;
using Kujikatsu058.Questions;

namespace Kujikatsu058.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc154/tasks/abc154_e
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var k = inputStream.ReadInt();

            const int Equal = 0;
            const int Less = 1;
            var dp = new long[s.Length + 1, 2, k + 1];
            dp[0, Equal, 0] = 1;

            for (int i = 0; i < s.Length; i++)
            {
                var current = s[i] - '0';

                for (int nonZero = 0; nonZero <= k; nonZero++)
                {
                    // Equal時
                    if (current == 0)
                    {
                        dp[i + 1, Equal, nonZero] += dp[i, Equal, nonZero];
                    }
                    else
                    {
                        dp[i + 1, Less, nonZero] += dp[i, Equal, nonZero];
                        if (nonZero < k)
                        {
                            dp[i + 1, Less, nonZero + 1] += dp[i, Equal, nonZero] * (current - 1);
                            dp[i + 1, Equal, nonZero + 1] += dp[i, Equal, nonZero];
                        }
                    }

                    // Not Equal時
                    dp[i + 1, Less, nonZero] += dp[i, Less, nonZero];

                    if (nonZero < k)
                    {
                        dp[i + 1, Less, nonZero + 1] += dp[i, Less, nonZero] * 9;
                    }
                }
            }

            long result = dp[s.Length, Equal, k] + dp[s.Length, Less, k];
            yield return result;
        }
    }
}
