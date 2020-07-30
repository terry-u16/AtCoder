using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu046.Algorithms;
using Kujikatsu046.Collections;
using Kujikatsu046.Extensions;
using Kujikatsu046.Numerics;
using Kujikatsu046.Questions;

namespace Kujikatsu046.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/keyence2020/tasks/keyence2020_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var ab = new[] { inputStream.ReadIntArray(), inputStream.ReadIntArray() };

            long min = long.MaxValue;
            bool ok = false;
            for (var flip = BitSet.Zero; flip < (1 << n); flip++)
            {
                var result = Check(n, ab, flip);
                if (result != -1)
                {
                    ok = true;
                    min = Math.Min(min, result);
                }
            }

            if (ok)
            {
                yield return min;
            }
            else
            {
                yield return -1;
            }
        }

        long Check(int n, int[][] ab, BitSet flip)
        {
            if (flip.Count() % 2 != 0)
            {
                return -1;
            }

            var odds = new List<int>();
            var evens = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (flip[i] ^ ((i & 1) == 1))
                {
                    evens.Add(ab[flip[i] ? 1 : 0][i]);
                }
                else
                {
                    odds.Add(ab[flip[i] ? 1 : 0][i]);
                }
            }

            odds.Sort();
            evens.Sort();

            var current = odds[0];
            for (int i = 1; i < n; i++)
            {
                int next = i % 2 == 0 ? odds[i >> 1] : evens[i >> 1];
                if (current > next)
                {
                    return -1;
                }                
            }

            long count = 0;
            var bit = new BinaryIndexedTree(51);
            for (int i = 0; i < n; i++)
            {
                var next = ab[flip[i] ? 1 : 0][i];
                count += bit.Sum((next + 1)..);
                bit[next]++;
            }

            return count;
        }
    }
}
