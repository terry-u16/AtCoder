using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest172.Algorithms;
using AtCoderBeginnerContest172.Collections;
using AtCoderBeginnerContest172.Extensions;
using AtCoderBeginnerContest172.Numerics;
using AtCoderBeginnerContest172.Questions;

namespace AtCoderBeginnerContest172.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            long count = 0;

            var spf = GetSmallestPrimes(n);
            for (int i = 1; i <= n; i++)
            {
                count += i * GetDivisiorCount(i, spf);
            }

            yield return count;
        }

        int[] GetSmallestPrimes(int n)
        {
            var spf = new int[n + 1];

            for (int p = 2; p < spf.Length; p++)
            {
                if (spf[p] == 0)
                {
                    for (int j = 1; p * j <= n; j++)
                    {
                        spf[p * j] = p;
                    }
                }
            }

            return spf;
        }

        long GetDivisiorCount(int n, int[] spf)
        {
            var before = 0;
            var streak = 0;
            long count = 1;

            while (n > 1)
            {
                var p = spf[n];
                if (p == before)
                {
                    streak++;
                }
                else
                {
                    count *= (streak + 1);
                    streak = 1;
                    before = p;
                }
                n /= p;
            }

            if (streak > 0)
            {
                count *= (streak + 1);
            }

            return count;
        }
    }
}
