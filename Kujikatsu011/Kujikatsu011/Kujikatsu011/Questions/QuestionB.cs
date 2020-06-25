using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu011.Algorithms;
using Kujikatsu011.Collections;
using Kujikatsu011.Extensions;
using Kujikatsu011.Numerics;
using Kujikatsu011.Questions;

namespace Kujikatsu011.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc090/tasks/abc090_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b) = inputStream.ReadValue<int, int>();
            yield return Enumerable.Range(a, b - a + 1).Select(i => i.ToString()).Count(s => s == string.Concat(s.Reverse()));
        }
    }
}
