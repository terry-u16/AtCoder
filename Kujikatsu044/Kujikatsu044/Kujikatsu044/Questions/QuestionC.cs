using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu044.Algorithms;
using Kujikatsu044.Collections;
using Kujikatsu044.Extensions;
using Kujikatsu044.Numerics;
using Kujikatsu044.Questions;

namespace Kujikatsu044.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/panasonic2020/tasks/panasonic2020_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, c) = inputStream.ReadValue<long, long, long>();
            var cab = c - (a + b);

            if (cab > 0 && 4 * a * b < cab * cab)
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }
    }
}
