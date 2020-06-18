using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Kujikatsu004.Algorithms;
using Kujikatsu004.Collections;
using Kujikatsu004.Extensions;
using Kujikatsu004.Numerics;
using Kujikatsu004.Questions;

namespace Kujikatsu004.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc056/tasks/arc070_b
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        const int mod = 1_000_000_007;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            Array.Sort(a);

            var count = SearchExtensions.BoundaryBinarySearch(ignored => !Needed(n, k, ignored, a), -1, n) + 1;

            yield return count;
        }

        bool Needed(int n, int k, int ignored, int[] a)
        {
            var canMake = new bool[n + 1, k];
            canMake[0, 0] = true;

            for (int item = 0; item < a.Length; item++)
            {
                for (int sum = 0; sum < k; sum++)
                {
                    var current = canMake[item, sum];
                    canMake[item + 1, sum] |= current;
                    var next = sum + a[item];
                    if (item != ignored && next < k)
                    {
                        canMake[item + 1, next] |= current;
                    }
                }
            }

            var needed = false;
            for (int sum = Math.Max(0, k - a[ignored]); sum < k; sum++)
            {
                needed |= canMake[n, sum];
            }
            return needed;
        }
    }
}
