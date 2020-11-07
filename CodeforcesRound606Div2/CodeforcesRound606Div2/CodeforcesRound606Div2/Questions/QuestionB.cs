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
using CodeforcesRound606Div2.Questions;

namespace CodeforcesRound606Div2.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var tests = io.ReadInt();
            var set = new SortedSet<int>();

            for (int t = 0; t < tests; t++)
            {
                var n = io.ReadInt();
                var a = io.ReadIntArray(n);
                set.Clear();

                foreach (var ai in a)
                {
                    if ((ai & 1) == 0)
                    {
                        set.Add(ai);
                    }
                }

                var count = 0;

                while (set.Count > 0)
                {
                    var max = set.Max;
                    set.Remove(max);
                    var div = max >> 1;

                    if ((div & 1) == 0)
                    {
                        set.Add(div);
                    }
                    count++;
                }

                io.WriteLine(count);
            }
        }
    }
}
