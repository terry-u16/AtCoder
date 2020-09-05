using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kujikatsu083.Algorithms;
using Kujikatsu083.Collections;
using Kujikatsu083.Extensions;
using Kujikatsu083.Numerics;
using Kujikatsu083.Questions;

namespace Kujikatsu083.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc174/tasks/abc174_d
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            _ = inputStream.ReadInt();
            var isReds = inputStream.ReadLine().Select(c => c == 'R').ToArray();

            var operations = 0;
            var left = 0;
            var right = isReds.Length - 1;

            Proceed(isReds, ref left, ref right);

            while (left < right)
            {
                (isReds[left], isReds[right]) = (isReds[right], isReds[left]);
                operations++;
                Proceed(isReds, ref left, ref right);
            }

            yield return operations;
        }

        private static void Proceed(bool[] isReds, ref int left, ref int right)
        {
            while (left < isReds.Length && isReds[left])
            {
                left++;
            }

            while (right >= 0 && !isReds[right])
            {
                right--;
            }
        }
    }
}
