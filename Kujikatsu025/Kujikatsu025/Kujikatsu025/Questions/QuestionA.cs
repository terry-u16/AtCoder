using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu025.Algorithms;
using Kujikatsu025.Collections;
using Kujikatsu025.Extensions;
using Kujikatsu025.Numerics;
using Kujikatsu025.Questions;

namespace Kujikatsu025.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc084/tasks/abc084_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var m = inputStream.ReadInt();
            yield return 48 - m;
        }
    }
}
