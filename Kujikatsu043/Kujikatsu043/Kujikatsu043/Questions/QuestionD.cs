using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu043.Algorithms;
using Kujikatsu043.Collections;
using Kujikatsu043.Extensions;
using Kujikatsu043.Numerics;
using Kujikatsu043.Questions;

namespace Kujikatsu043.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/nikkei2019-2-qual/tasks/nikkei2019_2_qual_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            Modular.Mod = 998244353;
            var n = inputStream.ReadInt();
            var d = inputStream.ReadIntArray();

            if (d[0] != 0)
            {
                yield return 0;
                yield break;
            }
            else
            {
                var counts = new int[n];
                counts[0] = 1;
                for (int i = 1; i < d.Length; i++)
                {
                    if (d[i] == 0)
                    {
                        yield return 0;
                        yield break;
                    }
                    else
                    {
                        counts[d[i]]++;
                    }
                }

                var total = Modular.One;
                var selected = 1;

                for (int distance = 1; distance < counts.Length; distance++)
                {
                    if (counts[distance] == 0)
                    {
                        yield return 0;
                        yield break;
                    }
                    else
                    {
                        total *= Modular.Pow(counts[distance - 1], counts[distance]);
                        selected += counts[distance];
                        if (selected == n)
                        {
                            break;
                        }
                    }
                }

                yield return total;
            }
        }
    }
}
