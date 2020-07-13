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
    /// https://atcoder.jp/contests/abc171/tasks/abc171_f
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            var lastLength = s.Length + k;

            Modular.InitializeCombinationTable(2500000);

            var count = Modular.Zero;

            for (int lastS = s.Length; lastS <= lastLength; lastS++)
            {
                count += Modular.Combination(lastS - 1, s.Length - 1) * Modular.Pow(25, lastS - s.Length) * Modular.Pow(26, lastLength - lastS);
            }

            yield return count.Value;
        }
    }
}
