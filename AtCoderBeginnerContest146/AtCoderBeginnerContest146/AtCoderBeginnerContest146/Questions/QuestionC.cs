using AtCoderBeginnerContest146.Questions;
using AtCoderBeginnerContest146.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Net.Mail;

namespace AtCoderBeginnerContest146.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abx = inputStream.ReadLongArray();
            var a = abx[0];
            var b = abx[1];
            var x = abx[2];
            const int largestInteger = 1000000000;

            var max = 0;
            for (int digit = 1; digit < 10; digit++)
            {
                max = Math.Max(max, GetAvailableLargestInteger(a, b, digit, x));
            }

            // 10^9
            if (a * largestInteger + b * D(largestInteger) <= x)
            {
                max = largestInteger;
            }

            yield return max;
        }

        private int GetAvailableLargestInteger(long a, long b, int digit, long money) => (int)Math.Min((money - (b * digit)) / a, GetLargestIntegerOf(digit));

        private int GetLargestIntegerOf(int digit)
        {
            var result = 1;
            for (int i = 0; i < digit; i++)
            {
                result *= 10;
            }
            return result - 1;
        }

        private int D(long n)
        {
            var digit = 1;
            while (n >= 10)
            {
                digit++;
                n /= 10;
            }
            return digit;
        }
    }
}
