using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Training20200621.Algorithms;
using Training20200621.Collections;
using Training20200621.Extensions;
using Training20200621.Numerics;
using Training20200621.Questions;

namespace Training20200621.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2015-morning-hard/tasks/cf_2015_morning_hard_a
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
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

            long current = 0;
            for (int i = 0; i < a.Length; i++)
            {
                current += i * a[i];
            }

            var left = 0;
            var right = n - 1;

            for (int i = 0; i < right; i++)
            {
                current += i;
            }

            long min = current;

            for (int pivot = 1; pivot < a.Length; pivot += 2)
            {
                current -= 2 * (prefixSum[^1] - prefixSum[pivot]);
                current += 2 * prefixSum[pivot + 1];

                right -= 2;
                current -= 2 * right + 1;
                current += 2 * left + 1;
                left += 2;

                min = Math.Min(min, current);
            }

            yield return min;
        }
    }
}
