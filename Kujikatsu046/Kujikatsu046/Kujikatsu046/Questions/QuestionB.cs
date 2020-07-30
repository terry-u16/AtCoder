using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu046.Algorithms;
using Kujikatsu046.Collections;
using Kujikatsu046.Extensions;
using Kujikatsu046.Numerics;
using Kujikatsu046.Questions;

namespace Kujikatsu046.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc162/tasks/abc162_c
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();
            long sum = 0;
            for (int a = 1; a <= k; a++)
            {
                for (int b = 1; b <= k; b++)
                {
                    for (int c = 1; c <= k; c++)
                    {
                        sum += NumericalAlgorithms.Gcd(a, NumericalAlgorithms.Gcd(b, c));
                    }
                }
            }

            yield return sum;
        }
    }
}
