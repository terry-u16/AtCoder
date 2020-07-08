using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu023.Algorithms;
using Kujikatsu023.Collections;
using Kujikatsu023.Extensions;
using Kujikatsu023.Numerics;
using Kujikatsu023.Questions;

namespace Kujikatsu023.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc161/tasks/abc161_f
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();

            var set = new HashSet<long>();
            foreach (var divisior in GetDivisiors(n))
            {
                if (divisior != 1 && Check(n, divisior))
                {
                    set.Add(divisior);
                }
            }

            foreach (var divisior in GetDivisiors(n - 1))
            {
                if (divisior != 1 && Check(n, divisior))
                {
                    set.Add(divisior);
                }
            }

            yield return set.Count;
        }

        IEnumerable<long> GetDivisiors(long n)
        {
            for (long i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    if (i * i != n)
                    {
                        yield return n / i;
                    }
                }
            }
        }

        bool Check(long n, long k)
        {
            while (n % k == 0)
            {
                n /= k;
            }

            return (n % k) == 1;
        }
    }
}
