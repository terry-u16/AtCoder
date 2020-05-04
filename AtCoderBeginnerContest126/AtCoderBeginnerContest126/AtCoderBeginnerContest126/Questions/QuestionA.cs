using AtCoderBeginnerContest126.Questions;
using AtCoderBeginnerContest126.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest126.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var k = nk[1] - 1;
            var s = inputStream.ReadLine().ToCharArray();

            s[k] = (char)(s[k] + ('a' - 'A'));

            yield return string.Concat(s);
        }
    }
}
