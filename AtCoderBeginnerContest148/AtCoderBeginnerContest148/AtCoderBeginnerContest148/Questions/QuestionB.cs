using AtCoderBeginnerContest148.Questions;
using AtCoderBeginnerContest148.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest148.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var st = inputStream.ReadString().Split(' ');
            var s = st[0];
            var t = st[1];

            var result = new StringBuilder();

            foreach (var chars in s.Zip(t, (s1, t1) => new { s1, t1 }))
            {
                result.Append(chars.s1);
                result.Append(chars.t1);
            }

            yield return result.ToString();
        }
    }
}
