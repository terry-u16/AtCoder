using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200730.Algorithms;
using Training20200730.Collections;
using Training20200730.Extensions;
using Training20200730.Numerics;
using Training20200730.Questions;

namespace Training20200730.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc060/tasks/arc060_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, average) = inputStream.ReadValue<int, int>();
            var x = inputStream.ReadIntArray();

            var max = 50 * n;
            var dp = new long[n + 1, n + 1, max + 1];
            dp[0, 0, 0] = 1;

            for (int seen = 0; seen < n; seen++)
            {
                for (int selected = 0; selected <= seen; selected++)
                {
                    for (int sum = 0; sum <= max; sum++)
                    {
                        dp[seen + 1, selected, sum] += dp[seen, selected, sum];

                        if (sum + x[seen] <= max)
                        {
                            dp[seen + 1, selected + 1, sum + x[seen]] += dp[seen, selected, sum];
                        }
                    }
                }
            }

            long result = 0;
            for (int selected = 1; selected <= n; selected++)
            {
                result += dp[n, selected, average * selected];
            }
            yield return result;
        }
    }
}
