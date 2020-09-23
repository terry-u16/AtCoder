using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu101.Algorithms;
using Kujikatsu101.Collections;
using Kujikatsu101.Numerics;
using Kujikatsu101.Questions;

namespace Kujikatsu101.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc070/tasks/abc070_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var result = 1L;

            for (int i = 0; i < n; i++)
            {
                var l = io.ReadLong();
                result = NumericalAlgorithms.Lcm(result, l);
            }

            io.WriteLine(result);
        }
    }
}
