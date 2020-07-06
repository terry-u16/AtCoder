using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200706.Algorithms;
using Training20200706.Collections;
using Training20200706.Extensions;
using Training20200706.Numerics;
using Training20200706.Questions;

namespace Training20200706.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/joi2011yo/tasks/joi2011yo_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            yield return GetCount(a.AsSpan()[..^1], a[^1]);
        }

        long GetCount(Span<int> a, int result)
        {
            const int max = 20;
            var counts = new long[a.Length, max + 1];
            counts[0, a[0]] = 1;

            Span<int> signs = stackalloc int[] { -1, 1 };

            for (int i = 1; i < a.Length; i++)
            {
                for (int current = 0; current <= max; current++)
                {
                    foreach (var sign in signs)
                    {
                        var next = current + sign * a[i];
                        if (unchecked((uint)next) <= max)
                        {
                            counts[i, next] += counts[i - 1, current];
                        }
                    }
                }
            }

            return counts[a.Length - 1, result];
        }
    }
}
