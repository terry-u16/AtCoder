using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu029.Algorithms;
using Kujikatsu029.Collections;
using Kujikatsu029.Extensions;
using Kujikatsu029.Numerics;
using Kujikatsu029.Questions;

namespace Kujikatsu029.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc159/tasks/abc159_e
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, k) = inputStream.ReadValue<int, int, int>();
            var chocolate = new char[height, width];

            for (int row = 0; row < height; row++)
            {
                var s = inputStream.ReadLine();
                for (int column = 0; column < width; column++)
                {
                    chocolate[row, column] = s[column];
                }
            }

            var min = int.MaxValue;

            for (var flags = BitSet.Zero; flags < (1 << (height - 1)); flags++)
            {
                var count = flags.Count();
                var whiteChocolates = new int[flags.Count() + 1];
                var ok = true;

                var columnStreak = 0;
                for (int column = 0; column < width; column++)
                {
                    var section = 0;
                    for (int row = 0; row < height; row++)
                    {
                        if (chocolate[row, column] == '1')
                        {
                            whiteChocolates[section]++;
                        }
                        if (flags[row])
                        {
                            section++;
                        }
                    }

                    if (whiteChocolates.Any(c => c > k))
                    {
                        if (columnStreak == 0)
                        {
                            ok = false;
                            break;
                        }
                        else
                        {
                            count++;
                            whiteChocolates.AsSpan().Clear();
                            column -= 1;
                            columnStreak = 0;
                        }
                    }
                    else
                    {
                        columnStreak++;
                    }
                }

                if (ok)
                {
                    min = Math.Min(min, count);
                }
            }

            yield return min;
        }
    }
}
