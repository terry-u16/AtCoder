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
using AtCoderGrandContest048.Algorithms;
using AtCoderGrandContest048.Collections;
using AtCoderGrandContest048.Numerics;
using AtCoderGrandContest048.Questions;

namespace AtCoderGrandContest048.Questions
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

        private static void SolveEach(IOManager io)
        {
            var s = io.ReadString();
            const string atcoder = "atcoder";

            if (s.All(c => c == 'a'))
            {
                io.WriteLine(-1);
            }
            else if (string.CompareOrdinal(atcoder, s) < 0)
            {
                io.WriteLine(0);
            }
            else
            {
                int min = int.MaxValue;

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] > 'a')
                    {
                        min.ChangeMin(i);
                        break;
                    }
                }

                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] > 't')
                    {
                        min.ChangeMin(i - 1);
                        break;
                    }
                }

                io.WriteLine(min);
            }
        }
    }
}
