using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu038.Algorithms;
using Kujikatsu038.Collections;
using Kujikatsu038.Extensions;
using Kujikatsu038.Numerics;
using Kujikatsu038.Questions;

namespace Kujikatsu038.Questions
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
                    var blacks = width * row + (height - row * 2) * column;
                    if (blacks == k)
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
