using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu035.Algorithms;
using Kujikatsu035.Collections;
using Kujikatsu035.Extensions;
using Kujikatsu035.Numerics;
using Kujikatsu035.Questions;

namespace Kujikatsu035.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/code-festival-2017-qualc/tasks/code_festival_2017_qualc_c
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var noX = s.Replace("x", "");

            for (int i = 0; i < (noX.Length >> 1); i++)
            {
                if (noX[i] != noX[^(i + 1)])
                {
                    yield return -1;
                    yield break;
                }
            }

            var left = 0;
            var right = s.Length - 1;
            var count = 0;

            while (left < right)
            {
                if (s[left] == s[right])
                {
                    left++;
                    right--;
                }
                else if (s[left] == 'x')
                {
                    left++;
                    count++;
                }
                else
                {
                    right--;
                    count++;
                }
            }

            yield return count;
        }
    }
}
