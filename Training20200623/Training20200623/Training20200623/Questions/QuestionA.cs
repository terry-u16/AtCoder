using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Training20200623.Algorithms;
using Training20200623.Collections;
using Training20200623.Extensions;
using Training20200623.Numerics;
using Training20200623.Questions;

namespace Training20200623.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/agc003/tasks/agc003_c
    /// </summary>
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = new int[n];
            var sorted = new int[n];
            for (int i = 0; i < n; i++)
            {
                var ai = inputStream.ReadInt();
                a[i] = ai;
                sorted[i] = ai;
            }

            Array.Sort(sorted);

            var count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                var sortedIndex = sorted.AsSpan().BinarySearch(a[i]);
                if (Math.Abs(i - sortedIndex) % 2 == 1)
                {
                    count++;
                }
            }

            yield return count / 2;
        }
    }
}
