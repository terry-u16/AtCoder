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
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();

            double manhattan = 0;
            double euclid = 0;
            double che = 0;

            for (int i = 0; i < n; i++)
            {
                var x = io.ReadDouble();
                manhattan += Math.Abs(x);
                euclid += x * x;
                che.ChangeMax(Math.Abs(x));
            }

            euclid = Math.Sqrt(euclid);

            io.WriteLine(manhattan);
            io.WriteLine(euclid);
            io.WriteLine(che);
        }
    }
}
