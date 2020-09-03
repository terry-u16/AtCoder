using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu20200830.Algorithms;
using Kujikatsu20200830.Collections;
using Kujikatsu20200830.Extensions;
using Kujikatsu20200830.Numerics;
using Kujikatsu20200830.Questions;

namespace Kujikatsu20200830.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc100/tasks/arc100_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            for (int i = 0; i < a.Length; i++)
            {
                a[i] -= i + 1;
            }

            Array.Sort(a);

            var min = long.MaxValue;

            for (int i = a.Length / 2; i < Math.Min(a.Length, a.Length / 2 + 1); i++)
            {
                var b = a[i];
                var sum = 0L;
                foreach (var ai in a)
                {
                    sum += Math.Abs(ai - b);
                }
                min = Math.Min(min, sum);
            }

            yield return min;
        }
    }
}
