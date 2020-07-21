using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu037.Algorithms;
using Kujikatsu037.Collections;
using Kujikatsu037.Extensions;
using Kujikatsu037.Numerics;
using Kujikatsu037.Questions;

namespace Kujikatsu037.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc169/tasks/abc169_e
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var mins = new int[n];
            var maxs = new int[n];
            for (int i = 0; i < mins.Length; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                mins[i] = a;
                maxs[i] = b;
            }

            Array.Sort(mins);
            Array.Sort(maxs);

            if (n % 2 == 0)
            {
                var minMedian = mins[n / 2 - 1] + mins[n / 2];
                var maxMedian = maxs[n / 2 - 1] + maxs[n / 2];
                var count = maxMedian - minMedian + 1;
                yield return count;
            }
            else
            {
                var minMedian = mins[n / 2];
                var maxMedian = maxs[n / 2];
                var count = maxMedian - minMedian + 1;
                yield return count;
            }
        }
    }
}
