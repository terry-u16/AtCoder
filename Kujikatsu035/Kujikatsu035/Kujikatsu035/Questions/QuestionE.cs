using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu035.Algorithms;
using Kujikatsu035.Collections;
using Kujikatsu035.Extensions;
using Kujikatsu035.Numerics;
using Kujikatsu035.Questions;

namespace Kujikatsu035.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc105/tasks/abc105_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (boxCount, children) = inputStream.ReadValue<int, int>();
            var candies = inputStream.ReadIntArray();
            Modular.Mod = children;
            var prefixSum = new Modular[boxCount + 1];

            for (int i = 0; i < candies.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + candies[i];
            }

            var counts = new Counter<int>();
            long total = 0;

            foreach (var mod in prefixSum)
            {
                counts[mod.Value]++;
            }

            foreach (var (value, c) in counts)
            {
                total += c * (c - 1) / 2;
            }

            yield return total;
        }
    }
}
