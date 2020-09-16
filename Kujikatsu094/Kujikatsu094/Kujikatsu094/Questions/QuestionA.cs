using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu094.Algorithms;
using Kujikatsu094.Collections;
using Kujikatsu094.Extensions;
using Kujikatsu094.Numerics;
using Kujikatsu094.Questions;

namespace Kujikatsu094.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc064/tasks/abc064_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            Array.Sort(a);

            yield return a[^1] - a[0];
        }
    }
}
