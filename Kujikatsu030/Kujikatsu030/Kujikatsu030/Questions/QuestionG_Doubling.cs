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
    /// https://atcoder.jp/contests/arc060/tasks/arc060_c
    /// </summary>
    public class QuestionG_Doubling : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var x = inputStream.ReadIntArray();
            var l = inputStream.ReadInt();
            const int MaxDigit = 20;

            var reachableHotels = Enumerable.Repeat(0, MaxDigit).Select(_ => new int[n]).ToArray();

            for (int start = 0; start < reachableHotels[0].Length; start++)
            {
                reachableHotels[0][start] = SearchExtensions.GetLessEqualIndex(x, x[start] + l);
            }

            for (int dayPow = 0; dayPow + 1 < reachableHotels.Length; dayPow++)
            {
                for (int start = 0; start < n; start++)
                {
                    reachableHotels[dayPow + 1][start] = reachableHotels[dayPow][reachableHotels[dayPow][start]];
                }
            }

            var queries = inputStream.ReadInt();
            for (int q = 0; q < queries; q++)
            {
                var (from, to) = inputStream.ReadValue<int, int>();
                from--;
                to--;
                if (from > to)
                {
                    (from, to) = (to, from);
                }

                var days = 0;
                for (int dayPow = MaxDigit - 1; dayPow >= 0; dayPow--)
                {
                    if (reachableHotels[dayPow][from] < to)
                    {
                        from = reachableHotels[dayPow][from];
                        days += 1 << dayPow;
                    }
                }
                
                yield return days + 1;
            }
        }
    }
}
