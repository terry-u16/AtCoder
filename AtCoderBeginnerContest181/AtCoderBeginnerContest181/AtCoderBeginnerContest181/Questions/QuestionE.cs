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
    public class QuestionE : AtCoderQuestionBase
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public override void Solve(IOManager io)
        {
            var n = io.ReadInt();
            var m = io.ReadInt();

            var children = io.ReadIntArray(n);
            var mines = io.ReadIntArray(m);

            children.Sort();
            mines.Sort();

            var evens = new long[n / 2 + 1];
            var odds = new long[n / 2 + 1];

            for (int i = 0; i + 1 < evens.Length; i++)
            {
                var even = children[i * 2 + 1] - children[i * 2];
                var odd = children[i * 2 + 2] - children[i * 2 + 1];

                evens[i + 1] = evens[i] + even;
                odds[i + 1] = odds[i] + odd;
            }

            long min = long.MaxValue;

            foreach (var mine in mines)
            {
                var index = SearchExtensions.GetGreaterThanIndex(children, mine);
                long sum = 0;

                if (index % 2 == 0)
                {
                    sum += Math.Abs(mine - children[index]);
                    index /= 2;
                    index++;
                    sum += evens[index - 1] + odds[^1] - odds[index - 1];
                }
                else
                {
                    sum += Math.Abs(mine - children[index - 1]);
                    index /= 2;
                    index++;
                    sum += evens[index - 1] + odds[^1] - odds[index - 1];
                }

                min.ChangeMin(sum);
            }

            io.WriteLine(min);
        }
    }
}
