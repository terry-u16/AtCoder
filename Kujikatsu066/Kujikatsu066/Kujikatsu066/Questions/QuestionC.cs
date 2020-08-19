using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu066.Algorithms;
using Kujikatsu066.Collections;
using Kujikatsu066.Extensions;
using Kujikatsu066.Numerics;
using Kujikatsu066.Questions;

namespace Kujikatsu066.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc129/tasks/abc129_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (top, brokenCount) = inputStream.ReadValue<int, int>();
            var brokens = new int[brokenCount];
            for (int i = 0; i < brokens.Length; i++)
            {
                brokens[i] = inputStream.ReadInt();
            }

            yield return Count(top, brokens);
        }

        int Count(int top, ReadOnlySpan<int> brokens)
        {
            var counts = new Modular[top + 1];
            counts[0] = 1;

            for (int step = 0; step < top; step++)
            {
                if (brokens.BinarySearch(step + 1) < 0)
                {
                    counts[step + 1] += counts[step];
                }
                if (step + 2 <= top && brokens.BinarySearch(step + 2) < 0)
                {
                    counts[step + 2] += counts[step];
                }
            }

            return counts[top].Value;
        }
    }
}
