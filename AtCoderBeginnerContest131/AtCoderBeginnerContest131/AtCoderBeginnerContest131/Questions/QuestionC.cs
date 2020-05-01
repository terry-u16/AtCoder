using AtCoderBeginnerContest131.Questions;
using AtCoderBeginnerContest131.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest131.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abcd = inputStream.ReadLongArray();
            var a = abcd[0];
            var b = abcd[1];
            var c = abcd[2];
            var d = abcd[3];

            var count = b - (a - 1) - GetMultipleCountBetween(a, b, c) - GetMultipleCountBetween(a, b, d) + GetMultipleCountBetween(a, b, Lcm(c, d));
            yield return count;
        }

        long GetMultipleCountBetween(long begin, long end, long divisior) => GetMultipleCount(end, divisior) - GetMultipleCount(begin - 1, divisior);

        long GetMultipleCount(long n, long divisior) => n / divisior;

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
