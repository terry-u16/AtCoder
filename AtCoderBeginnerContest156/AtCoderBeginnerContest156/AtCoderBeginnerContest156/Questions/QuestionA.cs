using AtCoderBeginnerContest156.Questions;
using AtCoderBeginnerContest156.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest156.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nr = inputStream.ReadIntArray();
            var n = nr[0];
            var r = nr[1];

            if (n >= 10)
            {
                yield return r;
            }
            else
            {
                yield return r + 100 * (10 - n);
            }
        }
    }
}
