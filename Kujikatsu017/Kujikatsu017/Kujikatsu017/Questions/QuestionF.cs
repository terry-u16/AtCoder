using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu017.Algorithms;
using Kujikatsu017.Collections;
using Kujikatsu017.Extensions;
using Kujikatsu017.Numerics;
using Kujikatsu017.Questions;

namespace Kujikatsu017.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc007/tasks/agc007_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var p = inputStream.ReadIntArray();
            var a = new int[p.Length];
            var b = new int[p.Length];

            const int maxLength = 20000;
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = maxLength * i + 1;
                b[^(i + 1)] = maxLength * i + 1;
            }

            for (int i = 0; i < p.Length; i++)
            {
                a[p[i] - 1] += i;
            }

            yield return string.Join(" ", a);
            yield return string.Join(" ", b);
        }
    }
}
