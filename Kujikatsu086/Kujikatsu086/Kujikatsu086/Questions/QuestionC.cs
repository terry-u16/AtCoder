using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu086.Algorithms;
using Kujikatsu086.Collections;
using Kujikatsu086.Extensions;
using Kujikatsu086.Numerics;
using Kujikatsu086.Questions;

namespace Kujikatsu086.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2017-quala/tasks/code_festival_2017_quala_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width, k) = inputStream.ReadValue<int, int, int>();

            for (int row = 0; row <= height; row++)
            {
                for (int column = 0; column <= width; column++)
                {
                    if (row * width + column * height - 2 * row * column == k)
                    {
                        yield return "Yes";
                        yield break;
                    }
                }
            }

            yield return "No";
        }
    }
}
