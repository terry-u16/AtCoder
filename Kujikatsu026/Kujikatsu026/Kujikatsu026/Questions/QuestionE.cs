using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu026.Algorithms;
using Kujikatsu026.Collections;
using Kujikatsu026.Extensions;
using Kujikatsu026.Numerics;
using Kujikatsu026.Questions;

namespace Kujikatsu026.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/cf17-final/tasks/cf17_final_c
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var d = inputStream.ReadIntArray();
            var counts = new int[13];
            counts[0]++;
            foreach (var di in d)
            {
                counts[di]++;
            }

            if (counts.Any(c => c > 2) || counts[0] > 1 || counts[12] > 1)
            {
                yield return 0;
                yield break;
            }

            yield return Dfs(counts, 0, 0);
        }

        int Dfs(int[] counts, int flags, int hour)
        {
            if (hour > 12)
            {
                flags |= 1 << 24;
                flags >>= 1;
                var min = int.MaxValue;
                var diff = 0;
                while (flags > 0)
                {
                    diff++;
                    if ((flags & 1) > 0)
                    {
                        min = Math.Min(min, diff);
                        diff = 0;
                    }
                    flags >>= 1;
                }
                return min;
            }
            else
            {
                var max = counts[hour] switch
                {
                    0 => Dfs(counts, flags, hour + 1),
                    1 => Math.Max(Dfs(counts, flags | (1 << hour), hour + 1), Dfs(counts, flags | (1 << (24 - hour)), hour + 1)),
                    _ => Dfs(counts, flags | (1 << hour) | (1 << (24 - hour)), hour + 1)
                };
                return max;
            }
        }
    }
}
