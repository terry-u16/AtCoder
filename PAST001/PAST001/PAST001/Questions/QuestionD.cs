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
    public class QuestionD : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);
            var bucket = new int[n];

            foreach (var ai in a)
            {
                bucket[ai - 1]++;
            }

            var two = -1;
            var zero = -1;

            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] == 0)
                {
                    zero = i + 1;
                }
                else if (bucket[i] > 1)
                {
                    two = i + 1;
                }
            }

            if (zero == -1)
            {
                io.WriteLine("Correct");
            }
            else
            {
                io.WriteLine($"{two} {zero}");
            }
        }
    }
}
