using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu102.Algorithms;
using Kujikatsu102.Collections;
using Kujikatsu102.Numerics;
using Kujikatsu102.Questions;

namespace Kujikatsu102.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc020/tasks/agc020_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadInt();
            var b = io.ReadInt();
            var diff = b - a - 1;

            if (diff % 2 == 1)
            {
                io.WriteLine("Alice");
            }
            else
            {
                io.WriteLine("Borys");
            }
        }
    }
}
