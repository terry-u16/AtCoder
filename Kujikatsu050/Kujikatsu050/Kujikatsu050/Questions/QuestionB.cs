using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu050.Algorithms;
using Kujikatsu050.Collections;
using Kujikatsu050.Extensions;
using Kujikatsu050.Numerics;
using Kujikatsu050.Questions;

namespace Kujikatsu050.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc161/tasks/abc161_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (n, toSelect) = inputStream.ReadValue<int, int>();
            var a = inputStream.ReadIntArray();
            Array.Sort(a);
            Array.Reverse(a);
            if (a[toSelect - 1] * 4 * toSelect >= a.Sum())
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }
    }
}
