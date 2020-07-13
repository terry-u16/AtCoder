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
    /// https://atcoder.jp/contests/abc118/tasks/abc118_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            long gcd = 0;

            foreach (var ai in a)
            {
                gcd = NumericalAlgorithms.Gcd(gcd, ai);
            }

            yield return gcd;
        }
    }
}
