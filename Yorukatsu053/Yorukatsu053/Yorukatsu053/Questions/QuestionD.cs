using Yorukatsu053.Questions;
using Yorukatsu053.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu053.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc067/tasks/arc067_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var primes = Enumerable.Range(1, n).SelectMany(i => PrimeFactorize(i)).GroupBy(p => p).ToDictionary(p => p.Key, p => p.Count());

            long count = 1;
            foreach (var p in primes)
            {
                count *= (p.Value + 1);
                count %= 1000000007;
            }

            yield return count;
        }

        IEnumerable<int> PrimeFactorize(int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                while (n % i == 0)
                {
                    n /= i;
                    yield return i;
                }
            }

            if (n > 1)
            {
                yield return n;
            }
        }
    }
}
