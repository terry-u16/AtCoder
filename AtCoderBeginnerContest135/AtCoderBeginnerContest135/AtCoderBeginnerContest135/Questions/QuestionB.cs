using AtCoderBeginnerContest135.Questions;
using AtCoderBeginnerContest135.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtCoderBeginnerContest135.Questions
{
    public class QuestionB : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var n = inputStream.ReadInt();
            var p = inputStream.ReadIntArray();

            var wrongCount = 0;
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] != i + 1)
                {
                    wrongCount++;
                }
            }

            if (wrongCount <= 2)
            {
                yield return "YES";
            }
            else
            {
                yield return "NO";
            }
        }
    }
}
