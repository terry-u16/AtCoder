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
    /// https://atcoder.jp/contests/dp/tasks/dp_l
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        int n;
        long[] a;
        long[,] dp;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            n = inputStream.ReadInt();
            a = inputStream.ReadLongArray();
            dp = new long[n, n].SetAll((i, j) => long.MaxValue);
            yield return Dfs(0, n - 1, 0);
        }

        long Dfs(int left, int right, int turn)
        {
            if (dp[left, right] != long.MaxValue)
            {
                return dp[left, right];
            }
            else if (left == right)
            {
                return dp[left, right] = (turn % 2 == 0 ? 1 : -1) * a[left];
            }
            else if (turn % 2 == 0)
            {
                // 太郎くん
                return dp[left, right] = Math.Max(Dfs(left + 1, right, turn + 1) + a[left], Dfs(left, right - 1, turn + 1) + a[right]);
            }
            else
            {
                // 次郎くん
                return dp[left, right] = Math.Min(Dfs(left + 1, right, turn + 1) - a[left], Dfs(left, right - 1, turn + 1) - a[right]);
            }
        }
    }
}
