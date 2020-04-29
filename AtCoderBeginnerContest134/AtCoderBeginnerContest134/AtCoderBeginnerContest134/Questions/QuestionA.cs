using AtCoderBeginnerContest134.Questions;
using AtCoderBeginnerContest134.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest134.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var r = inputStream.ReadInt();
            yield return 3 * r * r;
        }
    }
}
