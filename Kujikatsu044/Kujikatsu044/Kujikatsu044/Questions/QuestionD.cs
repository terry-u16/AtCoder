using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu044.Algorithms;
using Kujikatsu044.Collections;
using Kujikatsu044.Extensions;
using Kujikatsu044.Numerics;
using Kujikatsu044.Questions;

namespace Kujikatsu044.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc115/tasks/abc115_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        long[] buns;
        long[] patties;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, x) = inputStream.ReadValue<int, long>();
            buns = new long[n + 1];
            patties = new long[n + 1];
            buns[0] = 0;
            patties[0] = 1;

            for (int i = 1; i < buns.Length; i++)
            {
                buns[i] = buns[i - 1] * 2 + 2;
                patties[i] = patties[i - 1] * 2 + 1;
            }

            yield return CountPatties(n, x);
        }

        long CountPatties(int level, long toEat)
        {
            if (level == 0)
            {
                return 1;
            }
            else if (toEat <= 1)
            {
                return 0;
            }
            else if (toEat < 1 + buns[level - 1] + patties[level - 1])
            {
                return CountPatties(level - 1, toEat - 1);
            }
            else if (toEat <= 1 + buns[level - 1] + patties[level - 1])
            {
                return patties[level - 1];
            }
            else if (toEat <= 1 + buns[level - 1] + patties[level - 1] + 1)
            {
                return patties[level - 1] + 1;
            }
            else if (toEat < 1 + buns[level - 1] + patties[level - 1] + 1 + buns[level - 1] + patties[level - 1])
            {
                return patties[level - 1] + 1 + CountPatties(level - 1, toEat - buns[level - 1] - patties[level - 1] - 2);
            }
            else
            {
                return patties[level - 1] + 1 + patties[level - 1];
            }
        }
    }
}
