using AtCoderBeginnerContest150.Questions;
using AtCoderBeginnerContest150.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest150.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var kx = inputStream.ReadIntArray();
            var k = kx[0];
            var x = kx[1];

            yield return 500 * k >= x ? "Yes" : "No";
        }
    }
}
