using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu053.Algorithms;
using Kujikatsu053.Collections;
using Kujikatsu053.Extensions;
using Kujikatsu053.Numerics;
using Kujikatsu053.Questions;

namespace Kujikatsu053.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc059/tasks/arc072_a
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            yield return Math.Min(Operate(a, 0), Operate(a, 1));
        }

        long Operate(int[] a, int parity)
        {
            int current = 0;
            long operations = 0;

            for (int i = 0; i < a.Length; i++)
            {
                var toPlus = (i + parity) % 2 == 0;
                current += a[i];

                if (toPlus && current <= 0)
                {
                    operations += 1 - current;
                    current = 1;
                }
                else if (!toPlus && current >= 0)
                {
                    operations += current + 1;
                    current = -1;
                }
            }

            return operations;
        }
    }
}
