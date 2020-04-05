using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Atcoder.PracticeContest.Extensions;

namespace Atcoder.PracticeContest.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override string Solve(TextReader inputStream)
        {
            var a = inputStream.ReadInt();
            var bc = inputStream.ReadIntArray();
            var b = bc[0];
            var c = bc[1];
            var s = inputStream.ReadLine();

            return $"{a + b + c} {s}";
        }
    }
}
