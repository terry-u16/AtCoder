using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu066.Algorithms;
using Kujikatsu066.Collections;
using Kujikatsu066.Extensions;
using Kujikatsu066.Numerics;
using Kujikatsu066.Questions;

namespace Kujikatsu066.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc121/tasks/abc121_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (sourceCount, featureCount, geta) = inputStream.ReadValue<int, int, int>();
            var b = inputStream.ReadIntArray();
            var count = 0;

            for (int i = 0; i < sourceCount; i++)
            {
                var a = inputStream.ReadIntArray();
                var total = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    total += a[j] * b[j];
                }
                total += geta;
                if (total > 0)
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
