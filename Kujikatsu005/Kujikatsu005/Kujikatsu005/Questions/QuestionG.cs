using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Kujikatsu005.Algorithms;
using Kujikatsu005.Collections;
using Kujikatsu005.Extensions;
using Kujikatsu005.Numerics;
using Kujikatsu005.Questions;

namespace Kujikatsu005.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc016/tasks/agc016_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, h, w) = inputStream.ReadValue<int, int, int, int>();
            int baseValue = 1_000_000_000 / (h * w);
            var a = Enumerable.Range(0, height).Select(_ => Enumerable.Repeat(baseValue, width).ToArray()).ToArray();

            var minus = -(baseValue * (h * w - 1) + 1);
            for (int r = 0; r < a.Length; r++)
            {
                var row = a[r];
                for (int c = 0; c < row.Length; c++)
                {
                    if ((r + 1) % h == 0 && (c + 1) % w == 0)
                    {
                        row[c] = minus;
                    }
                }
            }

            var sum = a.Sum(row => row.Select(i => (long)i).Sum());

            if (sum > 0)
            {
                yield return "Yes";
                foreach (var row in a)
                {
                    yield return string.Join(" ", row);
                }
            }
            else
            {
                yield return "No";
            }
        }
    }
}
