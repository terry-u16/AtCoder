using AtCoderBeginnerContest152.Questions;
using AtCoderBeginnerContest152.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest152.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var p = inputStream.ReadIntArray();

            int count = 0;
            int min = p[0];
            foreach (var pi in p)
            {
                if (pi <= min)
                {
                    count++;
                }
                min = Math.Min(min, pi);
            }

            yield return count;
        }
    }
}
