using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200909.Algorithms;
using Training20200909.Collections;
using Training20200909.Extensions;
using Training20200909.Numerics;
using Training20200909.Questions;

namespace Training20200909.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc091/tasks/abc091_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b, c) = inputStream.ReadValue<int, int, int>();

            if (a + b >= c)
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
