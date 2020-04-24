using AtCoderBeginnerContest140.Questions;
using AtCoderBeginnerContest140.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest140.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var count = n - 1;
            yield return n * n * n;
        }
    }
}
