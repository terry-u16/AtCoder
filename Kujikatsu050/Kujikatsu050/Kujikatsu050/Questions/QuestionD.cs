using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu050.Algorithms;
using Kujikatsu050.Collections;
using Kujikatsu050.Extensions;
using Kujikatsu050.Numerics;
using Kujikatsu050.Questions;

namespace Kujikatsu050.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/caddi2018/tasks/caddi2018_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var apples = new int[n];
            for (int i = 0; i < apples.Length; i++)
            {
                apples[i] = inputStream.ReadInt();
            }

            Array.Sort(apples);
            Array.Reverse(apples);

            if (n == 1)
            {
                yield return apples[0] % 2 == 1 ? "first" : "second";
            }
            else if (true)
            {

            }
        }
    }
}
