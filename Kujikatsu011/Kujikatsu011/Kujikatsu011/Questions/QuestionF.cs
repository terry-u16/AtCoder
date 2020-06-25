using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu011.Algorithms;
using Kujikatsu011.Collections;
using Kujikatsu011.Extensions;
using Kujikatsu011.Numerics;
using Kujikatsu011.Questions;

namespace Kujikatsu011.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc008/tasks/agc008_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadLongArray();
            var plusOnly = a.Where(ai => ai > 0).Sum();

            var minus = a.Take(k).Where(ai => ai < 0).Sum();
            var plus = a.Take(k).Where(ai => ai > 0).Sum();
            var best = Math.Max(plusOnly + minus, plusOnly - plus);

            for (int shift = 0; shift + k < a.Length; shift++)
            {
                minus += Math.Min(0, a[shift + k]);
                minus -= Math.Min(0, a[shift]);
                plus += Math.Max(0, a[shift + k]);
                plus -= Math.Max(0, a[shift]);
                best = Math.Max(best, plusOnly + minus);
                best = Math.Max(best, plusOnly - plus);
            }

            yield return best;
        }
    }
}
