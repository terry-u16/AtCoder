using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu030.Algorithms;
using Kujikatsu030.Collections;
using Kujikatsu030.Extensions;
using Kujikatsu030.Numerics;
using Kujikatsu030.Questions;

namespace Kujikatsu030.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc147/tasks/abc147_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int MaxDigit = 60;
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();
            var bits = new int[MaxDigit];

            foreach (var ai in a)
            {
                for (int digit = 0; digit < MaxDigit; digit++)
                {
                    if ((ai & (1L << digit)) > 0)
                    {
                        bits[digit]++;
                    }
                }
            }

            var sum = Modular.Zero;
            for (int digit = 0; digit < MaxDigit; digit++)
            {
                sum += new Modular(bits[digit]) * new Modular(n - bits[digit]) * new Modular(1L << digit);
            }

            yield return sum;
        }
    }
}
