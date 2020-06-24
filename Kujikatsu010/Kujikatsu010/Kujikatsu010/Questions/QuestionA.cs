using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu010.Algorithms;
using Kujikatsu010.Collections;
using Kujikatsu010.Extensions;
using Kujikatsu010.Numerics;
using Kujikatsu010.Questions;

namespace Kujikatsu010.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc137/tasks/abc137_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b) = inputStream.ReadValue<int, int>();
            var plus = a + b;
            var minus = a - b;
            var times = a * b;

            yield return Math.Max(Math.Max(plus, minus), times);
        }
    }
}
