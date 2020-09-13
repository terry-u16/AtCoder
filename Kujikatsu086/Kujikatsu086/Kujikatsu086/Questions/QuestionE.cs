using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu086.Algorithms;
using Kujikatsu086.Collections;
using Kujikatsu086.Extensions;
using Kujikatsu086.Numerics;
using Kujikatsu086.Questions;

namespace Kujikatsu086.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc123/tasks/abc123_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (oneCake, twoCake, threeCake, k) = inputStream.ReadValue<int, int, int, int>();
            var abc = new Queue<long>[3];

            for (int i = 0; i < abc.Length; i++)
            {
                abc[i] = new Queue<long>(inputStream.ReadLongArray().OrderByDescending(i => i));
                abc[i].Enqueue(long.MinValue);
            }

            var results = new List<long>();
            var selected = Enumerable.Repeat(0, 3).Select(_ => new List<long>()).ToArray();

            results.Add(abc[0].Peek() + abc[1].Peek() + abc[2].Peek());
            for (int i = 0; i < abc.Length; i++)
            {
                selected[i].Add(abc[i].Dequeue());
            }

            while (selected.Aggregate(0, (s, sel) => s * sel.Count) < k)
            {
                var max = long.MinValue;
                var toSelect = -1;
                for (int i = 0; i < abc.Length; i++)
                {
                    if (abc[i].Peek() > max)
                    {
                        max = abc[i].Peek();
                        toSelect = i;
                    }
                }

                var current = abc[toSelect].Dequeue();

                var x = toSelect == 0 ? selected[1] : selected[0];
                var y = toSelect == 2 ? selected[1] : selected[2];

                for (int i = 0; i < x.Count; i++)
                {
                    for (int j = 0; j < y.Count; j++)
                    {
                        results.Add(x[i] + y[j] + current);
                    }
                }

                selected[toSelect].Add(current);
            }

            foreach (var sum in results.OrderByDescending(i => i).Take(k))
            {
                yield return sum;
            }
        }
    }
}
