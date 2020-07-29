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
    /// https://atcoder.jp/contests/abc132/tasks/abc132_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var d = inputStream.ReadIntArray();
            Array.Sort(d);

            var a = d[d.Length / 2 - 1];
            var b = d[d.Length / 2];

            yield return b - a;
        }
    }
}
