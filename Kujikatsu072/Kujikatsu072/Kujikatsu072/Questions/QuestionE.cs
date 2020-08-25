using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu072.Algorithms;
using Kujikatsu072.Collections;
using Kujikatsu072.Extensions;
using Kujikatsu072.Numerics;
using Kujikatsu072.Questions;

namespace Kujikatsu072.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc113/tasks/abc113_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, k) = inputStream.ReadValue<int, int, int>();
            k--;

            var count = Count(height, width, k);

            yield return count;
        }

        private static int Count(int height, int width, int k)
        {
            var counts = new Modular[height + 1, width];
            counts[0, 0] = 1;

            for (int row = 0; row < height; row++)
            {
                for (var flag = BitSet.Zero; flag < 1 << (width - 1); flag++)
                {
                    var ok = true;
                    for (int column = 0; column + 1 < width; column++)
                    {
                        if (flag[column] && flag[column + 1])
                        {
                            ok = false;
                            break;
                        }
                    }

                    if (ok)
                    {
                        var localCounts = new Modular[width];
                        for (int column = 0; column < localCounts.Length; column++)
                        {
                            localCounts[column] = counts[row, column];
                        }

                        for (int column = 0; column + 1 < width; column++)
                        {
                            if (flag[column])
                            {
                                (localCounts[column], localCounts[column + 1]) = (localCounts[column + 1], localCounts[column]);
                            }
                        }

                        for (int column = 0; column < localCounts.Length; column++)
                        {
                            counts[row + 1, column] += localCounts[column];
                        }
                    }
                }
            }

            return counts[height, k].Value;
        }
    }
}
