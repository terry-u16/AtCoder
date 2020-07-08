using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu023.Algorithms;
using Kujikatsu023.Collections;
using Kujikatsu023.Extensions;
using Kujikatsu023.Numerics;
using Kujikatsu023.Questions;

namespace Kujikatsu023.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc160/tasks/abc160_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            yield return s[2] == s[3] && s[4] == s[5] ? "Yes" : "No";
        }
    }
}
