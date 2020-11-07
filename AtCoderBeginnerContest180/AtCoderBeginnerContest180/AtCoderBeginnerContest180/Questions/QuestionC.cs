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
using AtCoderBeginnerContest180.Algorithms;
using AtCoderBeginnerContest180.Collections;
using AtCoderBeginnerContest180.Numerics;
using AtCoderBeginnerContest180.Questions;

namespace AtCoderBeginnerContest180.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadLong();

            foreach (var div in Divisiors.GetDivisiors(n))
            {
                io.WriteLine(div);
            }
        }
    }
}
