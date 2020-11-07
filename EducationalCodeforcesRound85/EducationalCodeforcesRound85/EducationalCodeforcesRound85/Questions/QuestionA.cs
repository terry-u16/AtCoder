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
    public class QuestionA : AtCoderQuestionBase
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
            var played = 0;
            var cleared = 0;

            var ok = true;

            for (int i = 0; i < n; i++)
            {
                var p = io.ReadInt();
                var c = io.ReadInt();
                var pDiff = p - played;
                var cDiff = c - cleared;

                if (pDiff < 0 || cDiff < 0 || pDiff < cDiff)
                {
                    ok = false;
                }

                played = p;
                cleared = c;
            }

            io.WriteLine(ok ? "YES" : "NO");
        }
    }
}
