using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu020.Algorithms;
using Kujikatsu020.Collections;
using Kujikatsu020.Extensions;
using Kujikatsu020.Numerics;
using Kujikatsu020.Questions;

namespace Kujikatsu020.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc086/tasks/abc086_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b) = inputStream.ReadValue<int, int>();
            if (a * b % 2 == 0)
            {
                yield return "Even";
            }
            else
            {
                yield return "Odd";
            }
        }
    }
}
