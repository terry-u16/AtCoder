using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu094.Algorithms;
using Kujikatsu094.Collections;
using Kujikatsu094.Extensions;
using Kujikatsu094.Numerics;
using Kujikatsu094.Questions;

namespace Kujikatsu094.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc121/tasks/abc121_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (a, b) = inputStream.ReadValue<long, long>();
            a--;

            if (a < 0)
            {
                a = 0;
            }
            yield return Xor(b) ^ Xor(a);
        }

        long Xor(long n)
        {
            long sum = 0;

            for (int shift = 1; shift < 60; shift++)
            {
                var current = 1L << shift;
                var mask = current - 1;

                if ((n & current) > 0 && (n & mask) % 2 == 0)
                {
                    sum |= current;
                }
            }

            if (n % 4 == 1 || n % 4 == 2)
            {
                sum += 1;
            }

            return sum;
        }
    }
}
