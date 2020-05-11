using Yorukatsu037.Questions;
using Yorukatsu037.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu037.Questions
{
    /// <summary>
    /// ABC131 C
    /// </summary>
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abcd = inputStream.ReadLongArray();
            var a = abcd[0];
            var b = abcd[1];
            var c = abcd[2];
            var d = abcd[3];
            var lcm = Lcm(c, d);

            var cDiv = b / c - (a - 1) / c;
            var dDiv = b / d - (a - 1) / d;
            var cdDiv = b / lcm - (a - 1) / lcm;

            yield return b - (a - 1) - (cDiv + dDiv) + cdDiv;
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
