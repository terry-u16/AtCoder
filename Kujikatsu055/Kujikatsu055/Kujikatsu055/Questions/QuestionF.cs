using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu055.Algorithms;
using Kujikatsu055.Collections;
using Kujikatsu055.Extensions;
using Kujikatsu055.Numerics;
using Kujikatsu055.Questions;

namespace Kujikatsu055.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc100/tasks/arc100_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            var prefixSum = new long[a.Length + 1];

            for (int i = 0; i < a.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + a[i];
            }

            long min = long.MaxValue;

            for (int split = 3; split < prefixSum.Length - 1; split++)
            {
                min = Math.Min(min, GetMin(prefixSum, split));
            }

            yield return min;
        }

        long GetMin(long[] prefixSum, int split)
        {
            var leftSum = prefixSum.AsSpan()[..split];
            var rightSum = prefixSum.AsSpan()[(split - 1)..];

            var leftSplit = SearchExtensions.GetLessEqualIndex(leftSum, leftSum[^1] / 2);
            var rightSplit = SearchExtensions.GetLessEqualIndex(rightSum, (rightSum[^1] - rightSum[0]) / 2 + rightSum[0]);

            var p = new[] { leftSum[leftSplit], leftSum[leftSplit + 1] };
            var q = new[] { leftSum[^1] - leftSum[leftSplit], leftSum[^1] - leftSum[leftSplit + 1] };

            var r = new[] { rightSum[rightSplit] - rightSum[0], rightSum[rightSplit + 1] - rightSum[0] };
            var s = new[] { rightSum[^1] - rightSum[rightSplit], rightSum[^1] - rightSum[rightSplit + 1] };

            var min = long.MaxValue;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    var maxSum = Math.Max(p[i], Math.Max(q[i], Math.Max(r[j], s[j])));
                    var minSum = Math.Min(p[i], Math.Min(q[i], Math.Min(r[j], s[j])));

                    min = Math.Min(min, maxSum - minSum);
                }
            }
            return min;
        }


    }
}
