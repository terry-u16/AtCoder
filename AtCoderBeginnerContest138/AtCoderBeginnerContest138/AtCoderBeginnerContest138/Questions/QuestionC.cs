using AtCoderBeginnerContest138.Questions;
using AtCoderBeginnerContest138.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest138.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var v = inputStream.ReadDoubleArray();
            Array.Sort(v);

            yield return v.Skip(1).Aggregate(v[0], (a, b) => (a + b) / 2);
        }
    }
}
