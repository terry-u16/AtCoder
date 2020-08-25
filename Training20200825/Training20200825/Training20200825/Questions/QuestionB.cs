using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200825.Algorithms;
using Training20200825.Collections;
using Training20200825.Extensions;
using Training20200825.Numerics;
using Training20200825.Questions;

namespace Training20200825.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc146/tasks/abc146_e
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray().Select(i => (i - 1) % k).ToArray();

            var prefixSum = new int[a.Length + 1];

            for (int i = 0; i < a.Length; i++)
            {
                prefixSum[i + 1] = (prefixSum[i] + a[i]) % k;
            }

            var counts = new Counter<int>();
            var left = 0;
            var right = 0;
            var result = 0L;

            for (right = 0; right <= Math.Min(a.Length, k - 1); right++)
            {
                counts[prefixSum[right]]++;
            }

            while (left < a.Length)
            {
                counts[prefixSum[left]]--;
                result += counts[prefixSum[left]];

                if (right < prefixSum.Length)
                {
                    counts[prefixSum[right++]]++;
                }

                left++;
            }
            
            yield return result;
        }
    }
}
