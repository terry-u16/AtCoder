using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu009.Algorithms;
using Kujikatsu009.Collections;
using Kujikatsu009.Extensions;
using Kujikatsu009.Numerics;
using Kujikatsu009.Questions;

namespace Kujikatsu009.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc067/tasks/arc067_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (towns, a, b) = inputStream.ReadValue<int, long, long>();
            var x = inputStream.ReadIntArray();

            long exhaustness = 0;
            for (int i = 0; i + 1 < x.Length; i++)
            {
                var distance = x[i + 1] - x[i];
                var walk = distance * a;
                var teleport = b;
                exhaustness += Math.Min(walk, teleport);
            }

            yield return exhaustness;
        }
    }
}
