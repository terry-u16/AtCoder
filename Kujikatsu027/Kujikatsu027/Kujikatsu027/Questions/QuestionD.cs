using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu027.Algorithms;
using Kujikatsu027.Collections;
using Kujikatsu027.Extensions;
using Kujikatsu027.Numerics;
using Kujikatsu027.Questions;

namespace Kujikatsu027.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/arc079/tasks/arc079_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();

            long total = 0;

            while (true)
            {
                var selectedIndex = -1;
                long max = n - 1;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > max)
                    {
                        max = a[i];
                        selectedIndex = i;
                    }
                }

                if (selectedIndex == -1)
                {
                    break;
                }
                else
                {
                    var div = a[selectedIndex] / n;
                    total += div;
                    a[selectedIndex] %= n;
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (i != selectedIndex)
                        {
                            a[i] += div;
                        }
                    }
                }
            }

            yield return total;
        }
    }
}
