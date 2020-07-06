using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200706.Algorithms;
using Training20200706.Collections;
using Training20200706.Extensions;
using Training20200706.Numerics;
using Training20200706.Questions;
using System.Diagnostics.CodeAnalysis;

namespace Training20200706.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/joi2015ho/tasks/joi2015ho_b
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        int n;
        long[] area;
        long[,] memo;

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            n = inputStream.ReadInt();
            area = new long[n];
            for (int i = 0; i < n; i++)
            {
                area[i] = inputStream.ReadLong();
            }
            memo = new long[n, n].SetAll((i, j) => int.MinValue);

            long max = 0;
            for (int take = 0; take < n; take++)
            {
                var from = (take + 1) % n;
                var to = (take - 1 + n) % n;
                max = Math.Max(max, Dfs(from, to) + area[take]);
            }

            yield return max;
        }


        long Dfs(int from, int to)
        {
            if (memo[from, to] != int.MinValue)
            {
                return memo[from, to];
            }
            else
            {
                var last = (n + to - from + 1) % n;

                if ((n - last) % 2 == 0)
                {
                    // JOIくんのターン
                    if (from == to)
                    {
                        return memo[from, to] = area[from];
                    }
                    else
                    {
                        return memo[from, to] = Math.Max(Dfs((from + 1) % n, to) + area[from], Dfs(from, (to - 1 + n) % n) + area[to]);
                    }
                }
                else
                {
                    // IOIちゃんのターン
                    if (from == to)
                    {
                        return memo[from, to] = 0;
                    }
                    else
                    {
                        if (area[from] > area[to])
                        {
                            return memo[from, to] = Dfs((from + 1) % n, to);
                        }
                        else
                        {
                            return memo[from, to] = Dfs(from, (to - 1 + n) % n);
                        }
                    }
                }
            }
        }
    }
}
