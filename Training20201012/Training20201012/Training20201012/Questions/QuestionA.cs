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
using Training20201012.Algorithms;
using Training20201012.Collections;
using Training20201012.Numerics;
using Training20201012.Questions;
using System.Runtime.Intrinsics.X86;

namespace Training20201012.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var k = io.ReadInt();
            var a = io.ReadIntArray(n);

            long min = long.MaxValue;

            for (var flag = BitSet.Zero; flag < (1 << n); flag++)
            {
                if (Popcnt.PopCount(flag) == k)
                {
                    int last = 0;
                    long total = 0;

                    for (int i = 0; i < a.Length; i++)
                    {
                        if (flag[i])
                        {
                            if (last >= a[i])
                            {
                                var added = last - a[i] + 1;
                                last++;
                                total += added;
                            }
                        }

                        last.ChangeMax(a[i]);
                    }

                    min.ChangeMin(total);
                }
            }

            io.WriteLine(min);
        }
    }
}
