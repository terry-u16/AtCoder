using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu044.Algorithms;
using Kujikatsu044.Collections;
using Kujikatsu044.Extensions;
using Kujikatsu044.Numerics;
using Kujikatsu044.Questions;

namespace Kujikatsu044.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc100/tasks/abc100_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();
            yield return ab.All(i => i <= 8) ? "Yay!" : ":(";
        }
    }
}
