using AtCoderBeginnerContest127.Questions;
using AtCoderBeginnerContest127.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest127.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();
            var a = ab[0];
            var b = ab[1];

            if (a >= 13)
            {
                yield return b;
            }
            else if (a >= 6)
            {
                yield return b / 2;
            }
            else
            {
                yield return 0;
            }
        }
    }
}
