using AtCoderBeginnerContest162.Algorithms;
using AtCoderBeginnerContest162.Collections;
using AtCoderBeginnerContest162.Questions;
using AtCoderBeginnerContest162.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest162.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var primes = GetPrimes(k).ToArray();
            var gcds = new Modular[primes.Length];

            Modular total = new Modular(0);
            for (int i = 1; i <= primes.Length; i++)
            {
                var prime = primes[i - 1];
                total += new Modular(prime) * (Modular.Pow(new Modular(primes.Length - i + 1), n) - Modular.Pow(new Modular(primes.Length - i), n));
            }

            yield return total.Value;
        }

        IEnumerable<int> GetPrimes(int n)
        {
            var max = (int)Math.Sqrt(n);
            var notPrimes = new bool[n];

            for (int i = 2; i <= max; i++)
            {
                if (!notPrimes[i - 1])
                {
                    for (int j = i * 2; j <= n; j += i)
                    {
                        notPrimes[j - 1] = true;
                    }
                }
            }

            return notPrimes.Select((b, i) => (b, i)).Where(p => !p.b).Select(p => p.i + 1);
        }
    }
}
