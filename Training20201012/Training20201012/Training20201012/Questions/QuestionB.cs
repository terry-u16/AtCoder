using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20201012.Algorithms;
using Training20201012.Collections;
using Training20201012.Numerics;
using Training20201012.Questions;

namespace Training20201012.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc145/tasks/abc145_f
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            const long Inf = 1L << 60;
            var n = io.ReadInt();
            var k = io.ReadInt();
            var h = io.ReadIntArray(n);
            var shrinker = new CoordinateShrinker<int>(h.Append(0));
            var hShrinked = new int[n];

            for (int i = 0; i < h.Length; i++)
            {
                hShrinked[i] = shrinker.Shrink(h[i]);
            }

            var dp = new long[n + 1, k + 1, shrinker.Count + 1].Fill(Inf);
            dp[0, 0, 0] = 0;

            for (int i = 0; i < hShrinked.Length; i++)
            {
                var currentH = hShrinked[i];

                for (int repainted = 0; repainted <= k; repainted++)
                {
                    for (int lastHeight = 0; lastHeight <= shrinker.Count; lastHeight++)
                    {
                        // 塗り替えない
                        if (currentH > lastHeight)
                        {
                            dp[i + 1, repainted, currentH].ChangeMin(dp[i, repainted, lastHeight] + shrinker.Expand(currentH) - shrinker.Expand(lastHeight));
                        }
                        else
                        {
                            dp[i + 1, repainted, currentH].ChangeMin(dp[i, repainted, lastHeight]);
                        }

                        // 塗り替える
                        if (repainted < k)
                        {
                            dp[i + 1, repainted + 1, lastHeight].ChangeMin(dp[i, repainted, lastHeight]);
                        }
                    }
                }
            }

            long min = Inf;

            for (int repainted = 0; repainted <= k; repainted++)
            {
                for (int lastHeight = 0; lastHeight <= shrinker.Count; lastHeight++)
                {
                    min.ChangeMin(dp[n, repainted, lastHeight]);
                }
            }

            io.WriteLine(min);
        }
    }
}
