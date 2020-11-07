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
using AtCoderBeginnerContest180.Algorithms;
using AtCoderBeginnerContest180.Collections;
using AtCoderBeginnerContest180.Numerics;
using AtCoderBeginnerContest180.Questions;

namespace AtCoderBeginnerContest180.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var x = io.ReadLong();
            var y = io.ReadLong();
            var a = io.ReadInt();
            var b = io.ReadInt();

            long exp = 0;

            while (true)
            {
                var mul = BigInteger.Multiply(x, a);
                var add = x + b;

                if (add >= y && mul >= y)
                {
                    io.WriteLine(exp);
                    return;
                }
                else if (add > mul)
                {
                    x *= a;
                    exp++;
                }
                else
                {
                    var count = (y - 1 - x) / b;
                    x += b * count;
                    exp += count;
                }
            }
        }
    }
}
