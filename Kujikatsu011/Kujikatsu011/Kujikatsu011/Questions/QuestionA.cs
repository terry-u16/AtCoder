using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu011.Algorithms;
using Kujikatsu011.Collections;
using Kujikatsu011.Extensions;
using Kujikatsu011.Numerics;
using Kujikatsu011.Questions;

namespace Kujikatsu011.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc071/tasks/abc071_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (x, a, b) = inputStream.ReadValue<int, int, int>();
            var diffA = Math.Abs(x - a);
            var diffB = Math.Abs(x - b);
            if (diffA < diffB)
            {
                yield return "A";
            }
            else
            {
                yield return "B";
            }
        }
    }
}
