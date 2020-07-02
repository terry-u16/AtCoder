using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu018.Algorithms;
using Kujikatsu018.Collections;
using Kujikatsu018.Extensions;
using Kujikatsu018.Numerics;
using Kujikatsu018.Questions;

namespace Kujikatsu018.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc008/tasks/agc008_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (x, y) = inputStream.ReadValue<int, int>();
            var absX = Math.Abs(x);
            var absY = Math.Abs(y);

            int count;
            if (absX <= absY)
            {
                count = absY - absX;
                count += x < 0 ? 1 : 0;
                count += y < 0 ? 1 : 0;
            }
            else
            {
                count = absX - absY;
                count += x > 0 ? 1 : 0;
                count += y > 0 ? 1 : 0;
            }

            yield return count;
        }
    }
}
