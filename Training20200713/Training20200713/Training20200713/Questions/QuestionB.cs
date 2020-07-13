using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200713.Algorithms;
using Training20200713.Collections;
using Training20200713.Extensions;
using Training20200713.Numerics;
using Training20200713.Questions;

namespace Training20200713.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc034/tasks/arc034_3
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b) = inputStream.ReadValue<int, int>();
            var primes = Enumerable.Range(b + 1, a - b).SelectMany(k => PrimeFactorize(k)).GroupBy(p => p).Select(g => (g.Key, g.Count())).ToArray();

            var count = Modular.One;

            foreach (var (prime, c) in primes)
            {
                count *= (c + 1);
            }

            yield return count.Value;
        }

        IEnumerable<int> PrimeFactorize(int n)
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
