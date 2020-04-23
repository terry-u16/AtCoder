using AtCoderBeginnerContest142.Questions;
using AtCoderBeginnerContest142.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest142.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];
            var h = inputStream.ReadIntArray();

            yield return h.Count(i => i >= k);
        }
    }
}
