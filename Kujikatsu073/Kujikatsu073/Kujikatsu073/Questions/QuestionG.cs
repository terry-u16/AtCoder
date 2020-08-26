using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu073.Algorithms;
using Kujikatsu073.Collections;
using Kujikatsu073.Extensions;
using Kujikatsu073.Numerics;
using Kujikatsu073.Questions;

namespace Kujikatsu073.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2016-qualc/tasks/codefestival_2016_qualC_d
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (height, width) = inputStream.ReadValue<int, int>();
            var blocks = Enumerable.Repeat(0, width).Select(_ => new char[height]).ToArray();

            for (int row = 0; row < height; row++)
            {
                var s = inputStream.ReadLine();
                for (int column = 0; column < width; column++)
                {
                    blocks[column][^(row + 1)] = s[column];
                }
            }

            var total = 0;

            for (int column = 0; column + 1 < width; column++)
            {
                total += Count(blocks[column], blocks[column + 1]);
            }

            yield return total;
        }

        int Count(char[] left, char[] right)
        {
            const int Inf = 1 << 28;
            var dp = new int[left.Length + 1, right.Length + 1].SetAll((i, j) => Inf);
            dp[0, 0] = 0;

            var costs = new int[2 * left.Length + 1, left.Length + 1];
            for (int diff = -left.Length; diff <= right.Length; diff++)
            {
                var index = diff + left.Length;
                var ls = diff < 0 ? left.AsSpan(-diff) : left.AsSpan();
                var rs = diff > 0 ? right.AsSpan(diff) : right.AsSpan();

                for (int i = 0; i < Math.Min(ls.Length, rs.Length); i++)
                {
                    costs[index, i] = ls[i] == rs[i] ? 1 : 0;
                }

                for (int i = left.Length - 1; i >= 0; i--)
                {
                    costs[index, i] += costs[index, i + 1];
                }
            }

            for (int l = 0; l <= left.Length; l++)
            {
                for (int r = 0; r <= right.Length; r++)
                {
                    var diff = r - l;
                    var geta = Math.Min(l, r);
                    var cost = costs[diff + left.Length, geta];
                    // 左を消す
                    if (l < left.Length)
                    {
                        UpdateWhenSmall(ref dp[l + 1, r], dp[l, r] + cost);
                    }

                    // 右を消す
                    if (r < right.Length)
                    {
                        UpdateWhenSmall(ref dp[l, r + 1], dp[l, r] + cost);
                    }
                }
            }

            return dp[left.Length, right.Length];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateWhenSmall<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) < 0)
            {
                value = other;
            }
        }
    }
}
