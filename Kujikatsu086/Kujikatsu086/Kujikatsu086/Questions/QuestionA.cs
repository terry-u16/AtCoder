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
    /// https://atcoder.jp/contests/nomura2020/tasks/nomura2020_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (h1, m1, h2, m2, k) = inputStream.ReadValue<int, int, int, int, int>();
            var awake = h2 * 60 + m2 - h1 * 60 - m1;
            yield return awake - k;
        }
    }
}
