using AtCoderBeginnerContest137.Questions;
using AtCoderBeginnerContest137.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest137.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();
            var a = ab[0];
            var b = ab[1];
            var plus = a + b;
            var sub = a - b;
            var mul = a * b;
            yield return Math.Max(Math.Max(plus, sub), mul);
        }
    }
}
