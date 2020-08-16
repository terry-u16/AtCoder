using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu063.Algorithms;
using Kujikatsu063.Collections;
using Kujikatsu063.Extensions;
using Kujikatsu063.Numerics;
using Kujikatsu063.Questions;

namespace Kujikatsu063.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc169/tasks/abc169_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();

            var result = 0;

            foreach (var (p, count) in PrimeFactorize(n))
            {
                var total = 0;
                for (int i = 1; true; i++)
                {
                    total += i;
                    if (total <= count)
                    {
                        result += 1;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            yield return result;
        }

        IEnumerable<(long p, int count)> PrimeFactorize(long n)
        {
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
                    yield return (p, count);
                }
            }

            if (n > 1)
            {
                yield return (n, 1);
            }
        }

    }
}
