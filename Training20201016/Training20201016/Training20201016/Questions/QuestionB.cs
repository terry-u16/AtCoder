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
using Training20201016.Algorithms;
using Training20201016.Collections;
using Training20201016.Numerics;
using Training20201016.Questions;

namespace Training20201016.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var na = io.ReadInt();
            var nb = io.ReadInt();
            var a = io.ReadIntArray(na);
            var b = io.ReadIntArray(nb);

            var dp = new int[na + 1, nb + 1];


            for (int ai = na; ai >= 0; ai--)
            {
                for (int bi = nb; bi >= 0; bi--)
                {
                    if (ai == na && bi == nb)
                    {
                        continue;
                    }
                    else if ((ai + bi) % 2 == 0)
                    {
                        // すぬけ
                        if (ai == na)
                        {
                            dp[ai, bi] = dp[ai, bi + 1] + b[bi];
                        }
                        else if (bi == nb)
                        {
                            dp[ai, bi] = dp[ai + 1, bi] + a[ai];
                        }
                        else
                        {
                            dp[ai, bi] = Math.Max(dp[ai + 1, bi] + a[ai], dp[ai, bi + 1] + b[bi]);
                        }
                    }
                    else
                    {
                        // すめけ
                        if (ai == na)
                        {
                            dp[ai, bi] = dp[ai, bi + 1];
                        }
                        else if (bi == nb)
                        {
                            dp[ai, bi] = dp[ai + 1, bi];
                        }
                        else
                        {
                            dp[ai, bi] = Math.Min(dp[ai + 1, bi], dp[ai, bi + 1]);
                        }
                    }
                }
            }

            io.WriteLine(dp[0, 0]);
        }
    }
}
