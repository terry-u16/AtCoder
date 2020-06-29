using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu015.Algorithms;
using Kujikatsu015.Collections;
using Kujikatsu015.Extensions;
using Kujikatsu015.Numerics;
using Kujikatsu015.Questions;

namespace Kujikatsu015.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/apc001/tasks/apc001_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();
            var b = inputStream.ReadLongArray();

            var diffs = a.Zip(b).Select(p => p.First - p.Second);

            long aCount = 0;
            long bCount = 0;

            foreach (var diff in diffs)
            {
                if (diff < 0)
                {
                    aCount -= diff / 2;
                }
                else
                {
                    bCount += diff;
                }
            }

            yield return aCount >= bCount ? "Yes" : "No";
        }
    }
}
