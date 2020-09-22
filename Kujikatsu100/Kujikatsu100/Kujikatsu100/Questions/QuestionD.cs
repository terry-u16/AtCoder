using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu100.Algorithms;
using Kujikatsu100.Collections;
using Kujikatsu100.Numerics;
using Kujikatsu100.Questions;

namespace Kujikatsu100.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2016-qualc/tasks/codefestival_2016_qualC_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var total = io.ReadInt();
            var type = io.ReadInt();
            var cakes = io.ReadIntArray(type);

            var max = cakes.Max();
            var remain = total - max;

            io.WriteLine(Math.Max(max - (remain + 1), 0));
        }
    }
}
