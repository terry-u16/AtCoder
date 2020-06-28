using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200628.Algorithms;
using Training20200628.Collections;
using Training20200628.Extensions;
using Training20200628.Numerics;
using Training20200628.Questions;

namespace Training20200628.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc004/tasks/arc004_4
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.InitializeCombinationTable();
            var (n, m) = inputStream.ReadValue<int, int>();
            var primes = PrimeFactorize(Math.Abs(n)).GroupBy(i => i).Select(g => (g.Key, g.Count()));

            var count = Modular.One;

            foreach (var (_, c) in primes)
            {
                count *= Modular.CombinationWithRepetition(m, c);
            }

            var minusCombination = Modular.Zero;
            for (int i = (-Math.Sign(n) + 1) / 2; i <= m; i += 2)
            {
                minusCombination += Modular.Combination(m, i);
            }

            count *= minusCombination;

            yield return count.Value;
        }

        IEnumerable<int> PrimeFactorize(int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                while (n % i == 0)
                {
                    yield return i;
                    n /= i;
                }
            }

            if (n > 1)
            {
                yield return n;
            }
        }
    }
}
