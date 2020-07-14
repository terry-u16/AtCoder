using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu030.Algorithms;
using Kujikatsu030.Collections;
using Kujikatsu030.Extensions;
using Kujikatsu030.Numerics;
using Kujikatsu030.Questions;

namespace Kujikatsu030.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc055/tasks/abc055_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            yield return 800 * n - 200 * (n / 15);
        }
    }
}
