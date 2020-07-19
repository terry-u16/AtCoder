using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu035.Algorithms;
using Kujikatsu035.Collections;
using Kujikatsu035.Extensions;
using Kujikatsu035.Numerics;
using Kujikatsu035.Questions;

namespace Kujikatsu035.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc135/tasks/abc135_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var monsters = inputStream.ReadIntArray();
            var braves = inputStream.ReadIntArray();

            long total = 0;
            for (int i = 0; i < braves.Length; i++)
            {
                var left = Math.Min(monsters[i], braves[i]);
                braves[i] -= left;
                var right = Math.Min(monsters[i + 1], braves[i]);
                monsters[i + 1] -= right;
                total += left + right;
            }

            yield return total;
        }
    }
}
