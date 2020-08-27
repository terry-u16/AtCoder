using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu074.Algorithms;
using Kujikatsu074.Collections;
using Kujikatsu074.Extensions;
using Kujikatsu074.Numerics;
using Kujikatsu074.Questions;

namespace Kujikatsu074.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc072/tasks/abc072_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (x, t) = inputStream.ReadValue<int, int> ();
            yield return Math.Max(x - t, 0);
        }
    }
}
