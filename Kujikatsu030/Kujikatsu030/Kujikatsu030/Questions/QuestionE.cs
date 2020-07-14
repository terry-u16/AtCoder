using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu030.Algorithms;
using Kujikatsu030.Collections;
using Kujikatsu030.Extensions;
using Kujikatsu030.Numerics;
using Kujikatsu030.Questions;

namespace Kujikatsu030.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc114/tasks/abc114_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var primes = Enumerable.Range(1, n).SelectMany(PrimeFactorization).GroupBy(p => p).Select(g => (prime: g.Key, count: g.Count())).ToArray();

            var overTwo = primes.Count(g => g.count >= 2);  // 厳密にはoverではない
            var overFour = primes.Count(g => g.count >= 4);
            var twoOrThree = overTwo - overFour;

            var count = 0;
            if (twoOrThree >= 1 && overFour >= 2)
            {
                count += twoOrThree * overFour * (overFour - 1) / 2;
            }
            if (overFour >= 3)
            {
                count += overFour * (overFour - 1) * (overFour - 2) / 2;
            }

            var overFourteen = primes.Count(g => g.count >= 14);
            var betweenFourToThirteen = overFour - overFourteen;
            if (betweenFourToThirteen >= 1 && overFourteen >= 1)
            {
                count += betweenFourToThirteen * overFourteen;
            }
            if (overFourteen >= 2)
            {
                count += overFourteen * (overFourteen - 1);
            }

            var overTwentyFour = primes.Count(g => g.count >= 24);
            var betweenTwoToTwentyThree = overTwo - overTwentyFour;
            if (betweenTwoToTwentyThree >= 1 && overTwentyFour >= 1)
            {
                count += betweenTwoToTwentyThree * overTwentyFour;
            }
            if (overTwentyFour >= 2)
            {
                count += overTwentyFour * (overTwentyFour - 1);
            }

            var overSeventyFour = primes.Count(g => g.count >= 74);
            if (overSeventyFour >= 1)
            {
                count += overSeventyFour;
            }

            yield return count;
        }

        IEnumerable<int> PrimeFactorization(int n)
        {
            var current = n;
            for (int i = 2; i * i <= n; i++)
            {
                while (current % i == 0)
                {
                    yield return i;
                    current /= i;
                }
            }

            if (current > 1)
            {
                yield return current;
            }
        }
    }
}
