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
using AtCoderRegularContest105.Algorithms;
using AtCoderRegularContest105.Collections;
using AtCoderRegularContest105.Numerics;
using AtCoderRegularContest105.Questions;

namespace AtCoderRegularContest105.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var cookies = io.ReadIntArray(4);
            var sum = cookies.Sum();

            for (var flag = BitSet.Zero; flag < (1 << 4); flag++)
            {
                var total = 0;
                for (int i = 0; i < cookies.Length; i++)
                {
                    if (flag[i])
                    {
                        total += cookies[i];
                    }
                }

                if (sum - total == total)
                {
                    io.WriteLine("Yes");
                    return;
                }
            }

            io.WriteLine("No");
        }
    }
}
