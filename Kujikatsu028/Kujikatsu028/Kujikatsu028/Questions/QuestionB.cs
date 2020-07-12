using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu028.Algorithms;
using Kujikatsu028.Collections;
using Kujikatsu028.Extensions;
using Kujikatsu028.Numerics;
using Kujikatsu028.Questions;

namespace Kujikatsu028.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc021/tasks/agc021_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();
            var max = SumOfDigit(n);

            for (long div = 10; div < n * 10; div *= 10)
            {
                max = Math.Max(max, SumOfDigit(n - (n % div) - 1));
            }

            yield return max;
        }

        int SumOfDigit(long n)
        {
            var result = 0;
            while (n > 0)
            {
                result += (int)(n % 10);
                n /= 10;
            }
            return result;
        }
    }
}
