using Yorukatsu036.Questions;
using Yorukatsu036.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu036.Questions
{
    /// <summary>
    /// ABC045 C
    /// </summary>
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();

            long sum = 0;

            for (int flag = 0; flag < 1 << (s.Length - 1); flag++)
            {
                long partialSum = 0;
                long buffer = s[0] - '0';
                for (int digit = 1; digit < s.Length; digit++)
                {
                    if ((flag & (1 << digit - 1)) > 0)
                    {
                        buffer *= 10;
                        buffer += s[digit] - '0';
                    }
                    else
                    {
                        partialSum += buffer;
                        buffer = s[digit] - '0';
                    }
                }
                partialSum += buffer;
                sum += partialSum;
            }

            yield return sum;
        }
    }
}
