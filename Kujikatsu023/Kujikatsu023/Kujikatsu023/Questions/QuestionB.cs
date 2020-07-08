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
    /// https://atcoder.jp/contests/agc024/tasks/agc024_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, c, k) = inputStream.ReadValue<long, long, long, long>();
            if (k % 2 == 0)
            {
                yield return a - b;
            }
            else
            {
                yield return b - a;
            }
        }
    }
}
