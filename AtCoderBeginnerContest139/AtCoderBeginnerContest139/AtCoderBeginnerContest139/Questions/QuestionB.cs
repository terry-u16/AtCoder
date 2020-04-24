using AtCoderBeginnerContest139.Questions;
using AtCoderBeginnerContest139.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest139.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();
            var a = ab[0];
            var b = ab[1];

            var receptacles = 1;
            var taps = 0;

            while (receptacles < b)
            {
                receptacles += a - 1;
                taps++;
            }

            yield return taps;
        }
    }
}
