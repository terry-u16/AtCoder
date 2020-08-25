using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu072.Algorithms;
using Kujikatsu072.Collections;
using Kujikatsu072.Extensions;
using Kujikatsu072.Numerics;
using Kujikatsu072.Questions;

namespace Kujikatsu072.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc072/tasks/arc082_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray().Select(i => i + 1).ToArray();
            var counts = new int[a.Max() + 2];

            foreach (var ai in a)
            {
                counts[ai - 1]++;
                counts[ai]++;
                counts[ai + 1]++;
            }

            yield return counts.Max();
        }
    }
}
