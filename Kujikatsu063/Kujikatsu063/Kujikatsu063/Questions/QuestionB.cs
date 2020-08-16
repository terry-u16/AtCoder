using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu063.Algorithms;
using Kujikatsu063.Collections;
using Kujikatsu063.Extensions;
using Kujikatsu063.Numerics;
using Kujikatsu063.Questions;

namespace Kujikatsu063.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc068/tasks/abc068_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var maxCount = int.MinValue;
            var result = 0;
            var n = inputStream.ReadInt();

            for (int i = 1; i <= n; i++)
            {
                var divTwo = DivTwo(i);
                if (maxCount < divTwo)
                {
                    maxCount = divTwo;
                    result = i;
                }
            }

            yield return result;
        }

        int DivTwo(int n)
        {
            var count = 0;
            while (n > 0 && ((n & 1) == 0))
            {
                count++;
                n >>= 1;
            }
            return count;
        }
    }
}
