using AtCoderBeginnerContest156.Questions;
using AtCoderBeginnerContest156.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest156.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];

            var digit = 0;
            while (n > 0)
            {
                digit++;
                n /= k;
            }

            yield return digit;
        }
    }
}
