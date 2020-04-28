using Yorukatsu027.Questions;
using Yorukatsu027.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yorukatsu027.Questions
{
    /// <summary>
    /// ABC079 C
    /// </summary>
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abcd = inputStream.ReadLine();
            var a = abcd[0] - '0';
            var b = abcd[1] - '0';
            var c = abcd[2] - '0';
            var d = abcd[3] - '0';

            for (int i = 0; i < 1 << 3; i++)
            {
                var sum = a;
                sum += (i & 0x01) > 0 ? b : -b;
                sum += (i & 0x02) > 0 ? c : -c;
                sum += (i & 0x04) > 0 ? d : -d;

                if (sum == 7)
                {
                    yield return $"{a}{((i & 0x01) > 0 ? '+' : '-')}{b}{((i & 0x02) > 0 ? '+' : '-')}{c}{((i & 0x04) > 0 ? '+' : '-')}{d}=7";
                    yield break;
                }
            }
        }
    }
}
