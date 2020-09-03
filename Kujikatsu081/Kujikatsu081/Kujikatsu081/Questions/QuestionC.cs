using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu081.Algorithms;
using Kujikatsu081.Collections;
using Kujikatsu081.Extensions;
using Kujikatsu081.Numerics;
using Kujikatsu081.Questions;

namespace Kujikatsu081.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc051/tasks/abc051_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (k, s) = inputStream.ReadValue<int, int>();
            var count = 0;

            for (int x = 0; x <= k; x++)
            {
                for (int y = 0; y <= k; y++)
                {
                    var z = s - x - y;
                    if (unchecked((uint)z) <= k)
                    {
                        count++;
                    }
                }
            }

            yield return count;
        }
    }
}
