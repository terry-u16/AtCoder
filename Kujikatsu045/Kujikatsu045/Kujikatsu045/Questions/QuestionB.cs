using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu045.Algorithms;
using Kujikatsu045.Collections;
using Kujikatsu045.Extensions;
using Kujikatsu045.Numerics;
using Kujikatsu045.Questions;

namespace Kujikatsu045.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc160/tasks/abc160_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (k, _) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            var diffs = new int[a.Length];
            for (int i = 0; i < diffs.Length; i++)
            {
                diffs[i] = (k + a[(i + 1) % a.Length] - a[i]) % k;
            }
            yield return k - diffs.Max();
        }
    }
}
