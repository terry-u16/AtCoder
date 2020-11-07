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
using Training20201020.Algorithms;
using Training20201020.Collections;
using Training20201020.Numerics;
using Training20201020.Questions;

namespace Training20201020.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var a = io.ReadInt();
            var b = io.ReadInt();

            if (a * b % 2 == 1)
            {
                io.WriteLine("Yes");
            }
            else
            {
                io.WriteLine("No");
            }
        }
    }
}
