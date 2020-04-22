using AtCoderBeginnerContest143.Questions;
using AtCoderBeginnerContest143.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest143.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var d = inputStream.ReadIntArray();

            var sum = 0;

            for (int i = 0; i < d.Length; i++)
            {
                for (int j = i + 1; j < d.Length; j++)
                {
                    sum += d[i] * d[j];
                }
            }

            yield return sum;
        }
    }
}
