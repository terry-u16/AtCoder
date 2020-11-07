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
using AtCoderBeginnerContest181.Algorithms;
using AtCoderBeginnerContest181.Collections;
using AtCoderBeginnerContest181.Numerics;
using AtCoderBeginnerContest181.Questions;

namespace AtCoderBeginnerContest181.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var result = 0L;

            for (int i = 0; i < n; i++)
            {
                var l = io.ReadInt();
                var r = io.ReadInt();

                result += Sum(r);
                result -= Sum(l - 1);
            }

            io.WriteLine(result);
        }

        long Sum(long n) => n * (n + 1) / 2;
    }
}
