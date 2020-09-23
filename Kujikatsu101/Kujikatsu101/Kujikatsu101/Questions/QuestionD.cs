using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu101.Algorithms;
using Kujikatsu101.Collections;
using Kujikatsu101.Numerics;
using Kujikatsu101.Questions;

namespace Kujikatsu101.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadLong();
            var x = io.ReadInt();
            var m = io.ReadInt();

            var nexts = new int[m + 1];
            var sum = new long[m + 1];
            long result = 0;

            for (int i = 0; i < nexts.Length; i++)
            {
                nexts[i] = F(i);
                sum[i] = i;
            }

            while (n > 0)
            {
                if ((n & 1) > 0)
                {
                    result += sum[x];
                    x = nexts[x];
                }

                var nexnex = new int[m + 1];
                var sumNext = new long[m + 1];

                for (int i = 0; i < nexnex.Length; i++)
                {
                    nexnex[i] = nexts[nexts[i]];
                    sumNext[i] = sum[i] + sum[nexts[i]];
                }

                nexts = nexnex;
                sum = sumNext;

                n >>= 1;
            }

            io.WriteLine(result);

            int F(int x) => (int)((long)x * x % m);
        }
    }
}
