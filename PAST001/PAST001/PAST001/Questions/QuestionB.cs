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
using PAST001.Algorithms;
using PAST001.Collections;
using PAST001.Numerics;
using PAST001.Questions;

namespace PAST001.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var last = io.ReadInt();

            for (int i = 0; i < n - 1; i++)
            {
                var a = io.ReadInt();
                var diff = a - last;

                if (diff > 0)
                {
                    io.WriteLine($"up {diff}");
                }
                else if (diff < 0)
                {
                    io.WriteLine($"down {-diff}");
                }
                else
                {
                    io.WriteLine("stay");
                }

                last = a;
            }
        }
    }
}
