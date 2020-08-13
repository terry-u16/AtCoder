using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu060.Algorithms;
using Kujikatsu060.Collections;
using Kujikatsu060.Extensions;
using Kujikatsu060.Numerics;
using Kujikatsu060.Questions;

namespace Kujikatsu060.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc031/tasks/agc031_b
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var colors = new List<int>();
            var last = -1;
            for (int i = 0; i < n; i++)
            {
                var color = inputStream.ReadInt() - 1;
                if (color != last)
                {
                    colors.Add(color);
                }
                last = color;
            }

            var lastSeen = Enumerable.Repeat(-1, colors.Max() + 1).ToArray();
            var dp = new Modular[colors.Count + 1];
            dp[0] = 1;

            for (int i = 0; i < colors.Count; i++)
            {
                dp[i + 1] += dp[i];

                if (lastSeen[colors[i]] != -1)
                {
                    dp[i + 1] += dp[lastSeen[colors[i]] + 1];
                }

                lastSeen[colors[i]] = i;
            }

            yield return dp[colors.Count];
        }
    }
}
