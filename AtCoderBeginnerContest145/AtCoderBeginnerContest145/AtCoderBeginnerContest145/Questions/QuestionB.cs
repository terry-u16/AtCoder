using AtCoderBeginnerContest145.Questions;
using AtCoderBeginnerContest145.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest145.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            if (n % 2 != 0)
            {
                yield return "No";
                yield break;
            }

            yield return s.Substring(0, n / 2) == s.Substring(n / 2) ? "Yes" : "No";
        }
    }
}
