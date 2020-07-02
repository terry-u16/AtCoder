using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu018.Algorithms;
using Kujikatsu018.Collections;
using Kujikatsu018.Extensions;
using Kujikatsu018.Numerics;
using Kujikatsu018.Questions;

namespace Kujikatsu018.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc024/tasks/agc024_c
    /// </summary>
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = new int[n];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = inputStream.ReadInt();
            }

            if (a[0] > 0)
            {
                yield return -1;
                yield break;
            }

            long sum = 0;
            var current = 0;
            foreach (var ai in a.Reverse())
            {
                if (current - 1 > ai)
                {
                    yield return -1;
                    yield break;
                }
                else if (current - 1 < ai)
                {
                    sum += ai;
                    current = ai;
                }
                current = ai;
            }

            yield return sum;
        }
    }
}
