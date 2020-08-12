using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu059.Algorithms;
using Kujikatsu059.Collections;
using Kujikatsu059.Extensions;
using Kujikatsu059.Numerics;
using Kujikatsu059.Questions;

namespace Kujikatsu059.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2016-qualb/tasks/codefestival_2016_qualB_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = inputStream.ReadInt();
            }

            long result = a[0] - 1; // 0番目の客には1円になるまで買わせておく
            var minPrice = 2;

            for (int i = 1; i < a.Length; i++)
            {
                var wallet = a[i];
                var count = (wallet - 1) / minPrice;
                result += count;

                if (count == 0)
                {
                    minPrice = Math.Max(minPrice, wallet + 1);
                }
            }

            yield return result;
        }
    }
}
