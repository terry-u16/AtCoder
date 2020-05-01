using AtCoderBeginnerContest132.Questions;
using AtCoderBeginnerContest132.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest132.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine().OrderBy(c => c).ToArray();

            yield return s[0] == s[1] && s[1] != s[2] && s[2] == s[3] ? "Yes" : "No";
        }
    }
}
