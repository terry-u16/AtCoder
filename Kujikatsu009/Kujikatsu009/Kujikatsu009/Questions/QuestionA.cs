using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu009.Algorithms;
using Kujikatsu009.Collections;
using Kujikatsu009.Extensions;
using Kujikatsu009.Numerics;
using Kujikatsu009.Questions;

namespace Kujikatsu009.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc054/tasks/abc054_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b) = inputStream.ReadValue<int, int>();
            if (a == 1)
            {
                a = 14;
            }
            if (b == 1)
            {
                b = 14;
            }

            if (a > b)
            {
                yield return "Alice";
            }
            else if (a < b)
            {
                yield return "Bob";
            }
            else
            {
                yield return "Draw";
            }
        }
    }
}
