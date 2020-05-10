using AtCoderBeginnerContest167.Algorithms;
using AtCoderBeginnerContest167.Collections;
using AtCoderBeginnerContest167.Questions;
using AtCoderBeginnerContest167.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest167.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var t = inputStream.ReadLine();
            yield return s == t.Substring(0, s.Length) ? "Yes" : "No";
        }
    }
}
