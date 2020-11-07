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

namespace AtCoderRegularContest107.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadLong();
            var k = io.ReadLong();
            k = Math.Abs(k);

            long result = 0;

            for (long i = k + 2; i <= 2 * n; i++)
            {
                var ab = Math.Min(i - 1, 2 * n - i + 1);
                var cd = Math.Min(i - k - 1, 2 * n + k - i + 1);
                result += ab * cd;
            }

            io.WriteLine(result);
        }
    }
}
