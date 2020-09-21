using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest179.Algorithms;
using AtCoderBeginnerContest179.Collections;
using AtCoderBeginnerContest179.Numerics;
using AtCoderBeginnerContest179.Questions;

namespace AtCoderBeginnerContest179.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override void Solve(IOManager io)
        {
            var n = io.ReadLong();
            long x = io.ReadInt();
            var m = io.ReadInt();

            long sum = x;
            var i = 1;
            var mods = new List<long>();
            var appeared = new HashSet<long>();
            mods.Add(x);
            appeared.Add(x);

            if (n == 1)
            {
                io.WriteLine(x);
                return;
            }
            else if (x == 0)
            {
                io.WriteLine(0);
                return;
            }

            while (true)
            {
                var next = F(x, m);

                if (appeared.Add(next))
                {
                    mods.Add(next);
                    i++;
                    x = next;
                    sum += x;
                }
                else
                {
                    break;
                }

                if (i == n)
                {
                    io.WriteLine(sum);
                    return;
                }
            }

            var nx = F(x, m);
            var remain = n - i;
            var lastIndex = -1;

            for (int j = 0; j < mods.Count; j++)
            {
                if (mods[j] == nx)
                {
                    lastIndex = j;
                    break;
                }
            }

            var loop = mods.Count - lastIndex;
            var prefixSum = new long[loop + 1];

            for (int j = 0; j + 1 < prefixSum.Length; j++)
            {
                prefixSum[j + 1] = prefixSum[j] + mods[lastIndex + j];
            }

            sum += prefixSum[^1] * (remain / loop);
            sum += prefixSum[remain % loop];

            io.WriteLine(sum);
        }

        long F(long a, int m) => a * a % m;
    }
}
