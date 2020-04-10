using AtCoderBeginnerContest159.Questions;
using AtCoderBeginnerContest159.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest159.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var l = inputStream.ReadDouble();

            var v = Math.Pow(l / 3, 3);
            yield return v;
        }
    }
}
