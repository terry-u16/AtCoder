using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu011.Algorithms;
using Kujikatsu011.Collections;
using Kujikatsu011.Extensions;
using Kujikatsu011.Numerics;
using Kujikatsu011.Questions;

namespace Kujikatsu011.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc106/tasks/abc106_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (cities, trains, queries) = inputStream.ReadValue<int, int, int>();
            var counts = new int[cities, cities];

            for (int t = 0; t < trains; t++)
            {
                var (l, r) = inputStream.ReadValue<int, int>();
                l--;
                r--;
                counts[l, r]++;
            }

            for (int i = 0; i < cities; i++)
            {
                for (int j = 0; j + 1 < cities; j++)
                {
                    counts[i, j + 1] += counts[i, j];
                }
            }

            for (int j = 0; j < cities; j++)
            {
                for (int i = cities - 1; i - 1 >= 0; i--)
                {
                    counts[i - 1, j] += counts[i, j];
                }
            }

            for (int q = 0; q < queries; q++)
            {
                var (l, r) = inputStream.ReadValue<int, int>();
                l--;
                r--;
                yield return counts[l, r];
            }
        }
    }
}
