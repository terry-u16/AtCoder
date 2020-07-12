using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu027.Algorithms;
using Kujikatsu027.Collections;
using Kujikatsu027.Extensions;
using Kujikatsu027.Numerics;
using Kujikatsu027.Questions;

namespace Kujikatsu027.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dwacon5th-prelims/tasks/dwacon5th_prelims_b
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadLongArray();
            var sums = new List<long>();

            for (int i = 0; i < a.Length; i++)
            {
                var current = a[i];
                sums.Add(current);
                for (int j = i + 1; j < a.Length; j++)
                {
                    current += a[j];
                    sums.Add(current);
                }
            }

            long result = 0;

            for (long bit = 1L << 60; bit > 0; bit >>= 1)
            {
                var candidates = new Queue<long>();
                foreach (var sum in sums)
                {
                    if ((sum & bit) > 0)
                    {
                        candidates.Enqueue(sum);
                    }
                }

                if (candidates.Count >= k)
                {
                    result |= bit;
                    sums = new List<long>(candidates);
                }
            }

            yield return result;
        }
    }
}
