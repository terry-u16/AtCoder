using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu038.Algorithms;
using Kujikatsu038.Collections;
using Kujikatsu038.Extensions;
using Kujikatsu038.Numerics;
using Kujikatsu038.Questions;

namespace Kujikatsu038.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/cf16-final/tasks/codefestival_2016_final_d
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (cardCount, m) = inputStream.ReadValue<int, int>();
            var cards = inputStream.ReadIntArray();
            var mods = new int[m];
            var counts = new int[100001];

            foreach (var card in cards)
            {
                mods[card % m]++;
                counts[card]++;
            }

            int pairs = mods[0] / 2;
            mods[0] -= pairs * 2;

            for (int i = 1; i < mods.Length; i++)
            {
                var newPairs = Math.Min(mods[i], mods[m - i]);
                if (i == m - i)
                {
                    newPairs /= 2;
                }
                mods[i] -= newPairs;
                mods[m - i] -= newPairs;
                pairs += newPairs;
            }

            for (int i = 1; i < counts.Length; i++)
            {
                var newPairs = Math.Min(counts[i] / 2, mods[i % m] / 2);
                pairs += newPairs;
                mods[i % m] -= newPairs * 2;
            }

            yield return pairs;
        }
    }
}
