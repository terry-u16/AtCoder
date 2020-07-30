using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu046.Algorithms;
using Kujikatsu046.Collections;
using Kujikatsu046.Extensions;
using Kujikatsu046.Numerics;
using Kujikatsu046.Questions;

namespace Kujikatsu046.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc024/tasks/agc024_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var lengths = new int[n];
            for (int i = 0; i < n; i++)
            {
                var p = inputStream.ReadInt() - 1;
                if (p == 0)
                {
                    lengths[0] = 1;
                }
                else
                {
                    lengths[p] = lengths[p - 1] + 1;
                }
            }

            yield return n - lengths.Max();
        }
    }
}
