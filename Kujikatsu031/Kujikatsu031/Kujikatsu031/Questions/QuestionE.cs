using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu031.Algorithms;
using Kujikatsu031.Collections;
using Kujikatsu031.Extensions;
using Kujikatsu031.Numerics;
using Kujikatsu031.Questions;

namespace Kujikatsu031.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc046/tasks/agc046_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = 998244353;
            var (a, b, c, d) = inputStream.ReadValue<int, int, int, int>();
            var counts = new Modular[3001, 3001];
            counts[a, b] = 1;

            for (int row = a; row <= c; row++)
            {
                for (int column = b; column <= d; column++)
                {
                    if (row == a && column == b)
                    {
                        continue;
                    }

                    counts[row, column] = counts[row - 1, column] * column + counts[row, column - 1] * row - counts[row - 1, column - 1] * (row - 1) * (column - 1);
                }
            }

            yield return counts[c, d];
        }
    }
}
