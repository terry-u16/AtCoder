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
using AtCoderRegularContest106.Algorithms;
using AtCoderRegularContest106.Collections;
using AtCoderRegularContest106.Numerics;
using AtCoderRegularContest106.Questions;

namespace AtCoderRegularContest106.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadLong();
            long three = 1;

            for (int i = 1; true; i++)
            {
                three *= 3;

                if (three > n)
                {
                    break;
                }

                long five = 1;

                for (int j = 1; true; j++)
                {
                    five *= 5;

                    if (three + five > n)
                    {
                        break;
                    }
                    else if (three + five == n)
                    {
                        io.WriteLine($"{i} {j}");
                        return;
                    }
                }
            }

            io.WriteLine(-1);
        }
    }
}
