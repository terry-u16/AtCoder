using AtCoderBeginnerContest136.Questions;
using AtCoderBeginnerContest136.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest136.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();
            var a = abc[0];
            var b = abc[1];
            var c = abc[2];

            c -= a - b;
            yield return Math.Max(c, 0);
        }
    }
}
