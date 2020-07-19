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
    /// https://atcoder.jp/contests/agc008/tasks/agc008_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (aI, aO, aT, aJ, aL, aS, aZ) = inputStream.ReadValue<int, int, int, int, int, int, int>();
            long tetrominos = Compose(aO, aI, aJ, aL);

            if (aI > 0 && aJ > 0 && aL > 0)
            {
                tetrominos = Math.Max(tetrominos, Compose(aO, aI - 1, aJ - 1, aL - 1) + 3);
            }

            yield return tetrominos;
        }

        long Compose(int ao, int ai, int aj, int al)
        {
            long tetrominos = 0;
            tetrominos += ao;
            tetrominos += (ai / 2) * 2;
            tetrominos += (aj / 2) * 2;
            tetrominos += (al / 2) * 2;
            return tetrominos;
        }
    }
}
