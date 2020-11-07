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
using AtCoderBeginnerContest181.Algorithms;
using AtCoderBeginnerContest181.Collections;
using AtCoderBeginnerContest181.Numerics;
using AtCoderBeginnerContest181.Questions;

namespace AtCoderBeginnerContest181.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var s = io.ReadString();

            var counts = new int[10];

            if (s.Length == 1)
            {
                if ((s[0] - '0') % 8 == 0)
                {
                    io.WriteLine("Yes");
                    return;
                }
            }
            else if (s.Length == 2)
            {
                var a = s[0] - '0';
                var b = s[1] - '0';

                if ((a * 10 + b) % 8 == 0 || (b * 10 + a) % 8 == 0)
                {
                    io.WriteLine("Yes");
                    return;
                }
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    counts[s[i] - '0']++;
                }

                for (int i = 0; i < 1000; i += 8)
                {
                    var current = i;
                    var needed = new int[10];
                    for (int j = 0; j < 3; j++)
                    {
                        needed[current % 10]++;
                        current /= 10;
                    }

                    var ok = true;

                    for (int j = 0; j < needed.Length; j++)
                    {
                        ok &= counts[j] >= needed[j];
                    }

                    if (ok)
                    {
                        io.WriteLine("Yes");
                        return;
                    }
                }
            }

            io.WriteLine("No");
        }
    }
}
