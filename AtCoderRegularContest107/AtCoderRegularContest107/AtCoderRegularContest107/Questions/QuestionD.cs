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
using System.Runtime.Intrinsics.X86;
using AtCoderRegularContest107.Algorithms;
using AtCoderRegularContest107.Collections;
using AtCoderRegularContest107.Numerics;
using AtCoderRegularContest107.Questions;
using ModInt = AtCoderRegularContest107.Numerics.StaticModInt<AtCoderRegularContest107.Numerics.Mod998244353>;

namespace AtCoderRegularContest107.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var k = io.ReadInt();

            var dp = new ModInt[n + 1, n + 1];
            dp[n, k] = ModInt.One;

            for (int i = n; i > 0; i--)
            {
                for (int remain = 0; remain <= n; remain++)
                {
                    if (remain * 2 <= n)
                    {
                        dp[i, remain * 2] += dp[i, remain];
                    }

                    if (remain > 0)
                    {
                        dp[i - 1, remain - 1] += dp[i, remain];
                    }
                }
            }
            
            io.WriteLine(dp[0, 0]);
        }
    }
}
