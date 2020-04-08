using AtcoderBeginnerContest160.Questions;
using AtcoderBeginnerContest160.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtcoderBeginnerContest160.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            yield return s[2] == s[3] && s[4] == s[5] ? "Yes" : "No";
        }
    }
}
