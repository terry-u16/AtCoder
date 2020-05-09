using AtCoderBeginnerContest120.Questions;
using AtCoderBeginnerContest120.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest120.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            var zeros = s.Count(c => c == '0');
            var ones = s.Count(c => c == '1');
            yield return Math.Min(zeros, ones) * 2;
        }
    }
}
