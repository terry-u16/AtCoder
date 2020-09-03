using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu081.Algorithms;
using Kujikatsu081.Collections;
using Kujikatsu081.Extensions;
using Kujikatsu081.Numerics;
using Kujikatsu081.Questions;

namespace Kujikatsu081.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc100/tasks/arc100_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            for (int i = 0; i < a.Length; i++)
            {
                a[i] -= i + 1;
            }

            Array.Sort(a);

            var min = GetDiffSum(a, a[a.Length / 2]);
            if (n > 1)
            {
                min = Math.Min(min, GetDiffSum(a, a[a.Length / 2 + 1]));
            }

            yield return min;
        }

        long GetDiffSum(long[] a, long median)
        {
            var sum = 0L;
            foreach (var ai in a)
            {
                sum += Math.Abs(ai - median);
            }
            return sum;
        }
    }
}
