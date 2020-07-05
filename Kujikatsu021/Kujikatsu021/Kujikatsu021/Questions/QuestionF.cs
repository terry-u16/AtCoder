using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu021.Algorithms;
using Kujikatsu021.Collections;
using Kujikatsu021.Extensions;
using Kujikatsu021.Numerics;
using Kujikatsu021.Questions;

namespace Kujikatsu021.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc075/tasks/arc075_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = inputStream.ReadInt() - k;
            }

            var prefixSum = new long[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + a[i];
            }

            var shrinker = new CoordinateShrinker<long>(prefixSum); // 座圧
            var bit = new BinaryIndexedTree(shrinker.Count);

            long count = 0;
            foreach (var s in prefixSum)
            {
                count += bit.Sum(..(shrinker.Shrink(s) + 1));   // 転倒数を数える
                bit[shrinker.Shrink(s)]++;
            }

            yield return count;
        }
    }
}
