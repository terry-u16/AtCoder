using AtCoderBeginnerContest116.Questions;
using AtCoderBeginnerContest116.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest116.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var edges = inputStream.ReadIntArray();
            var a = edges[0];
            var b = edges[1];
            yield return a * b / 2;
        }
    }
}
