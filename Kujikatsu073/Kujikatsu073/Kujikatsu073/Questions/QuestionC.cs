using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu073.Algorithms;
using Kujikatsu073.Collections;
using Kujikatsu073.Extensions;
using Kujikatsu073.Numerics;
using Kujikatsu073.Questions;

namespace Kujikatsu073.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/yahoo-procon2019-qual/tasks/yahoo_procon2019_qual_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (k, a, b) = inputStream.ReadValue<long, long, long>();
            var diff = b - a;

            if (k <= a || diff <= 2)
            {
                yield return k + 1;
            }
            else
            {
                var biscuits = a;
                k -= a - 1;
                var count = k / 2;
                biscuits += diff * count;
                if (k % 2 == 1)
                {
                    biscuits++;
                }
                yield return biscuits;
            }
        }
    }
}
