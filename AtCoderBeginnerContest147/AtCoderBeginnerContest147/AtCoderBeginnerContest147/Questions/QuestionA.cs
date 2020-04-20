using AtCoderBeginnerContest147.Questions;
using AtCoderBeginnerContest147.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest147.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            yield return inputStream.ReadIntArray().Sum() > 21 ? "bust" : "win";
        }
    }
}
