using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu058.Algorithms;
using Kujikatsu058.Collections;
using Kujikatsu058.Extensions;
using Kujikatsu058.Numerics;
using Kujikatsu058.Questions;
using Kujikatsu058.Graphs.Algorithms;
using Kujikatsu058.Graphs;

namespace Kujikatsu058.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc107/tasks/arc101_b
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var candidates = a.Distinct().OrderBy(ai => ai).ToArray();

            bool CanBeMedian(int m)
            {
                var isGreaterEqual = a.Select(ai => ai >= m ? 1 : -1).ToArray();
                var prefixSum = new int[isGreaterEqual.Length + 1];
                for (int i = 0; i < isGreaterEqual.Length; i++)
                {
                    prefixSum[i + 1] = prefixSum[i] + isGreaterEqual[i];
                }

                long count = 0;
                var bit = new BinaryIndexedTree(2 * n + 1); // bit[n]が0を表すようオフセット

                foreach (var ps in prefixSum)
                {
                    var offsetted = ps + n;
                    count += bit.Sum(..(offsetted + 1));
                    bit.AddAt(offsetted, 1);
                }

                return count >= ((long)n * (n + 1) / 2 + 1) / 2;
            }

            var index = SearchExtensions.BoundaryBinarySearch(i => CanBeMedian(candidates[i]), 0, candidates.Length);
            yield return candidates[index];
        }
    }
}
