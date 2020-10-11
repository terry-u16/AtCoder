using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu115.Algorithms;
using Kujikatsu115.Collections;
using Kujikatsu115.Numerics;
using Kujikatsu115.Questions;
using System.Numerics;

namespace Kujikatsu115.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc117/tasks/abc117_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var k = io.ReadLong();
            var a = io.ReadLongArray(n);

            var maxDigit = BitOperations.Log2((ulong)k);

            const int Eq = 0;
            const int Less = 1;
            var dp = new long[42, 2];

            for (int i = 0; i < 42; i++)
            {
                dp[i, Less] = long.MinValue;
            }

            for (int digit = 40; digit >= 0; digit--)
            {
                long ones = a.Count(ai => (ai & (1L << digit)) > 0);
                long zeros = n - ones;

                // 0にする
                dp[digit, Eq].ChangeMax(dp[digit + 1, Eq] + (ones << digit));
                dp[digit, Less].ChangeMax(dp[digit + 1, Less] + (ones << digit));
                if ((k & (1L << digit)) > 0)
                {
                    dp[digit, Less].ChangeMax(dp[digit + 1, Eq] + (ones << digit));
                }

                // 1にする
                dp[digit, Less].ChangeMax(dp[digit + 1, Less] + (zeros << digit));
                if ((k & (1L << digit)) > 0)
                {
                    dp[digit, Eq].ChangeMax(dp[digit + 1, Eq] + (zeros << digit));
                }
            }

            io.WriteLine(Math.Max(dp[0, Eq], dp[0, Less]));
        }
    }
}
