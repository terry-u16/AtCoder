using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu073.Algorithms;
using Kujikatsu073.Collections;
using Kujikatsu073.Extensions;
using Kujikatsu073.Numerics;
using Kujikatsu073.Questions;

namespace Kujikatsu073.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc160/tasks/abc160_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadInt();
            var fiveHandreds = x / 500;
            x -= 500 * fiveHandreds;
            var fives = x / 5;
            yield return 1000 * fiveHandreds + 5 * fives;
        }
    }
}
