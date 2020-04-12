using AtCoderBeginnerContest155.Questions;
using AtCoderBeginnerContest155.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest155.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadIntArray();
            var a = abc[0];
            var b = abc[1];
            var c = abc[2];

            if ((a == b && b != c) ||
                (b == c && c != a) ||
                (c == a && a != b))
            {
                yield return "Yes";
            }
            else
            {
                yield return "No";
            }
        }
    }
}
