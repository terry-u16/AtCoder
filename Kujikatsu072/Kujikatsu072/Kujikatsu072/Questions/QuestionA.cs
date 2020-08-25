using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu072.Algorithms;
using Kujikatsu072.Collections;
using Kujikatsu072.Extensions;
using Kujikatsu072.Numerics;
using Kujikatsu072.Questions;

namespace Kujikatsu072.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc068/tasks/abc068_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            yield return "ABC" + inputStream.ReadInt().ToString("000");
        }
    }
}
