using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu022.Algorithms;
using Kujikatsu022.Collections;
using Kujikatsu022.Extensions;
using Kujikatsu022.Numerics;
using Kujikatsu022.Questions;

namespace Kujikatsu022.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc055/tasks/abc055_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var power = Modular.One;
            for (int i = 1; i <= n; i++)
            {
                power *= i;
            }

            yield return power.Value;
        }
    }
}
