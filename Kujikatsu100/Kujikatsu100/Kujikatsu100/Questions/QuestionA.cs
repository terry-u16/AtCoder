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
    /// https://atcoder.jp/contests/abc178/tasks/abc178_b
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var a = io.ReadLong();
            var b = io.ReadLong();
            var c = io.ReadLong();
            var d = io.ReadLong();

            io.WriteLine(Math.Max(Math.Max(Math.Max(a * c, a * d), b * c), b * d));
        }
    }
}
