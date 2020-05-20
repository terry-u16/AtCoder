using Yorukatsu044.Questions;
using Yorukatsu044.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu044.Questions
{
    /// <summary>
    /// ARC075 E
    /// </summary>
    public class QuestionF : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];
            var a = new Fraction[n, 3];

            for (int i = 0; i < n; i++)
            {
                a[i, 0] = new Fraction(inputStream.ReadLong(), 1);
            }

            long count = 0;

            for (int i = 0; i + 1 < n; i++)
            {

            }
        }

        struct Fraction
        {
            public long Numerator { get; }
            public long Denominator { get; }

            public Fraction(long numerator, long denominator)
            {
                var gcd = Gcd(numerator, denominator);
                Numerator = numerator / gcd;
                Denominator = denominator / gcd;
            }

            public static Fraction operator+(Fraction a, Fraction b)
            {
                var numerator = a.Numerator * b.Denominator + a.Denominator * b.Numerator;
                var denominator = a.Denominator * b.Denominator;
                return new Fraction(numerator, denominator);
            }

            public static Fraction operator*(Fraction a, int b)
            {
                return new Fraction(a.Numerator * b, a.Denominator);
            }

            public static bool operator>=(Fraction a, long b)
            {
                b *= a.Denominator;
                return a.Numerator >= b;
            }

            public static bool operator <=(Fraction a, long b)
            {
                b *= a.Denominator;
                return a.Numerator <= b;
            }

            private static long Gcd(long a, long b)
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

        }
    }
}
