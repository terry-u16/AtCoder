using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu081.Algorithms;
using Kujikatsu081.Collections;
using Kujikatsu081.Extensions;
using Kujikatsu081.Numerics;
using Kujikatsu081.Questions;

namespace Kujikatsu081.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc041/tasks/agc041_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, a, b) = inputStream.ReadValue<long, long, long>();
            var diff = b - a;
            if (diff % 2 == 0)
            {
                yield return diff / 2;
            }
            else
            {
                yield return Math.Min(diff / 2 + a, diff / 2 + n - b + 1);
            }
        }
    }
}
