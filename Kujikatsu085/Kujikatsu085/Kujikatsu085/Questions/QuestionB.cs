using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu085.Algorithms;
using Kujikatsu085.Collections;
using Kujikatsu085.Extensions;
using Kujikatsu085.Numerics;
using Kujikatsu085.Questions;

namespace Kujikatsu085.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc177/tasks/abc177_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var sum = Modular.Zero;
            var other = Modular.Zero;
            foreach (var ai in a)
            {
                other += ai;
            }

            foreach (var ai in a)
            {
                other -= ai;
                sum += ai * other;
            }

            yield return sum;
        }
    }
}
