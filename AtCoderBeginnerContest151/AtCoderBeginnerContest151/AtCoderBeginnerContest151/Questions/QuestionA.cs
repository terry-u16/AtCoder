using AtCoderBeginnerContest151.Questions;
using AtCoderBeginnerContest151.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest151.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            yield return (char)(inputStream.ReadLine()[0] + 1);
        }
    }
}
