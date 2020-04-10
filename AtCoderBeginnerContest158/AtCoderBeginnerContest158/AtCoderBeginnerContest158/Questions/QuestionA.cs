using AtCoderBeginnerContest158.Questions;
using AtCoderBeginnerContest158.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest158.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            yield return s.All(c => c == 'A') || s.All(c => c == 'B') ? "No" : "Yes";
        }
    }
}
