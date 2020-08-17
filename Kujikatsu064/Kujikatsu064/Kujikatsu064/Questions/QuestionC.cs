using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu064.Algorithms;
using Kujikatsu064.Collections;
using Kujikatsu064.Extensions;
using Kujikatsu064.Numerics;
using Kujikatsu064.Questions;

namespace Kujikatsu064.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/caddi2018/tasks/caddi2018_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, p) = inputStream.ReadValue<long, long>();

            long result = 1;

            foreach (var (prime, count) in PrimeFactorize(p))
            {
                var each = count / n;
                for (int i = 0; i < each; i++)
                {
                    result *= prime;
                }
            }

            yield return result;
        }

        Dictionary<long, long> PrimeFactorize(long n)
        {
            var result = new Dictionary<long, long>();
            for (long p = 2; p * p <= n; p++)
            {
                var count = 0;
                while (n % p == 0)
                {
                    count++;
                    n /= p;
                }
                if (count > 0)
                {
                    result[p] = count;
                }
            }

            if (n > 1)
            {
                result[n] = 1;
            }

            return result;
        }
    }
}
