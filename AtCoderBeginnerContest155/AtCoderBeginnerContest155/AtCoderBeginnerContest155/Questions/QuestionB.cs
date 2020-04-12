using AtCoderBeginnerContest155.Questions;
using AtCoderBeginnerContest155.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest155.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadIntArray();

            if (a.Where(i => i % 2 == 0).All(i => i % 3 == 0 || i % 5 == 0))
            {
                yield return "APPROVED";
            }
            else
            {
                yield return "DENIED";
            }
        }
    }
}
