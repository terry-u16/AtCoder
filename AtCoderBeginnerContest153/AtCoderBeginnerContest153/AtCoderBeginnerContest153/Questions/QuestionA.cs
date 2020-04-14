using AtCoderBeginnerContest153.Questions;
using AtCoderBeginnerContest153.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest153.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ha = inputStream.ReadIntArray();
            var h = ha[0];
            var a = ha[1];
            yield return (int)Math.Ceiling((double)h / a);
        }
    }
}
