using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nomura2020.Algorithms;
using Nomura2020.Collections;
using Nomura2020.Extensions;
using Nomura2020.Numerics;
using Nomura2020.Questions;

namespace Nomura2020.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            var (min, max) = GetMinMax(a);
            yield return Count(a, min, max);
        }

        (long[] min, long[] max) GetMinMax(int[] a)
        {
            var min = new long[a.Length];
            var max = new long[a.Length];
            min[^1] = a[^1];
            max[^1] = a[^1];

            for (int depth = a.Length - 2; depth >= 0; depth--)
            {
                min[depth] = (min[depth + 1] + 1) / 2 + a[depth];
                max[depth] = max[depth + 1] + a[depth];
            }

            return (min, max);
        }

        long Count(int[] a, long[] min, long[] max)
        {
            var count = new long[a.Length];

            if (min[0] > 1)
            {
                return -1;
            }

            long total = 1;
            long before = 1;
            for (int depth = 1; depth < a.Length; depth++)
            {
                var available = (before - a[depth - 1]) * 2;
                if (available < min[depth])
                {
                    return -1;
                }

                before = Math.Min(max[depth], available);
                total += before;
            }

            return total;
        }
    }
}
