using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu012.Algorithms;
using Kujikatsu012.Collections;
using Kujikatsu012.Extensions;
using Kujikatsu012.Numerics;
using Kujikatsu012.Questions;

namespace Kujikatsu012.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc091/tasks/arc091_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, a, b) = inputStream.ReadValue<int, int, int>();
            if (a + b > n + 1 || (n + a - 1) / a > b)
            {
                yield return -1;
            }
            else
            {
                var queue = new Queue<int>();
                var used = 0;
                var usedMin = n + 1;
                int repeated;

                for (repeated = 1; true; repeated++)
                {
                    if (n - repeated * a < Math.Max(b - repeated, 1))
                    {
                        break;
                    }

                    var start = n - repeated * a + 1;
                    usedMin = start;
                    used += a;

                    foreach (var value in Enumerable.Range(start, a))
                    {
                        queue.Enqueue(value);
                    }
                }

                repeated--;

                var extra = n - used - (b - repeated);
                if (extra > 0)
                {
                    usedMin = usedMin - extra - 1;
                    foreach (var value in Enumerable.Range(usedMin, extra + 1))
                    {
                        queue.Enqueue(value);
                    }
                }

                for (int i = usedMin - 1; i > 0; i--)
                {
                    queue.Enqueue(i);
                }

                yield return string.Join(" ", queue);
            }
        }
    }
}
