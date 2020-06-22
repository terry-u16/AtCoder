using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu008.Algorithms;
using Kujikatsu008.Collections;
using Kujikatsu008.Extensions;
using Kujikatsu008.Numerics;
using Kujikatsu008.Questions;
using System.Numerics;

namespace Kujikatsu008.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc044/tasks/agc044_a
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        long a;
        long b;
        long c;
        long d;
        Dictionary<long, long> memo;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                long n;
                (n, a, b, c, d) = inputStream.ReadValue<long, long, long, long, long>();
                memo = new Dictionary<long, long>();
                yield return GetMinCost(n);
            }
        }

        long GetMinCost(long n)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }
            else if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return d;
            }
            else
            {
                var min = long.MaxValue;
                if (new BigInteger(n) * d < long.MaxValue)
                {
                    min = n * d;
                }

                var mod2 = n % 2;
                var mod3 = n % 3;
                var mod5 = n % 5;

                AlgorithmHelpers.UpdateWhenSmall(ref min, GetMinCost((n + 1) / 2) + a + (2 - mod2) * d);
                AlgorithmHelpers.UpdateWhenSmall(ref min, GetMinCost(n / 2) + a + mod2 * d);
                AlgorithmHelpers.UpdateWhenSmall(ref min, GetMinCost((n + 2) / 3) + b + (3 - mod3) * d);
                AlgorithmHelpers.UpdateWhenSmall(ref min, GetMinCost(n / 3) + b + mod3 * d);
                AlgorithmHelpers.UpdateWhenSmall(ref min, GetMinCost((n + 4) / 5) + c + (5 - mod5) * d);
                AlgorithmHelpers.UpdateWhenSmall(ref min, GetMinCost(n / 5) + c + mod5 * d);

                return memo[n] = min;
            }
        }
    }
}
