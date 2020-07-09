using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu025.Algorithms;
using Kujikatsu025.Collections;
using Kujikatsu025.Extensions;
using Kujikatsu025.Numerics;
using Kujikatsu025.Questions;

namespace Kujikatsu025.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/dwacon5th-prelims/tasks/dwacon5th_prelims_a
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();
            var average = a.Select(ai => (decimal)ai).Average();
            var min = a.Min(ai => Math.Abs(ai - average));

            for (int i = 0; i < a.Length; i++)
            {
                if (Math.Abs(a[i] - average) == min)
                {
                    yield return i;
                    yield break;
                }
            }
        }
    }
}
