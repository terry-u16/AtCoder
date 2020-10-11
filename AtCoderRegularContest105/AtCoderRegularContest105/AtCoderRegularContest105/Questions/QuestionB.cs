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
    public class QuestionB : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var a = io.ReadIntArray(n);

            var set = new SortedSet<int>();

            foreach (var ai in a)
            {
                set.Add(ai);
            }

            while (set.Count > 1)
            {
                var min = set.Min;
                var max = set.Max;

                set.Remove(max);
                var sub = (max - 1) / min * min; 
                var next = max - sub;

                set.Add(next);
            }

            io.WriteLine(set.Min);
        }
    }
}
