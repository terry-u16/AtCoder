using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu046.Algorithms;
using Kujikatsu046.Collections;
using Kujikatsu046.Extensions;
using Kujikatsu046.Numerics;
using Kujikatsu046.Questions;

namespace Kujikatsu046.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc057/tasks/abc057_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();
            var min = int.MaxValue;
            for (long i = 1; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    var other = n / i;
                    min = Math.Min(min, Math.Max(GetDigit(i), GetDigit(other)));
                }
            }
            yield return min;
        }

        int GetDigit(long n)
        {
            var digit = 0;
            while (n > 0)
            {
                n /= 10;
                digit++;
            }
            return digit;
        }
    }
}
