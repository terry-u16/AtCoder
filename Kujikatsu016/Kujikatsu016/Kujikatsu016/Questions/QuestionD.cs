using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu016.Algorithms;
using Kujikatsu016.Collections;
using Kujikatsu016.Extensions;
using Kujikatsu016.Numerics;
using Kujikatsu016.Questions;

namespace Kujikatsu016.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc163/tasks/abc163_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();

            var count = Modular.Zero;
            for (int selected = k; selected <= n + 1; selected++)
            {
                var min = (long)selected * (selected - 1) / 2;
                var max = min + (long)selected * (n + 1 - selected);
                count += max - min + 1;
            }
            yield return count.Value;
        }
    }
}
