using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu057.Algorithms;
using Kujikatsu057.Collections;
using Kujikatsu057.Extensions;
using Kujikatsu057.Numerics;
using Kujikatsu057.Questions;

namespace Kujikatsu057.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc125/tasks/abc125_c
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var leftGcd = new long[n + 1];
            var rightGcd = new long[n + 1];

            for (int i = 0; i < a.Length; i++)
            {
                leftGcd[i + 1] = NumericalAlgorithms.Gcd(leftGcd[i], a[i]);
            }

            for (int i = a.Length - 1; i >= 0; i--)
            {
                rightGcd[i] = NumericalAlgorithms.Gcd(rightGcd[i + 1], a[i]);
            }

            long max = 1;

            for (int i = 0; i < a.Length; i++)
            {
                max = Math.Max(max, NumericalAlgorithms.Gcd(leftGcd[i], rightGcd[i + 1]));
            }

            yield return max;
        }
    }
}
