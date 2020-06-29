using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu015.Algorithms;
using Kujikatsu015.Collections;
using Kujikatsu015.Extensions;
using Kujikatsu015.Numerics;
using Kujikatsu015.Questions;

namespace Kujikatsu015.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc094/tasks/arc095_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var x = inputStream.ReadIntArray();
            var sortedX = x.OrderBy(i => i).ToArray();

            var median = sortedX[sortedX.Length / 2 - 1];
            var medianNext = sortedX[sortedX.Length / 2];

            foreach (var xi in x)
            {
                if (xi > median)
                {
                    yield return median;
                }
                else
                {
                    yield return medianNext;
                }
            }
        }
    }
}
