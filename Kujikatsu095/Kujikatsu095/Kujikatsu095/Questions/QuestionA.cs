using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu095.Algorithms;
using Kujikatsu095.Collections;
using Kujikatsu095.Extensions;
using Kujikatsu095.Numerics;
using Kujikatsu095.Questions;

namespace Kujikatsu095.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/nikkei2019-qual/tasks/nikkei2019_qual_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, a, b) = inputStream.ReadValue<int, int, int>();
            var max = Math.Min(a, b);
            var min = Math.Max(0, a + b - n);

            yield return $"{max} {min}";
        }
    }
}
