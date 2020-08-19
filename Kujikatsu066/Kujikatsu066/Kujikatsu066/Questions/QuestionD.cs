using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu066.Algorithms;
using Kujikatsu066.Collections;
using Kujikatsu066.Extensions;
using Kujikatsu066.Numerics;
using Kujikatsu066.Questions;

namespace Kujikatsu066.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc160/tasks/abc160_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, x, y) = inputStream.ReadValue<int, int, int>();

            var counts = new int[n];

            for (int i = 1; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    counts[Math.Min(j - i, Math.Abs(x - i) + 1 + Math.Abs(j - y))]++;
                }
            }

            for (int i = 1; i < n; i++)
            {
                yield return counts[i];
            }
        }
    }
}
