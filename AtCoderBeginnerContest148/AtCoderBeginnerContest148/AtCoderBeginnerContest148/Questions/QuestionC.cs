using AtCoderBeginnerContest148.Questions;
using AtCoderBeginnerContest148.Extensions;
using AtCoderBeginnerContest148.Algorithms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest148.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var ab = inputStream.ReadIntArray();
            var a = ab[0];
            var b = ab[1];

            yield return BasicAlgorithm.Lcm(a, b);
        }
    }
}
