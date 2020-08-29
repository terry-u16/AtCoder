using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest177.Algorithms;
using AtCoderBeginnerContest177.Collections;
using AtCoderBeginnerContest177.Extensions;
using AtCoderBeginnerContest177.Numerics;
using AtCoderBeginnerContest177.Questions;
using System.Net;

namespace AtCoderBeginnerContest177.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int MaxPrime = 1000;
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var primes = GetPrimes(MaxPrime);

            var appeared = new HashSet<int>();
            foreach (var prime in PrimeFactorize(a[0], primes))
            {
                appeared.Add(prime);
            }

            var pairwise = true;
            for (int i = 1; i < a.Length; i++)
            {
                foreach (var prime in PrimeFactorize(a[i], primes))
                {
                    if (!appeared.Add(prime))
                    {
                        pairwise = false;
                        break;
                    }
                }
            }

            if (pairwise)
            {
                yield return "pairwise coprime";
                yield break;
            }

            long prefixGcd = 0;
            foreach (var ai in a)
            {
                prefixGcd = NumericalAlgorithms.Gcd(prefixGcd, ai);
            }

            if (prefixGcd == 1)
            {
                yield return "setwise coprime";
            }
            else
            {
                yield return "not coprime";
            }
        }

        int[] GetPrimes(int max)
        {
            var isPrime = Enumerable.Repeat(true, max + 1).ToArray();
            isPrime[0] = false;
            isPrime[1] = false;

            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * 2; j < isPrime.Length; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }


            var results = new List<int>();

            for (int i = 0; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    results.Add(i);
                }
            }

            return results.ToArray();
        }

        List<int> PrimeFactorize(int n, int[] primes)
        {
            var result = new List<int>();
            foreach (var prime in primes)
            {
                var added = false;
                while (n % prime == 0)
                {
                    n /= prime;
                    if (!added)
                    {
                        result.Add(prime);
                    }
                    added = true;
                }
            }

            if (n > 1)
            {
                result.Add(n);
            }

            return result;
        }
    }
}
