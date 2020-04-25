using AtCoderBeginnerContest138.Questions;
using AtCoderBeginnerContest138.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest138.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var a = inputStream.ReadDoubleArray();

            yield return 1.0 / a.Sum(d => 1.0 / d);
        }
    }
}
