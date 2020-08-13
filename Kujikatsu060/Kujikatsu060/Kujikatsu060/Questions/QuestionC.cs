using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu060.Algorithms;
using Kujikatsu060.Collections;
using Kujikatsu060.Extensions;
using Kujikatsu060.Numerics;
using Kujikatsu060.Questions;

namespace Kujikatsu060.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/diverta2019/tasks/diverta2019_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (reds, greens, blues, n) = inputStream.ReadValue<int, int, int, int>();
            var count = 0;

            for (int r = 0; r <= n; r += reds)
            {
                for (int g = 0; r + g <= n; g += greens)
                {
                    var b = n - r - g;
                    if (b >= 0 && b % blues == 0)
                    {
                        count++;
                    }
                }
            }

            yield return count;
        }
    }
}
