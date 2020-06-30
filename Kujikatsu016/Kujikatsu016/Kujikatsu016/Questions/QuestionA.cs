using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu016.Algorithms;
using Kujikatsu016.Collections;
using Kujikatsu016.Extensions;
using Kujikatsu016.Numerics;
using Kujikatsu016.Questions;

namespace Kujikatsu016.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/panasonic2020/tasks/panasonic2020_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var a = new[] { 1, 1, 1, 2, 1, 2, 1, 5, 2, 2, 1, 5, 1, 2, 1, 14, 1, 5, 1, 5, 2, 2, 1, 15, 2, 2, 5, 4, 1, 4, 1, 51 };
            var k = inputStream.ReadInt();
            yield return a[k - 1];
        }
    }
}
