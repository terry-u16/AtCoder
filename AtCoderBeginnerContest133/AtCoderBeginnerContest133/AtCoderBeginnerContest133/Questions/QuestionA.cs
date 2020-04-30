using AtCoderBeginnerContest133.Questions;
using AtCoderBeginnerContest133.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest133.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nab = inputStream.ReadIntArray();
            var n = nab[0];
            var a = nab[1];
            var b = nab[2];

            yield return Math.Min(n * a, b);
        }
    }
}
