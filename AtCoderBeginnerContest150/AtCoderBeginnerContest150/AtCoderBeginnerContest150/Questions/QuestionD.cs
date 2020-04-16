using AtCoderBeginnerContest150.Questions;
using AtCoderBeginnerContest150.Extensions;
using AtCoderBeginnerContest150.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Numerics;

namespace AtCoderBeginnerContest150.Questions
{

    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nm = inputStream.ReadIntArray();
            var n = nm[0];
            var m = nm[1];

            var a = inputStream.ReadIntArray();
            var halfA = a.Select(i => i / 2).ToArray();
            var lcm = new BigInteger(1);    // ゴリ押し

            var evenCount = f(halfA[0]);
            if (halfA.All(i => f(i) == evenCount))
            {
                halfA = halfA.Select(i => i / (1 << evenCount)).ToArray();
                foreach (var halfAi in halfA)
                {
                    lcm = BasicAlgorithms.Lcm(lcm, halfAi);
                }

                var count = (m / (lcm << evenCount) + 1) / 2;
                yield return count;
            }
            else
            {
                yield return 0;
            }

        }

        private int f(int n)
        {
            int count = 0;
            while (n % 2 == 0)
            {
                n /= 2;
                count++;
            }
            return count;
        }
    }
}
