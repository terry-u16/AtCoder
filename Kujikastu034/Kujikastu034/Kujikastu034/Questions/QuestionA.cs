using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikastu034.Algorithms;
using Kujikastu034.Collections;
using Kujikastu034.Extensions;
using Kujikastu034.Numerics;
using Kujikastu034.Questions;

namespace Kujikastu034.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc025/tasks/agc025_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();

            var min = int.MaxValue;

            for (int a = 1; a < n; a++)
            {
                var b = n - a;
                min = Math.Min(min, DigitSum(a) + DigitSum(b));
            }

            yield return min;
        }

        int DigitSum(int n)
        {
            var result = 0;
            while (n > 0)
            {
                result += n % 10;
                n /= 10;
            }

            return result;
        }
    }
}
