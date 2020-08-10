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
    /// https://atcoder.jp/contests/abc154/tasks/abc154_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (diceCount, k) = inputStream.ReadValue<int, int>();
            var p = inputStream.ReadDoubleArray();

            var current = 0.0;

            for (int i = 0; i < k; i++)
            {
                current += (p[i] + 1) / 2;
            }

            var max = current;

            for (int i = k; i < p.Length; i++)
            {
                current -= (p[i - k] + 1) / 2;
                current += (p[i] + 1) / 2;
                max = Math.Max(max, current);
            }

            yield return max;
        }
    }
}
