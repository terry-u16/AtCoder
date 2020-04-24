using AtCoderBeginnerContest139.Questions;
using AtCoderBeginnerContest139.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest139.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            long n = inputStream.ReadLong();
            yield return n * (n - 1) / 2;
        }
    }
}
