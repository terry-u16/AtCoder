using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Atcoder.AtCoderBeginnerContest101.Extensions;

namespace Atcoder.AtCoderBeginnerContest101.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override string Solve(TextReader inputStream)
        {
            var nk = inputStream.ReadIntArray();
            var n = nk[0];
            var k = nk[1];

            return ((int)(Math.Ceiling((n - 1.0) / (k - 1.0)) + double.Epsilon)).ToString();
        }
    }
}
