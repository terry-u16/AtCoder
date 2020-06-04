using Yorukatsu056.Questions;
using Yorukatsu056.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu056.Questions
{
    /// <summary>
    /// https://atcoder.jp/contests/abc109/tasks/abc109_c
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nx = inputStream.ReadIntArray();
            var start = nx[1];
            var x = inputStream.ReadIntArray().Concat(new[] { start }).ToArray();
            Array.Sort(x);

            long gcd = x[1] - x[0];

            for (int i = 1; i + 1 < x.Length; i++)
            {
                gcd = Gcd(gcd, x[i + 1] - x[i]);
            }

            yield return gcd;
        }

        public static long Gcd(long a, long b)
        {
            if (a <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(b)}は正の整数である必要があります。");
            }
            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)}は正の整数である必要があります。");
            }
            if (a < b)
            {
                var temp = a;
                a = b;
                b = temp;
            }

            while (b != 0)
            {
                var temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        public static long Lcm(long a, long b)
        {
            if (a <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a), $"{nameof(b)}は正の整数である必要があります。");
            }
            if (b <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(b), $"{nameof(b)}は正の整数である必要があります。");
            }

            return a / Gcd(a, b) * b;
        }

    }
}
