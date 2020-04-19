using AtCoderBeginnerContest163.Algorithms;
using AtCoderBeginnerContest163.Collections;
using AtCoderBeginnerContest163.Questions;
using AtCoderBeginnerContest163.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest163.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var r = inputStream.ReadInt();
            yield return 2 * Math.PI * r;
        }
    }
}
