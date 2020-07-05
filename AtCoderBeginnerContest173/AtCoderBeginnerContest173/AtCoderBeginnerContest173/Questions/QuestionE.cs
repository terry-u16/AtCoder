using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AtCoderBeginnerContest173.Algorithms;
using AtCoderBeginnerContest173.Collections;
using AtCoderBeginnerContest173.Extensions;
using AtCoderBeginnerContest173.Numerics;
using AtCoderBeginnerContest173.Questions;

namespace AtCoderBeginnerContest173.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, k) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadLongArray();

            var minus = a.Where(ai => ai < 0).ToList();
            var zero = a.Where(ai => ai == 0).ToList();
            var plus = a.Where(ai => ai > 0).ToList();

            minus.Sort();
            plus.Sort();

            if ((k % 2 == 0 && plus.Count + minus.Count / 2 * 2 >= k) ||
                (k % 2 == 1 && (plus.Count > 0 && plus.Count - 1 + minus.Count / 2 * 2 >= k - 1)))
            {
                Modular result;

                if (k % 2 == 0)
                {
                    result = Modular.One;
                }
                else
                {
                    result = plus[^1];
                    plus.RemoveAt(plus.Count - 1);
                }

                var minusPair = new long[minus.Count / 2];
                var plusPair = new long[plus.Count / 2];

                for (int i = 0; i < minusPair.Length; i++)
                {
                    minusPair[i] = minus[2 * i] * minus[2 * i + 1];
                }

                var offset = plus.Count % 2;
                for (int i = 0; i < plusPair.Length; i++)
                {
                    plusPair[i] = plus[offset + 2 * i] * plus[offset + 2 * i + 1];
                }

                var queue = new PriorityQueue<long>(true);
                foreach (var m in minusPair)
                {
                    queue.Enqueue(m);
                }
                foreach (var p in plusPair)
                {
                    queue.Enqueue(p);
                }

                for (int i = 0; i < k / 2; i++)
                {
                    result *= queue.Dequeue();
                }

                yield return result.Value;
            }
            else if (zero.Count > 0)
            {
                yield return 0;
                yield break;
            }
            else
            {
                var queue = new PriorityQueue<long>(false);
                foreach (var m in minus)
                {
                    queue.Enqueue(-m);
                }
                foreach (var p in plus)
                {
                    queue.Enqueue(p);
                }

                var result = Modular.One;

                for (int i = 0; i < k; i++)
                {
                    result *= queue.Dequeue();
                }

                yield return (Modular.Zero - result).Value;
            }
        }
    }
}
