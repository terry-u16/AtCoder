using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu036.Algorithms;
using Kujikatsu036.Collections;
using Kujikatsu036.Extensions;
using Kujikatsu036.Numerics;
using Kujikatsu036.Questions;

namespace Kujikatsu036.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var sums = new long[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
            {
                sums[i + 1] = sums[i] + a[i];
            }

            var total = sums[^1];
            long min = long.MaxValue;

            for (int i = 1; i < sums.Length - 1; i++)
            {
                var x = sums[i];
                var y = total - x;
                min = Math.Min(min, Math.Abs(x - y));
            }

            yield return min;
        }
    }
}
