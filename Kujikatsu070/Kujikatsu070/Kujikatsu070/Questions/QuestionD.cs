using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu070.Algorithms;
using Kujikatsu070.Collections;
using Kujikatsu070.Extensions;
using Kujikatsu070.Numerics;
using Kujikatsu070.Questions;

namespace Kujikatsu070.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/tenka1-2017/tasks/tenka1_2017_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var N = inputStream.ReadLong();

            for (int h = 1; h <= 3500; h++)
            {
                for (int n = 1; n <= 3500; n++)
                {
                    var numerator = N * h * n;
                    var denominator = 4 * h * n - N * n - N * h;

                    if (denominator > 0 && numerator % denominator == 0)
                    {
                        var w = numerator / denominator;
                        yield return $"{h} {n} {w}";
                        yield break;
                    }
                }
            }
        }
    }
}
