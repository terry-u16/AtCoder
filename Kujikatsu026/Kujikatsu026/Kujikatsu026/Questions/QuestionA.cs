using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu026.Algorithms;
using Kujikatsu026.Collections;
using Kujikatsu026.Extensions;
using Kujikatsu026.Numerics;
using Kujikatsu026.Questions;

namespace Kujikatsu026.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc070/tasks/abc070_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadLine();
            yield return n[0] == n[2] ? "Yes" : "No";
        }
    }
}
