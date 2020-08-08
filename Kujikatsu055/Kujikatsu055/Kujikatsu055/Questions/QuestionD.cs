using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu055.Algorithms;
using Kujikatsu055.Collections;
using Kujikatsu055.Extensions;
using Kujikatsu055.Numerics;
using Kujikatsu055.Questions;

namespace Kujikatsu055.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc048/tasks/arc064_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, x) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();

            long result = 0;

            if (a[0] > x)
            {
                result += a[0] - x;
                a[0] -= a[0] - x;
            }

            for (int i = 1; i < a.Length; i++)
            {
                var sum = a[i - 1] + a[i];
                if (sum > x)
                {
                    result += sum - x;
                    a[i] -= sum - x;
                }
            }

            yield return result;
        }
    }
}
