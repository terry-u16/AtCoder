using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu051.Algorithms;
using Kujikatsu051.Collections;
using Kujikatsu051.Extensions;
using Kujikatsu051.Numerics;
using Kujikatsu051.Questions;

namespace Kujikatsu051.Questions
{

    /// <summary>
    /// https://atcoder.jp/contests/abc111/tasks/arc103_a
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var evens = new Counter<int>();
            var odds = new Counter<int>();

            for (int i = 0; i < a.Length; i++)
            {
                if ((i & 1) == 0)
                {
                    evens[a[i]]++;
                }
                else
                {
                    odds[a[i]]++;
                }
            }

            var e = evens.OrderByDescending(p => p.count).Select(p => (p.key, p.count)).ToArray();
            var o = odds.OrderByDescending(p => p.count).Select(p => (p.key, p.count)).ToArray();

            if (a.All(ai => ai == a[0]))
            {
                yield return a.Length / 2;
            }
            else
            {
                if (e[0].key != o[0].key)
                {
                    yield return a.Length - e[0].count - o[0].count;
                }
                else
                {
                    var min = long.MaxValue;
                    if (e.Length > 1 && e[1].key != o[0].key)
                    {
                        min = Math.Min(min, a.Length - e[1].count - o[0].count);
                    }
                    if (o.Length > 1 && e[0].key != o[1].key)
                    {
                        min = Math.Min(min, a.Length - e[0].count - o[1].count);
                    }
                    yield return min;
                }
            }
        }
    }
}
