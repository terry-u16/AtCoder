using Kujikatsu003.Questions;
using Kujikatsu003.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Kujikatsu003.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc083/tasks/abc083_b
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nab = inputStream.ReadIntArray();
            var n = nab[0];
            var a = nab[1];
            var b = nab[2];

            yield return Enumerable.Range(1, n).Where(i =>
            {
                var digitSum = GetDigitSum(i);
                return a <= digitSum && digitSum <= b;
            }).Sum();
        }

        int GetDigitSum(int n)
        {
            var sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
    }
}
