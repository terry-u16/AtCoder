using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu115.Algorithms;
using Kujikatsu115.Collections;
using Kujikatsu115.Numerics;
using Kujikatsu115.Questions;

namespace Kujikatsu115.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc142/tasks/abc142_a
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var odds = 0;

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 1)
                {
                    odds++;
                }
            }

            io.WriteLine((double)odds / n);
        }
    }
}
