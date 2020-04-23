using AtCoderBeginnerContest142.Questions;
using AtCoderBeginnerContest142.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest142.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadLongArray();
            var a = ab[0];
            var b = ab[1];

            var divisorsA = GetDivisors(a);
            var divisorsB = GetDivisors(b);
            var commonDivisors = GetCommonDivisors(divisorsA, divisorsB);

            yield return commonDivisors.Count;
        }

        private HashSet<long> GetDivisors(long n)
        {
            var sqrtN = (int)Math.Sqrt(n);
            var divisors = new HashSet<long>();
            divisors.Add(1);

            for (int i = 2; i <= sqrtN; i++)
            {
                while (n % i == 0)
                {
                    if (!divisors.Contains(i))
                    {
                        divisors.Add(i);
                    }
                    n /= i;
                }
            }

            if (n != 1)
            {
                divisors.Add(n);
            }

            return divisors;
        }

        private HashSet<long> GetCommonDivisors(HashSet<long> divisorsA, HashSet<long> divisorsB)
        {
            divisorsA.IntersectWith(divisorsB);
            return divisorsA;
        }
    }
}
