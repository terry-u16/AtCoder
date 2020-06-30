using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu016.Algorithms;
using Kujikatsu016.Collections;
using Kujikatsu016.Extensions;
using Kujikatsu016.Numerics;
using Kujikatsu016.Questions;

namespace Kujikatsu016.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc135/tasks/abc135_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var p = inputStream.ReadIntArray();
            var count = 0;

            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] != i + 1)
                {
                    count++;
                }
            }

            yield return count == 0 || count == 2 ? "YES" : "NO";
        }
    }
}
