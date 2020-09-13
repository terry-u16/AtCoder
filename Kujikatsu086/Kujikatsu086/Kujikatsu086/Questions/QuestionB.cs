using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu086.Algorithms;
using Kujikatsu086.Collections;
using Kujikatsu086.Extensions;
using Kujikatsu086.Numerics;
using Kujikatsu086.Questions;

namespace Kujikatsu086.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc094/tasks/abc094_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, _, start) = inputStream.ReadValue<int, int, int>();
            start--;
            var a = inputStream.ReadIntArray().Select(i => i - 1).ToArray();

            yield return Math.Min(a.Count(ai => ai < start), a.Count(ai => ai > start));
        }
    }
}
