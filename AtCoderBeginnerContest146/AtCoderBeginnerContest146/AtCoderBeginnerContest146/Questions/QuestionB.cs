using AtCoderBeginnerContest146.Questions;
using AtCoderBeginnerContest146.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest146.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();
            yield return string.Concat(s.Select(c => (char)((c - 'A' + n) % 26 + 'A')));
        }
    }
}
