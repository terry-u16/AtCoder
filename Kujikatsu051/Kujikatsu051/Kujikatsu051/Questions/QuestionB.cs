using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu051.Algorithms;
using Kujikatsu051.Collections;
using Kujikatsu051.Extensions;
using Kujikatsu051.Numerics;
using Kujikatsu051.Questions;

namespace Kujikatsu051.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc155/tasks/abc155_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var counts = new Counter<string>();
            var n = inputStream.ReadInt();
            for (int i = 0; i < n; i++)
            {
                counts[inputStream.ReadLine()]++;
            }

            var max = counts.Max(p => p.count);
            foreach (var s in counts.Where(p => p.count == max).Select(p => p.key).OrderBy(s => s, StringComparer.Ordinal))
            {
                yield return s;
            }
        }
    }
}
