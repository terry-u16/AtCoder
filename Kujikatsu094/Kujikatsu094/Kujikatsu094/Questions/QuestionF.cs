using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu094.Algorithms;
using Kujikatsu094.Collections;
using Kujikatsu094.Extensions;
using Kujikatsu094.Numerics;
using Kujikatsu094.Questions;

namespace Kujikatsu094.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc149/tasks/abc149_e
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (guests, handshakes) = inputStream.ReadValue<int, long>();
            var powers = inputStream.ReadLongArray();
            Array.Sort(powers, (l, r) => r.CompareTo(l));
            var prefixSum = new long[powers.Length + 1];
            for (int i = 0; i < powers.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + powers[i];
            }

            var minPower = SearchExtensions.BoundaryBinarySearch(Check, 1L << 60, -1);

            var result = 0L;
            long total = 0;

            for (int i = 0; i < powers.Length; i++)
            {
                var j = SearchExtensions.BoundaryBinarySearch(idx => powers[i] + powers[idx] >= minPower, -1, powers.Length);
                var count = j + 1;
                result += powers[i] * count + prefixSum[count];
                total += count;
            }

            result += (minPower - 1) * (handshakes - total);

            yield return result;

            bool Check(long minPower)
            {
                long count = 0;

                for (int i = 0; i < powers.Length; i++)
                {
                    count += SearchExtensions.BoundaryBinarySearch(j => powers[i] + powers[j] >= minPower, -1, powers.Length) + 1;
                }

                return count <= handshakes;
            }
        }
    }
}
