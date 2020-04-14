using AtCoderBeginnerContest153.Questions;
using AtCoderBeginnerContest153.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest153.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];
            var h = inputStream.ReadLongArray();

            yield return h.OrderByDescending(i => i).Skip(k).Sum();
        }
    }
}
