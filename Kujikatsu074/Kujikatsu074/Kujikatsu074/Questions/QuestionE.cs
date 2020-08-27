using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu074.Algorithms;
using Kujikatsu074.Collections;
using Kujikatsu074.Extensions;
using Kujikatsu074.Numerics;
using Kujikatsu074.Questions;

namespace Kujikatsu074.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2016-qualc/tasks/codefestival_2016_qualC_c
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var t = inputStream.ReadIntArray();
            var a = inputStream.ReadIntArray();

            t = new[] { 0 }.Concat(t).Concat(new[] { t[^1] }).ToArray();
            a = new[] { a[0] }.Concat(a).Concat(new[] { 0 }).ToArray();

            var dp = Modular.One;
            var getHighest = false;

            for (int i = 1; i <= n; i++)
            {
                var takUpdated = t[i - 1] < t[i];
                var aoUpdated = a[i] > a[i + 1];

                if (takUpdated && aoUpdated)
                {
                    if (t[i] == a[i])
                    {
                        dp *= 1;
                        getHighest = true;
                    }
                    else
                    {
                        dp *= 0;
                    }
                }
                else if (takUpdated)
                {
                    if (getHighest)
                    {
                        dp *= 0;
                    }
                    else if (t[i] == a[i])
                    {
                        getHighest = true;
                    }
                }
                else if (aoUpdated)
                {
                    if (!getHighest)
                    {
                        dp *= 0;
                    }
                    else if (t[i] == a[i])
                    {
                        getHighest = true;
                    }
                }
                else
                {
                    dp *= Math.Min(t[i], a[i]);
                }
            }

            yield return dp;
        }
    }
}
