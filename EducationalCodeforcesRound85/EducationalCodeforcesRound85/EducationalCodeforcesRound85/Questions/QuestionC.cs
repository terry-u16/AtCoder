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
    public class QuestionC : AtCoderQuestionBase
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
            var hps = new long[n];
            var damages = new long[n];

            for (int i = 0; i < hps.Length; i++)
            {
                hps[i] = io.ReadLong();
                damages[i] = io.ReadLong();
            }

            long baseShoots = 0;

            for (int i = 0; i < hps.Length; i++)
            {
                baseShoots += Math.Max(hps[(i + 1) % hps.Length] - damages[i], 0);
            }

            var min = long.MaxValue;

            for (int i = 0; i < hps.Length; i++)
            {
                min.ChangeMin(baseShoots + Math.Min(hps[(i + 1) % hps.Length], damages[i]));
            }

            io.WriteLine(min);
        }
    }
}
