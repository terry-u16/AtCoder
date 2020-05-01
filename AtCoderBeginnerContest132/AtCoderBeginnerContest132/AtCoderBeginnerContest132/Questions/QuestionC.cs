using AtCoderBeginnerContest132.Questions;
using AtCoderBeginnerContest132.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest132.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var d = inputStream.ReadIntArray();
            Array.Sort(d);

            var abcLast = d[n / 2 - 1];
            var arcFirst = d[n / 2];

            yield return arcFirst - abcLast;
        }
    }
}
