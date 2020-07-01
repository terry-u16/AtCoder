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
    /// https://atcoder.jp/contests/agc023/tasks/agc023_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            long current = 0;
            var counter = new Counter<long>();
            counter[current]++;

            foreach (var ai in a)
            {
                current += ai;
                counter[current]++;
            }

            long totalCount = 0;
            foreach (var (_, count) in counter)
            {
                totalCount += count * (count - 1) / 2;
            }

            yield return totalCount;
        }
    }
}
