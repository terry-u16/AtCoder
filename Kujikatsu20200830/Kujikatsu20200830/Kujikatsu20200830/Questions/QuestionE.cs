using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu20200830.Algorithms;
using Kujikatsu20200830.Collections;
using Kujikatsu20200830.Extensions;
using Kujikatsu20200830.Numerics;
using Kujikatsu20200830.Questions;

namespace Kujikatsu20200830.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/aising2020/tasks/aising2020_d
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var x = inputStream.ReadLine().Select(c => c == '1').ToArray();

            var initialPopcount = x.Count(c => c);
            var plusOne = initialPopcount + 1;
            var minusOne = initialPopcount - 1;

            var plusMods = new int[x.Length];
            var minusMods = new int[x.Length];
            var basePlus = 0;
            var baseMinus = 0;
            var powBasePlus = 1;
            var powBaseMinus = 1;

            for (int i = x.Length - 1; i >= 0; i--)
            {
                plusMods[i] = ((x[i] ? 0 : 1) * powBasePlus + basePlus) % plusOne;
                basePlus = ((x[i] ? 1 : 0) * powBasePlus + basePlus) % plusOne;
                powBasePlus = (powBasePlus << 1) % plusOne;
                if (minusOne != 0)
                {
                    minusMods[i] = ((x[i] ? 0 : 1) * powBaseMinus + baseMinus) % minusOne;
                    baseMinus = ((x[i] ? 1 : 0) * powBaseMinus + baseMinus) % minusOne;
                    powBaseMinus = (powBaseMinus << 1) % minusOne;
                }
            }

            for (int i = 0; i < x.Length; i++)
            {
                if (!x[i])
                {
                    yield return F(plusMods[i]) + 1;
                }
                else
                {
                    yield return F(minusMods[i]) + 1;
                }
            }
        }

        int F(int n)
        {
            var count = 0;
            while (n > 0)
            {
                count++;
                n %= PopCount(n);
            }
            return count;
        }

        int PopCount(int n)
        {
            var count = 0;
            while (n > 0)
            {
                if ((n & 1) > 0)
                {
                    count++;
                }
                n >>= 1;
            }
            return count;
        }
    }
}
