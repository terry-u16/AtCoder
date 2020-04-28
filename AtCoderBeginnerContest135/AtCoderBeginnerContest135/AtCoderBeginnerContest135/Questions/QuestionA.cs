using AtCoderBeginnerContest135.Questions;
using AtCoderBeginnerContest135.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest135.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();
            var a = ab[0];
            var b = ab[1];

            var k = (a + b) / 2;

            if (Math.Abs(a - k) == Math.Abs(b - k))
            {
                yield return k;
            }
            else
            {
                yield return "IMPOSSIBLE";
            }
        }
    }
}
