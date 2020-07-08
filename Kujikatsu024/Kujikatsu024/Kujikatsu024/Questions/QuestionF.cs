using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu024.Algorithms;
using Kujikatsu024.Collections;
using Kujikatsu024.Extensions;
using Kujikatsu024.Numerics;
using Kujikatsu024.Questions;

namespace Kujikatsu024.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc103/tasks/arc103_c
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var canMake = inputStream.ReadLine().Select(c => c == '1').ToArray();
            var n = canMake.Length;

            if (canMake[^1] || !canMake[0])
            {
                yield return -1;
                yield break;
            }

            for (int i = 0; i < n / 2; i++)
            {
                if (canMake[i] ^ canMake[^(i + 2)])
                {
                    yield return -1;
                    yield break;
                }
            }

            canMake[^1] = true;

            var leaves = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                var node = i + 1;
                if (canMake[i])
                {
                    while (leaves.Count > 0)
                    {
                        var leaf = leaves.Dequeue();
                        yield return $"{leaf} {node}";
                    }
                }

                leaves.Enqueue(node);
            }
        }
    }
}
