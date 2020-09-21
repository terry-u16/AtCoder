using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200918.Algorithms;
using Training20200918.Collections;
using Training20200918.Extensions;
using Training20200918.Numerics;
using Training20200918.Questions;

namespace Training20200918.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, x, m) = inputStream.ReadValue<long, long, int>();

            long sum = x;
            var i = 1;
            var mods = new List<long>();
            var appeared = new HashSet<long>();
            mods.Add(x);
            appeared.Add(x);

            if (n == 1)
            {
                yield return x;
                yield break;
            }
            else if (x == 0)
            {
                yield return 0;
                yield break;
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
                    yield return sum;
                    yield break;
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

            yield return sum;
            yield break;
        }

        long F(long a, int m) => a * a % m;
    }
}
