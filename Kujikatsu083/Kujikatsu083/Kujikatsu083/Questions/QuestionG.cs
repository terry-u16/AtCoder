using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu083.Algorithms;
using Kujikatsu083.Collections;
using Kujikatsu083.Extensions;
using Kujikatsu083.Numerics;
using Kujikatsu083.Questions;

namespace Kujikatsu083.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc071/tasks/arc071_c
    /// </summary>
    public class QuestionG : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (_, steps) = inputStream.ReadValue<int, int>();
            var plans = inputStream.ReadIntArray().Select(i => i - 1).ToArray();

            var delta = new long[steps];
            var needed = 0L;    // 初期

            for (int i = 0; i + 1 < plans.Length; i++)
            {
                var start = plans[i];
                var goal = plans[i + 1];
                if (goal < start)
                {
                    goal += steps;
                }

                var normalDiff = goal - start;
                var beginDecrease = start + 2;
                if (beginDecrease <= goal)
                {
                    delta[beginDecrease % steps] -= 1;

                    delta[(goal + 1) % steps] += normalDiff;
                    if ((goal + 2) % steps != 0)
                    {
                        delta[(goal + 2) % steps] -= normalDiff - 1;
                    }

                    if (beginDecrease < steps && steps <= goal || (goal + 1) % steps == 0)
                    {
                        // 初期Δ
                        delta[0] -= 1;
                    }
                }

                needed += Math.Min(normalDiff, goal % steps + 1);
            }

            var min = needed;
            var currentDelta = delta[0];

            for (int i = 1; i < delta.Length; i++)
            {
                currentDelta += delta[i];
                needed += currentDelta;
                min = Math.Min(min, needed);
            }

            yield return min;
        }
    }
}
