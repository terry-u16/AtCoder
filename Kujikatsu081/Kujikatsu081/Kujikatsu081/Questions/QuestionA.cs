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
    /// https://atcoder.jp/contests/diverta2019/tasks/diverta2019_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            yield return n - k + 1;
        }
    }
}
