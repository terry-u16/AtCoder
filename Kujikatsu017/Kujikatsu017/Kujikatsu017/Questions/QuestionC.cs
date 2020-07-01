using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu017.Algorithms;
using Kujikatsu017.Collections;
using Kujikatsu017.Extensions;
using Kujikatsu017.Numerics;
using Kujikatsu017.Questions;

namespace Kujikatsu017.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc082/tasks/arc087_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var counter = new Counter<int>();
            foreach (var ai in a)
            {
                counter[ai]++;
            }

            long totalCount = 0;
            foreach (var (value, count) in counter)
            {
                if (count >= value)
                {
                    totalCount += count - value;
                }
                else
                {
                    totalCount += count;
                }
            }

            yield return totalCount;
        }
    }
}
