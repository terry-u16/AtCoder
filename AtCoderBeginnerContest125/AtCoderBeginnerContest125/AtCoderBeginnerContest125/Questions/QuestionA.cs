using AtCoderBeginnerContest125.Questions;
using AtCoderBeginnerContest125.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest125.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abt = inputStream.ReadIntArray();
            var a = abt[0];
            var b = abt[1];
            var t = abt[2];

            yield return (t / a) * b;
        }
    }
}
