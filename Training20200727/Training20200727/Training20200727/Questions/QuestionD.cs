using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200727.Algorithms;
using Training20200727.Collections;
using Training20200727.Extensions;
using Training20200727.Numerics;
using Training20200727.Questions;

namespace Training20200727.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dp/tasks/dp_n
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        int slimes;
        long[,] slimeSizes;
        long[,] dp;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            slimes = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();
            slimeSizes = new long[slimes, slimes];
            dp = new long[slimes, slimes];

            for (int left = 0; left < a.Length; left++)
            {
                long prefixSum = 0;
                for (int right = left; right < a.Length; right++)
                {
                    prefixSum += a[right];
                    slimeSizes[left, right] = prefixSum;
                }
            }

            yield return Dfs(0, slimes - 1);
        }

        long Dfs(int left, int right)
        {
            if (dp[left, right] > 0)
            {
                return dp[left, right];
            }
            else if (left == right)
            {
                return 0;
            }
            else
            {
                long min = long.MaxValue;
                for (int split = left; split < right; split++)
                {
                    min = Math.Min(min, Dfs(left, split) + Dfs(split + 1, right) + slimeSizes[left, split] + slimeSizes[split + 1, right]);
                }
                return dp[left, right] = min;
            }
        }
    }
}
