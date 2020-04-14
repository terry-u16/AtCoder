using AtCoderBeginnerContest152.Questions;
using AtCoderBeginnerContest152.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest152.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();

            var a = string.Concat(Enumerable.Repeat(ab[0].ToString(), ab[1]));
            var b = string.Concat(Enumerable.Repeat(ab[1].ToString(), ab[0]));

            yield return a.CompareTo(b) <= 0 ? a : b;
        }
    }
}
