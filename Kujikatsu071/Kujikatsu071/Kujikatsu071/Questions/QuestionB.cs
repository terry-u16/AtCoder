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
    /// https://atcoder.jp/contests/abc142/tasks/abc142_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var orders = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                orders[a[i] - 1] = i + 1;
            }

            yield return orders.Join(' ');
        }
    }
}
