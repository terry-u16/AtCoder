using AtCoderBeginnerContest130.Questions;
using AtCoderBeginnerContest130.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest130.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var xa = inputStream.ReadIntArray();
            var x = xa[0];
            var a = xa[1];
            yield return x < a ? 0 : 10;
        }
    }
}
