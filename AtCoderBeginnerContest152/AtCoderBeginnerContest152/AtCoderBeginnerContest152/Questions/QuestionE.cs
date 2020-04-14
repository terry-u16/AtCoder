using AtCoderBeginnerContest152.Questions;
using AtCoderBeginnerContest152.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest152.Questions
{
    public class QuestionE : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            Modular lcm = new Modular(1);
            for (int i = 1; i < a.Length; i++)
            {
                lcm = new Modular(Lcm(lcm.Value, a[i]));
            }

            var sum = new Modular(0);
            foreach (var v in a)
            {
                sum += lcm / new Modular(v);
            }

            yield return sum.Value;
        }

        public static long Gcd(int a, int b)
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

        public static long Lcm(int a, int b)
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
