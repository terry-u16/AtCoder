using AtCoderBeginnerContest154.Questions;
using AtCoderBeginnerContest154.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest154.Questions
{
    public class QuestionA : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var st = inputStream.ReadStringArray();
            var ab = inputStream.ReadIntArray();
            var u = inputStream.ReadLine();

            if (st[0] == u)
            {
                yield return $"{ab[0] - 1} {ab[1]}";
            }
            else
            {
                yield return $"{ab[0]} {ab[1] - 1}";
            }
        }
    }
}
