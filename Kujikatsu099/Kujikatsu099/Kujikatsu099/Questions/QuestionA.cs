using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu099.Algorithms;
using Kujikatsu099.Collections;
using Kujikatsu099.Numerics;
using Kujikatsu099.Questions;

namespace Kujikatsu099.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc125/tasks/abc125_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var a = io.ReadInt();
            var b = io.ReadInt();
            var t = io.ReadInt();
            io.WriteLine(b * (t / a));
        }
    }
}
