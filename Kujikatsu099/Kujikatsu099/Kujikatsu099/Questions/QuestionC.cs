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
    /// https://atcoder.jp/contests/arc099/tasks/arc099_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var width = io.ReadInt();
            n -= width;
            width--;
            io.WriteLine((n + width - 1) / width + 1);
        }
    }
}
