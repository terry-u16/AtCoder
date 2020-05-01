using AtCoderBeginnerContest132.Questions;
using AtCoderBeginnerContest132.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest132.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var p = inputStream.ReadIntArray();

            var count = 0;
            for (int i = 1; i < n - 1; i++)
            {
                if ((p[i - 1] < p[i] && p[i] < p[i + 1]) || (p[i + 1] < p[i] && p[i] < p[i - 1]))
                {
                    count++;
                }
            }

            yield return count;
        }
    }
}
