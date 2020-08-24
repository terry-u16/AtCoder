using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu071.Algorithms;
using Kujikatsu071.Collections;
using Kujikatsu071.Extensions;
using Kujikatsu071.Numerics;
using Kujikatsu071.Questions;

namespace Kujikatsu071.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc011/tasks/agc011_b
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadLongArray();
            Array.Sort(a);
            long size = a[0];
            int color = 1;

            for (int i = 0; i + 1 < a.Length; i++)
            {
                if (size * 2 >= a[i + 1] )
                {
                    color++;
                }
                else
                {
                    color = 1;
                }

                size += a[i + 1];
            }

            yield return color;
        }
    }
}
