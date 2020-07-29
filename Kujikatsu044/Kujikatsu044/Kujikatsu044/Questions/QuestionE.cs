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
    /// https://atcoder.jp/contests/abc068/tasks/arc079_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadLong();

            yield return 50;

            if (k % 50 == 0)
            {
                yield return Enumerable.Repeat(49 + k / 50, 50).Join(' ');
            }
            else
            {
                var max = 100 - k % 50 + k / 50;
                var min = 49 + k / 50 - k % 50;
                var maxCount = (int)(k % 50);
                yield return Enumerable.Repeat(max, maxCount).Concat(Enumerable.Repeat(min, 50 - maxCount)).Join(' ');
            }
        }
    }
}
