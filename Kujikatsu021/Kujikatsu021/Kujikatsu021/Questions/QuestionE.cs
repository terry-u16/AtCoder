using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu021.Algorithms;
using Kujikatsu021.Collections;
using Kujikatsu021.Extensions;
using Kujikatsu021.Numerics;
using Kujikatsu021.Questions;

namespace Kujikatsu021.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/nomura2020/tasks/nomura2020_c
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            if (n == 0)
            {
                if (a[0] == 1)
                {
                    yield return 1;
                }
                else
                {
                    yield return -1;
                }
                yield break;
            }

            var min = new long[a.Length];
            var max = new long[a.Length];

            min[^1] = a[^1];
            max[^1] = a[^1];

            for (int i = a.Length - 2; i >= 0; i--)
            {
                min[i] = (min[i + 1] + 1) / 2 + a[i];
                max[i] = max[i + 1] + a[i];
            }

            long count = 1;
            long current = 1;

            for (int i = 1; i < a.Length; i++)
            {
                var parents = current - a[i - 1];
                if (parents * 2 < min[i])
                {
                    yield return -1;
                    yield break;
                }

                current = Math.Min(max[i], parents * 2);
                count += current;
            }

            yield return count;
        }
    }
}
