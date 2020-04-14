using AtCoderBeginnerContest153.Questions;
using AtCoderBeginnerContest153.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest153.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var hn = inputStream.ReadIntArray();
            long h = hn[0];
            int n = hn[1];
            var a = inputStream.ReadLongArray();

            yield return h - a.Sum() <= 0 ? "Yes" : "No";
        }
    }
}
