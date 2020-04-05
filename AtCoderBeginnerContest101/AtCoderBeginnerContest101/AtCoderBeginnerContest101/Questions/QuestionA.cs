using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Atcoder.AtCoderBeginnerContest101.Extensions;

namespace Atcoder.AtCoderBeginnerContest101.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override string Solve(TextReader inputStream)
        {
            var s = inputStream.ReadLine();
            return (s.Count(c => c == '+') - s.Count(c => c == '-')).ToString();
        }
    }
}
