using AtCoderBeginnerContest144.Questions;
using AtCoderBeginnerContest144.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest144.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();
            var a = ab[0];
            var b = ab[1];
            if (a < 10 && b < 10)
            {
                yield return a * b;
            }
            else
            {
                yield return -1;
            }
        }
    }
}
