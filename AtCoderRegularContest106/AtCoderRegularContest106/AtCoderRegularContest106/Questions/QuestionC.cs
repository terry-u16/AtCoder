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
    public class QuestionC : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var diff = io.ReadInt();

            if (diff < 0 || (n > 1 && diff == n - 1) || diff == n)
            {
                io.WriteLine(-1);
            }
            else if (diff == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    io.WriteLine($"{2 * i + 1} {2 * i + 2}");
                }
            }
            else
            {
                io.WriteLine("1 10000000");

                for (int i = 0; i <= diff; i++)
                {
                    io.WriteLine($"{2 * i + 2} {2 * i + 3}");
                }

                var remain = n - diff - 2;

                for (int i = 0; i < remain; i++)
                {
                    io.WriteLine($"{100000000 + 2 * i} {100000000 + 2 * i + 1}");
                }
            }
        }
    }
}
