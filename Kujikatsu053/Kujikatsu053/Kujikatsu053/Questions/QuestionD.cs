using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu053.Algorithms;
using Kujikatsu053.Collections;
using Kujikatsu053.Extensions;
using Kujikatsu053.Numerics;
using Kujikatsu053.Questions;

namespace Kujikatsu053.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc094/tasks/arc095_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            Array.Sort(a);

            var n = a[^1];
            var r = 0;

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (Abs(n, r) < Abs(n, a[i]))
                {
                    r = a[i];
                }
            }
            yield return $"{n} {r}";
        }

        int Abs(int n, int r) => Math.Min(r, n - r);
    }
}
