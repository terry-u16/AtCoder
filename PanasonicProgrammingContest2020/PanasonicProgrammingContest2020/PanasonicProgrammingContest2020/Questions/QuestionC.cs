using PanasonicProgrammingContest2020.Questions;
using PanasonicProgrammingContest2020.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PanasonicProgrammingContest2020.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var abc = inputStream.ReadLongArray();
            var a = abc[0];
            var b = abc[1];
            var c = abc[2];

            yield return a + b < c && 4 * a * b < (c - a - b) * (c - a - b) ? "Yes" : "No";
        }
    }
}
