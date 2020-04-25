using AtCoderBeginnerContest138.Questions;
using AtCoderBeginnerContest138.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest138.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var a = inputStream.ReadInt();
            var s = inputStream.ReadLine();

            if (a >= 3200)
            {
                yield return s;
            }
            else
            {
                yield return "red";
            }
        }
    }
}
