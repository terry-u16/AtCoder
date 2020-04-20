using AtCoderBeginnerContest148.Questions;
using AtCoderBeginnerContest148.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest148.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var a = inputStream.ReadIntArray();
            var b = inputStream.ReadIntArray();
            yield return new[] { 1, 2, 3, }.Except(a).Except(b).Single();
        }
    }
}
