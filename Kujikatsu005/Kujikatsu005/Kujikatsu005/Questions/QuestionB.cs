using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Kujikatsu005.Algorithms;
using Kujikatsu005.Collections;
using Kujikatsu005.Extensions;
using Kujikatsu005.Numerics;
using Kujikatsu005.Questions;

namespace Kujikatsu005.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc056/tasks/abc056_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (w, a, b) = inputStream.ReadValue<int, int, int>();
            var toLeft = b - (a + w);
            var toRight = a - (b + w);
            yield return Math.Max(Math.Max(toLeft, toRight), 0);
        }
    }
}
