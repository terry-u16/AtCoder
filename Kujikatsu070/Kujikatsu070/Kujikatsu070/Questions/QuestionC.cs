using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu070.Algorithms;
using Kujikatsu070.Collections;
using Kujikatsu070.Extensions;
using Kujikatsu070.Numerics;
using Kujikatsu070.Questions;

namespace Kujikatsu070.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc130/tasks/abc130_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (width, height, x, y) = inputStream.ReadValue<int, int, int, int>();
            var area = (double)width * height * 0.5;

            if (x * 2 == width && y * 2 == height)
            {
                yield return $"{area} 1";
            }
            else
            {
                yield return $"{area} 0";
            }
        }
    }
}
