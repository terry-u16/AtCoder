using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu008.Algorithms;
using Kujikatsu008.Collections;
using Kujikatsu008.Extensions;
using Kujikatsu008.Numerics;
using Kujikatsu008.Questions;

namespace Kujikatsu008.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc166/tasks/abc166_e
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var plus = new int[a.Length];
            var minus = new Counter<int>();

            for (int i = 0; i < a.Length; i++)
            {
                var no = i + 1;
                plus[i] = no + a[i];
                minus[no - a[i]]++;
            }

            long overall = 0;
            for (int i = 0; i < plus.Length; i++)
            {
                var no = i + 1;
                var other = no - a[i];
                minus[other]--;
                overall += minus[no + a[i]];
            }

            yield return overall;
        }
    }
}
