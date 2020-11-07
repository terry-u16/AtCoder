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
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var p = io.ReadIntArray(n);
            var dp = new bool[p.Sum() + 1];

            dp[0] = true;

            foreach (var pi in p)
            {
                for (int i = dp.Length - 1; i - pi >= 0; i--)
                {
                    dp[i] |= dp[i - pi];
                }
            }

            io.WriteLine(dp.Count(b => b));
        }
    }
}
