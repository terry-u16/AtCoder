using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu052.Algorithms;
using Kujikatsu052.Collections;
using Kujikatsu052.Extensions;
using Kujikatsu052.Numerics;
using Kujikatsu052.Questions;

namespace Kujikatsu052.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc170/tasks/abc170_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var (x, n) = inputStream.ReadValue<int, int>();
            var pString = inputStream.ReadLine();

            if (string.IsNullOrEmpty(pString))
            {
                yield return x;
                yield break;
            }

            var p = pString.Split(' ').Select(int.Parse).ToArray();
            Array.Sort(p);

            var minDiff = int.MaxValue;
            var result = -1;
            
            for (int i = 0; i <= 101; i++)
            {
                if (!p.Any(pi => pi == i) && Math.Abs(i - x) < minDiff)
                {
                    minDiff = Math.Abs(i - x);
                    result = i;
                }
            }

            yield return result;
        }
    }
}
