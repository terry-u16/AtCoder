using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu020.Algorithms;
using Kujikatsu020.Collections;
using Kujikatsu020.Extensions;
using Kujikatsu020.Numerics;
using Kujikatsu020.Questions;

namespace Kujikatsu020.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc074/tasks/arc074_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            var prefixMax = new long[a.Length];
            var prefixMaxNumbers = new PriorityQueue<long>(false);
            var suffixMin = new long[a.Length];
            var suffixMinNumbers = new PriorityQueue<long>(true);

            prefixMax[0] = a[0];
            prefixMaxNumbers.Enqueue(a[0]);
            for (int i = 1; i < a.Length; i++)
            {
                prefixMax[i] = prefixMax[i - 1] + a[i];
                prefixMaxNumbers.Enqueue(a[i]);
                if (prefixMaxNumbers.Count > n)
                {
                    var toRemove = prefixMaxNumbers.Dequeue();
                    prefixMax[i] -= toRemove;
                }
            }

            suffixMin[^1] = a[^1];
            suffixMinNumbers.Enqueue(a[^1]);

            for (int i = a.Length - 2; i >= 0; i--)
            {
                suffixMin[i] = suffixMin[i + 1] + a[i];
                suffixMinNumbers.Enqueue(a[i]);
                if (suffixMinNumbers.Count > n)
                {
                    var toRemove = suffixMinNumbers.Dequeue();
                    suffixMin[i] -= toRemove;
                }
            }

            var maxScore = long.MinValue;
            for (int separated = n - 1; separated < 2 * n; separated++)
            {
                maxScore = Math.Max(maxScore, prefixMax[separated] - suffixMin[separated + 1]);
            }

            yield return maxScore;
        }
    }
}
