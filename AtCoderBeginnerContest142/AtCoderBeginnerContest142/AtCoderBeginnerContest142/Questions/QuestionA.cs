using AtCoderBeginnerContest142.Questions;
using AtCoderBeginnerContest142.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest142.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var odd = (n + 1) / 2;
            yield return (double)odd / n;
        }
    }
}
