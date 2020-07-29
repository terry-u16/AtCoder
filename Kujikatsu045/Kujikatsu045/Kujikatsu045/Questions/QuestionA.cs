using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu045.Algorithms;
using Kujikatsu045.Collections;
using Kujikatsu045.Extensions;
using Kujikatsu045.Numerics;
using Kujikatsu045.Questions;

namespace Kujikatsu045.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc050/tasks/abc050_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, op, b) = inputStream.ReadValue<int, char, int>();
            if (op == '+')
            {
                yield return a + b;
            }
            else
            {
                yield return a - b; ;
            }
        }
    }
}
