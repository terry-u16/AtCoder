using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu072.Algorithms;
using Kujikatsu072.Collections;
using Kujikatsu072.Extensions;
using Kujikatsu072.Numerics;
using Kujikatsu072.Questions;

namespace Kujikatsu072.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/diverta2019/tasks/diverta2019_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLong();
            var sum = 0L;

            for (long quotient = 1L; quotient * quotient <= n; quotient++)
            {
                var mod = quotient;
                var div = n - mod;
                div /= quotient;

                if (div != 0 && n / div == n % div)
                {
                    sum += div;
                }
            }

            yield return sum;
        }
    }
}
