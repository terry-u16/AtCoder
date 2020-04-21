using AtCoderBeginnerContest145.Questions;
using AtCoderBeginnerContest145.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest145.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var r = inputStream.ReadInt();
            yield return r * r;
        }
    }
}
