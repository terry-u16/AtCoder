using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Training20200620.Algorithms;
using Training20200620.Collections;
using Training20200620.Extensions;
using Training20200620.Numerics;
using Training20200620.Questions;

namespace Training20200620.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc149/tasks/abc149_e
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (guestCount, handshakes) = inputStream.ReadValue<int, long>();
            var a = inputStream.ReadLongArray();

            Array.Sort(a, (x, y) => y.CompareTo(x));
            var prefixSum = new long[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + a[i];
            }

            var minPower = SearchExtensions.BoundaryBinarySearch(minPow =>
            {
                var countSum = GetHandshakeCountOverAll(minPow, a);
                return countSum <= handshakes;
            }, 200_001, 0);

            var overallCount = GetHandshakeCountOverAll(minPower, a);
            var happiness = a.Sum(pow =>
            {
                var count = GetHandshakeCount(minPower, pow, a);
                return prefixSum[count] + pow * count;
            });

            if (handshakes > overallCount)
            {
                happiness += (minPower - 1) * (handshakes - overallCount);
            }

            yield return happiness;
        }

        private static long GetHandshakeCount(long minPow, long otherPow, long[] a) => SearchExtensions.BoundaryBinarySearch(myPowIndex => otherPow + a[myPowIndex] >= minPow, -1, a.Length) + 1;

        private static long GetHandshakeCountOverAll(long minPow, long[] a) => a.Sum(pow => GetHandshakeCount(minPow, pow, a));
    }
}
