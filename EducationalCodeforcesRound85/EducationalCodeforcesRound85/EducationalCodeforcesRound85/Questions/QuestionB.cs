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
using EducationalCodeforcesRound85.Questions;

namespace EducationalCodeforcesRound85.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();

            for (int t = 0; t < tests; t++)
            {
                SolveEach(io);
            }
        }

        private void SolveEach(IOManager io)
        {
            var n = io.ReadInt();
            var threshold = io.ReadInt();

            var savings = io.ReadIntArray(n);
            savings.Sort((a, b) => b.CompareTo(a));

            long sum = 0;

            for (int i = 0; i < savings.Length; i++)
            {
                sum += savings[i];

                if (sum / (i + 1) < threshold)
                {
                    io.WriteLine(i);
                    return;
                }
            }

            io.WriteLine(n);
        }
    }
}
