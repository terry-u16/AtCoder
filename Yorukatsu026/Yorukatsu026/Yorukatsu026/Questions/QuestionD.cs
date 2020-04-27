using Yorukatsu026.Questions;
using Yorukatsu026.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu026.Questions
{
    /// <summary>
    /// ABC121 D
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadLongArray();
            long a = ab[0];
            long b = ab[1];

            var maxDigit = GetMaxDigitOfTwo(b);
            long answer = 0L;

            for (int digit = maxDigit; digit >= 1; digit--)
            {
                answer <<= 1;
                answer += GetDigitOneCountIsEven(a, b, digit) ? 0 : 1;
            }

            yield return answer;
        }

        bool GetDigitOneCountIsEven(long begin, long end, int digit)
        {
            end += 1;   // [a,b)で考える
            if (digit == 1)
            {
                var beginMod = begin % 4;
                var endMod = end % 4;
                endMod += 4;

                var count = 0;
                if (endMod > 1 && beginMod <= 1)
                {
                    count++;
                }
                if (endMod > 3 && beginMod <= 3)
                {
                    count++;
                }
                if (endMod > 5)
                {
                    count++;
                }
                return count % 2 == 0;
            }
            else
            {
                var beginMod = begin % (1L << digit);
                var endMod = end % (1L << digit);

                endMod += 1L << digit;

                var countOneLeft = Math.Min(endMod, (1L << digit)) - Math.Max(beginMod, 1L << (digit - 1));
                var oneHarf = (1L << digit) + (1L << (digit - 1));
                var countOneRight = Math.Max(endMod, oneHarf) - Math.Max(beginMod, oneHarf);
                var countOne = countOneLeft + countOneRight;

                return countOne % 2 == 0;
            }
        }
        
        int GetMaxDigitOfTwo(long n)
        {
            var digit = 0;
            while (n > 0)
            {
                digit++;
                n >>= 1;
            }
            return digit;
        }
    }
}
