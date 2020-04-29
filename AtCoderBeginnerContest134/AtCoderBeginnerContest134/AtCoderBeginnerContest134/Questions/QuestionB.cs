using AtCoderBeginnerContest134.Questions;
using AtCoderBeginnerContest134.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest134.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nd = inputStream.ReadIntArray();
            var n = nd[0];
            var d = nd[1];

            var range = 2 * d + 1;
            yield return (int)Math.Ceiling((double)n / range);
        }
    }
}
