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
    /// https://atcoder.jp/contests/abc165/tasks/abc165_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, n) = inputStream.ReadValue<long, long, long>();
            var x = Math.Min(b - 1, n);
            yield return (a * (x % b) - (a * x) % b) / b;
        }
    }
}
