using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu095.Algorithms;
using Kujikatsu095.Collections;
using Kujikatsu095.Extensions;
using Kujikatsu095.Numerics;
using Kujikatsu095.Questions;

namespace Kujikatsu095.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc097/tasks/abc097_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var x = inputStream.ReadInt();
            var max = 1;

            for (int b = 2; b * b <= x; b++)
            {
                var current = b * b;
                while (current <= x)
                {
                    max = Math.Max(max, current);
                    current *= b;
                }
            }

            yield return max;
        }
    }
}
