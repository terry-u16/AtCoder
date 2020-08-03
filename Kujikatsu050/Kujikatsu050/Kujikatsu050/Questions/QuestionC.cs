using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu050.Algorithms;
using Kujikatsu050.Collections;
using Kujikatsu050.Extensions;
using Kujikatsu050.Numerics;
using Kujikatsu050.Questions;

namespace Kujikatsu050.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc058/tasks/arc071_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var counts = Enumerable.Repeat(int.MaxValue, 26).ToArray();

            for (int i = 0; i < n; i++)
            {
                var s = inputStream.ReadLine();
                for (char c = 'a'; c <= 'z'; c++)
                {
                    counts[c - 'a'] = Math.Min(counts[c - 'a'], s.Count(si => si == c));
                }
            }

            var result = "";
            for (char c = 'a'; c <= 'z'; c++)
            {
                result += Enumerable.Repeat(c, counts[c - 'a']).Join();
            }

            yield return result;
        }
    }
}
