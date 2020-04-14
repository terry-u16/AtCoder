using AtCoderBeginnerContest152.Questions;
using AtCoderBeginnerContest152.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest152.Questions
{
    public class QuestionE_Review : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var primes = new Dictionary<int, int>();

            foreach (var ai in a)
            {
                foreach (var prime in PrimeFactorization(ai))   // 素数, 個数のペア
                {
                    if (primes.ContainsKey(prime.Key))
                    {
                        primes[prime.Key] = Math.Max(primes[prime.Key], prime.Value);
                    }
                    else
                    {
                        primes[prime.Key] = prime.Value;
                    }
                }
            }

            Modular lcm = new Modular(1);
            foreach (var prime in primes)
            {
                lcm *= Modular.Pow(new Modular(prime.Key), prime.Value);
            }

            var sum = new Modular(0);
            foreach (var v in a)
            {
                sum += lcm / new Modular(v);
            }

            yield return sum.Value;
        }

        IEnumerable<KeyValuePair<int, int>> PrimeFactorization(int n)
        {
            var dictionary = new Dictionary<int, int>();
            for (int i = 2; i * i <= n; i++)
            {
                while (n % i == 0)
                {
                    if (dictionary.ContainsKey(i))
                    {
                        dictionary[i]++;
                    }
                    else
                    {
                        dictionary[i] = 1;
                    }

                    n /= i;
                }
            }

            if (n > 1)
            {
                dictionary[n] = 1;
            }

            return dictionary;
        }
    }
}
