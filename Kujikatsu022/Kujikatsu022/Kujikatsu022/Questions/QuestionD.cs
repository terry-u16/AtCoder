using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu022.Algorithms;
using Kujikatsu022.Collections;
using Kujikatsu022.Extensions;
using Kujikatsu022.Numerics;
using Kujikatsu022.Questions;

namespace Kujikatsu022.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc172/tasks/abc172_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, m, k) = inputStream.ReadValue<int, int, long>();
            var a = inputStream.ReadLongArray();
            var b = inputStream.ReadLongArray();

            var aSum = new long[n + 1];
            var bSum = new long[m + 1];
            for (int i = 0; i < a.Length; i++)
            {
                aSum[i + 1] = aSum[i] + a[i];
            }
            for (int i = 0; i < b.Length; i++)
            {
                bSum[i + 1] = bSum[i] + b[i];
            }

            var max = 0;
            for (int aBooks = aSum.Length - 1; aBooks >= 0; aBooks--)
            {
                if (aSum[aBooks] > k)
                {
                    continue;
                }

                var bBooks = SearchExtensions.GetLessEqualIndex(bSum, k - aSum[aBooks]);
                max = Math.Max(max, aBooks + bBooks);
            }

            yield return max;
        }
    }
}
