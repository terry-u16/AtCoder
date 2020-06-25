using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu011.Algorithms;
using Kujikatsu011.Collections;
using Kujikatsu011.Extensions;
using Kujikatsu011.Numerics;
using Kujikatsu011.Questions;

namespace Kujikatsu011.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc146/tasks/abc146_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, x) = inputStream.ReadValue<long, long, long>();
            yield return SearchExtensions.BoundaryBinarySearch(n => a * n + b * GetMaxDigit(n) <= x, 0, 1_000_000_001);
        }

        long GetMaxDigit(long n)
        {
            var digit = 0;
            while (n > 0)
            {
                digit++;
                n /= 10;
            }
            return digit;
        }
    }
}
