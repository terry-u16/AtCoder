using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu030.Algorithms;
using Kujikatsu030.Collections;
using Kujikatsu030.Extensions;
using Kujikatsu030.Numerics;
using Kujikatsu030.Questions;

namespace Kujikatsu030.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/keyence2019/tasks/keyence2019_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var current = inputStream.ReadLongArray();
            var needed = inputStream.ReadLongArray();
            var diffs = current.Zip(needed).Select(p => p.First - p.Second).ToArray();

            if (diffs.Sum() < 0)
            {
                yield return -1;
            }
            else
            {
                var minus = diffs.Where(d => d < 0).Sum();
                var count = 0;
                var plus = diffs.Where(d => d > 0).OrderByDescending(d => d).ToArray();
                while (minus < 0)
                {
                    minus += plus[count++];
                }
                
                yield return count + diffs.Count(d => d < 0);
            }
        }
    }
}
