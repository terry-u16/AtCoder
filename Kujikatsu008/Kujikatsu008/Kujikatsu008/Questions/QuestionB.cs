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
    /// https://atcoder.jp/contests/abc140/tasks/abc140_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var _ = inputStream.ReadInt();
            var b = inputStream.ReadIntArray();
            var a = new int[b.Length + 1];
            a[0] = b[0];
            a[^1] = b[^1];
            for (int i = 1; i + 1 < a.Length; i++)
            {
                a[i] = Math.Min(b[i - 1], b[i]);
            }

            yield return a.Sum();
        }
    }
}
