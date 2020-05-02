using AtCoderBeginnerContest130.Questions;
using AtCoderBeginnerContest130.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest130.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var whxy = inputStream.ReadIntArray();
            var w = whxy[0];
            var h = whxy[1];
            var x = whxy[2];
            var y = whxy[3];

            yield return $"{(double)w * h / 2} {(x * 2 == w && y * 2 == h ? 1 : 0)}";
        }
    }
}
