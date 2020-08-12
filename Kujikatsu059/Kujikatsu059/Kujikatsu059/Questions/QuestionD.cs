using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu059.Algorithms;
using Kujikatsu059.Collections;
using Kujikatsu059.Extensions;
using Kujikatsu059.Numerics;
using Kujikatsu059.Questions;

namespace Kujikatsu059.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc067/tasks/arc067_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var counts = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                var current = i;
                for (int div = 2; div * div <= n; div++)
                {
                    while (current % div == 0)
                    {
                        counts[div]++;
                        current /= div;
                    }
                }
                if (current > 1)
                {
                    counts[current]++;
                }
            }

            long result = 1;

            for (int i = 0; i < counts.Length; i++)
            {
                result *= counts[i] + 1;
                result %= 1000000007;
            }

            yield return result;
        }
    }
}
