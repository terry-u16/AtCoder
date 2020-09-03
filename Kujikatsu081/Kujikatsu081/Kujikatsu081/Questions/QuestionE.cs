using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu081.Algorithms;
using Kujikatsu081.Collections;
using Kujikatsu081.Extensions;
using Kujikatsu081.Numerics;
using Kujikatsu081.Questions;

namespace Kujikatsu081.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/aising2020/tasks/aising2020_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var x = inputStream.ReadLine();
            var oneCount = x.Count(c => c == '1');

            var mods = GetInvertedMods(x);

            for (int i = 0; i < mods.Length; i++)
            {
                if (oneCount == 1 && x[i] == '1')
                {
                    yield return 0;
                }
                else
                {
                    var current = mods[i];
                    var count = 0;
                    while (current > 0)
                    {
                        current %= PopCount(current);
                        count++;
                    }
                    yield return count + 1;
                }
            }
        }

        int PopCount(int n)
        {
            var count = 0;
            while (n > 0)
            {
                count += n & 1;
                n >>= 1;
            }
            return count;
        }

        int[] GetInvertedMods(string s)
        {
            var popCount = s.Count(c => c == '1');
            var plusCount = popCount + 1;
            var minusCount = popCount > 1 ? popCount - 1 : 1;    // 0除算回避

            var prefixPlusMod = 0;
            var prefixMinusMod = 0;

            var plusBases = new int[s.Length];
            var minusBases = new int[s.Length];
            plusBases[^1] = 1;
            minusBases[^1] = 1;
            prefixPlusMod = s[^1] == '1' ? 1 % plusCount : 0;
            prefixMinusMod = s[^1] == '1' ? 1 % minusCount : 0;

            for (int i = s.Length - 2; i >= 0; i--)
            {
                plusBases[i] = (plusBases[i + 1] << 1) % plusCount;
                minusBases[i] = (minusBases[i + 1] << 1) % minusCount;

                if (s[i] == '1')
                {
                    prefixPlusMod = (prefixPlusMod + plusBases[i]) % plusCount;
                    prefixMinusMod = (prefixMinusMod + minusBases[i]) % minusCount;
                }
            }

            var mods = new int[s.Length];

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == '1')
                {
                    // 1 -> 0
                    mods[i] = (prefixMinusMod - minusBases[i] + minusCount) % minusCount;
                }
                else
                {
                    // 0 -> 1
                    mods[i] = (prefixPlusMod + plusBases[i]) % plusCount;
                }
            }

            return mods;
        }
    }
}
