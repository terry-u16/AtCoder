using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu029.Algorithms;
using Kujikatsu029.Collections;
using Kujikatsu029.Extensions;
using Kujikatsu029.Numerics;
using Kujikatsu029.Questions;

namespace Kujikatsu029.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc104/tasks/abc104_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var r = inputStream.ReadInt();

            if (r < 1200)
            {
                yield return "ABC";
            }
            else if (r < 2800)
            {
                yield return "ARC";
            }
            else
            {
                yield return "AGC";
            }
        }
    }
}
