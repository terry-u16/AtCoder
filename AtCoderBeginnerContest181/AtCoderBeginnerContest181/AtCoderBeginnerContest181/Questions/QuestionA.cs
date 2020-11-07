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
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();

            if (n % 2 == 0)
            {
                io.WriteLine("White");
            }
            else
            {
                io.WriteLine("Black");
            }
        }
    }
}
