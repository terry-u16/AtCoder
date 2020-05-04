using AtCoderBeginnerContest129.Questions;
using AtCoderBeginnerContest129.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest129.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var pqr = inputStream.ReadIntArray();
            var p = pqr[0];
            var q = pqr[1];
            var r = pqr[2];

            yield return Math.Min(Math.Min(p + q, q + r), r + p);
        }
    }
}
