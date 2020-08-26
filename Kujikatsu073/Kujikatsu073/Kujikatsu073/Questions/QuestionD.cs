using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu073.Algorithms;
using Kujikatsu073.Collections;
using Kujikatsu073.Extensions;
using Kujikatsu073.Numerics;
using Kujikatsu073.Questions;

namespace Kujikatsu073.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc085/tasks/abc085_d
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, hp) = inputStream.ReadValue<int, int>();
            var normalAttack = 0;
            var throwAttacks = new int[n];
            for (int i = 0; i < throwAttacks.Length; i++)
            {
                var (a, b) = inputStream.ReadValue<int, int>();
                normalAttack = Math.Max(normalAttack, a);
                throwAttacks[i] = b;
            }

            Array.Sort(throwAttacks, (a, b) => b - a);
            var prefixSum = new long[n + 1];
            for (int i = 0; i < throwAttacks.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + throwAttacks[i];
            }

            var minAttacks = long.MaxValue;

            for (int i = 0; i < prefixSum.Length; i++)
            {
                long attacks = i;
                var currentHp = hp - prefixSum[i];

                if (currentHp > 0)
                {
                    attacks += (currentHp + normalAttack - 1) / normalAttack;
                }

                minAttacks = Math.Min(minAttacks, attacks);
            }

            yield return minAttacks;
        }
    }
}
