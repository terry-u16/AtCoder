using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu009.Algorithms;
using Kujikatsu009.Collections;
using Kujikatsu009.Extensions;
using Kujikatsu009.Numerics;
using Kujikatsu009.Questions;

namespace Kujikatsu009.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc029/tasks/agc029_b
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var counter = new Counter<int>();

            foreach (var ai in a)
            {
                counter[ai]++;
            }

            long pairs = 0;

            foreach (var me in a.OrderByDescending(i => i).Distinct())
            {
                var another = GetAnother(me);
                if (me == another)
                {
                    pairs += counter[me] / 2;
                }
                else
                {
                    var min = Math.Min(counter[me], counter[another]);
                    pairs += min;
                    counter[another] -= min;
                }
            }

            yield return pairs;
        }

        int GetAnother(int n)
        {
            var another = 1;
            while (another <= n)
            {
                another <<= 1;
            }
            return another - n;
        }
    }
}
