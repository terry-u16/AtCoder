using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AtCoderBeginnerContest161.Extensions;

namespace AtCoderBeginnerContest161.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<string> Solve(TextReader inputStream)
        {
            var k = inputStream.ReadInt();

            long lunlun = 0;
            for (int i = 0; i < k; i++)
            {
                lunlun = GetNextLunlunNumber(lunlun);
            }

            yield return lunlun.ToString();
        }

        long GetNextLunlunNumber(long lunlunNumber)
        {
            var incrementedDigit = GetNextIncrementedDigit(lunlunNumber);
            var pow = (long)Math.Pow(10, incrementedDigit);
            var nextLunlunNumber = (lunlunNumber / pow + 1) * pow;
            var previous = (nextLunlunNumber / pow) % 10;

            for (long digit = incrementedDigit - 1; digit >= 0; digit--)
            {
                var current = Math.Max(previous - 1, 0);
                nextLunlunNumber += current * (long)Math.Pow(10, digit);
                previous = current;
            }

            return nextLunlunNumber;
        }

        long GetNextIncrementedDigit(long lunlunNumber)
        {
            var digit = 0;

            if (lunlunNumber < 10)
            {
                return digit;
            }

            var n = lunlunNumber;
            var previous = n % 10;
            n /= 10;

            while (n != 0)
            {
                var current = n % 10;

                if (previous <= current && previous != 9)
                {
                    return digit;
                }

                n /= 10;
                digit++;
                previous = current;
            }

            return digit;
        }
    }
}
