using AtCoderBeginnerContest125.Questions;
using AtCoderBeginnerContest125.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest125.Questions
{
    public class QuestionD : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadIntArray();
            var a = inputStream.ReadLongArray();
            var minusCount = a.Count(i => i < 0);

            if (minusCount % 2 == 0)
            {
                yield return a.Sum(i => Math.Abs(i));
            }
            else
            {
                yield return a.Sum(i => Math.Abs(i)) - 2 * a.Min(i => Math.Abs(i));
            }
        }
    }
}
