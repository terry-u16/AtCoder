using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200904.Algorithms;
using Training20200904.Collections;
using Training20200904.Extensions;
using Training20200904.Numerics;
using Training20200904.Questions;

namespace Training20200904.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc097/tasks/abc097_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, c, d) = inputStream.ReadValue<int, int, int, int>();

            if (Math.Abs(a - c) <= d || (Math.Abs(a - b) <= d && Math.Abs(b - c) <= d))
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }
    }
}
