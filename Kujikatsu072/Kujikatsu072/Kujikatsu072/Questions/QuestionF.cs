using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu072.Algorithms;
using Kujikatsu072.Collections;
using Kujikatsu072.Extensions;
using Kujikatsu072.Numerics;
using Kujikatsu072.Questions;

namespace Kujikatsu072.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc094/tasks/arc094_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = new long[n];
            var b = new long[n];

            var min = long.MaxValue;

            for (int i = 0; i < a.Length; i++)
            {
                var (ai, bi) = inputStream.ReadValue<int, int>();
                a[i] = ai;
                b[i] = bi;

                if (a[i] > b[i])
                {
                    min = Math.Min(min, b[i]);
                }
            }

            if (a.SequenceEqual(b))
            {
                yield return 0;
            }
            else
            {
                yield return b.Sum() - min;
            }
        }
    }
}
