using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest169.Algorithms;
using AtCoderBeginnerContest169.Collections;
using AtCoderBeginnerContest169.Extensions;
using AtCoderBeginnerContest169.Numerics;
using AtCoderBeginnerContest169.Questions;

namespace AtCoderBeginnerContest169.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();
            var primes = PrimeFactorize(n).GroupBy(i => i).ToDictionary(g => g.Key);


            var count = 0;
            foreach (var (prime, c) in primes)
            {
                for (int i = 1; true; i++)
                {
                    var pow = Pow(prime, i);
                    if (n % pow == 0)
                    {
                        n /= pow;
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            yield return count;
        }

        long Pow(long n, long k)
        {
            long result = 1;
            for (int i = 0; i < k; i++)
            {
                result *= n;
            }
            return result;
        }

        IEnumerable<long> PrimeFactorize(long n)
        {
            for (long i = 2; i * i <= n; i++)
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
