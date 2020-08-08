using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu055.Algorithms;
using Kujikatsu055.Collections;
using Kujikatsu055.Extensions;
using Kujikatsu055.Numerics;
using Kujikatsu055.Questions;

namespace Kujikatsu055.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/aising2020/tasks/aising2020_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var counts = new int[n + 1];

            for (int x = 1; x <= 100; x++)
            {
                for (int y = 1; y <= 100; y++)
                {
                    for (int z = 1; z <= 100; z++)
                    {
                        var g = x * x + y * y + z * z + x * y + y * z + z * x;
                        if (g <= n)
                        {
                            counts[g]++;
                        }
                    }
                }
            }

            for (int i = 1; i < counts.Length; i++)
            {
                yield return counts[i];
            }
        }
    }
}
